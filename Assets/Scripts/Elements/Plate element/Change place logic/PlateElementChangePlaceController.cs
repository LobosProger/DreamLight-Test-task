using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using PlateElementLayoutSnapshotNamespace;

public class PlateElementChangePlaceController : MonoBehaviour, IPointerUpHandler
{
	private PlateElementDetectorController plateElementDetectorController;
	private PlateElementChangePlaceModel plateElementModel;

	private IEnumerator Start()
	{
		// Just waiting and capturing initial position after refreshing and work of VerticalLayoutComponent.
		// Because in the start of frame, it assigns zero position to layout elements, so just wait one frame
		yield return new WaitForEndOfFrame();

		plateElementDetectorController = GetComponent<PlateElementDetectorController>();
		plateElementModel = GetComponent<PlateElementChangePlaceModel>();
		plateElementModel.CaptureInitialPlatePosition(transform.position);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		PlateElementChangePlaceController anotherPlateController = null;
		VerticalLayoutGroup anotherListLayout = null;

		bool isDetectedAnotherPlate = plateElementDetectorController.IsEnteredPointerInAnotherPlateElement(eventData, out anotherPlateController);
		bool isDetectedAnotherList = plateElementDetectorController.IsEnteredPointerInAnotherList(eventData, out anotherListLayout);
		
		if (isDetectedAnotherPlate)
		{
			ExchangePositionsOfPlates(anotherPlateController);
		}
		else if(isDetectedAnotherList)
		{
			ChangeListOfPlateElement(anotherListLayout);
		}
		else
		{
			ReturnPlateToOldPosition();
		}
	}

	private void ExchangePositionsOfPlates(PlateElementChangePlaceController anotherPlateController)
	{
		PlateElementLayoutSnapshot newLayoutDataForThisPlate = PlateElementLayoutSnapshot.CaptureLayoutSnapshotOfPlate(anotherPlateController.transform);
		PlateElementLayoutSnapshot newLayoutDataForExchangingPlate = PlateElementLayoutSnapshot.CaptureLayoutSnapshotOfPlate(transform);

		SetNewPlatePositionAndList(newLayoutDataForThisPlate);
		anotherPlateController.SetNewPlatePositionAndList(newLayoutDataForExchangingPlate);
	}

	private void ReturnPlateToOldPosition()
	{
		transform.position = plateElementModel.GetInitialPlatePosition();
	}

	private void ChangeListOfPlateElement(VerticalLayoutGroup anotherListLayout)
	{
		// After assigning new list, the sibling index will be automatically attached to the plate element
		plateElementModel.SetLayoutParentOfPlate(anotherListLayout.transform);
		StartCoroutine(WaitRefreshingLayoutListAndCaptureInitialPosition());
		
		PlateElementEvents.OnChangedListOfPlateElement?.Invoke();
	}

	private IEnumerator WaitRefreshingLayoutListAndCaptureInitialPosition()
	{
		yield return new WaitForEndOfFrame();
		Vector2 newInitialPositionOfPlate = transform.position;
		plateElementModel.CaptureInitialPlatePosition(newInitialPositionOfPlate);
	}

	public void SetNewPlatePositionAndList(PlateElementLayoutSnapshot capturedSiblingIndexAndParentList)
	{
		plateElementModel.SetLayoutParentOfPlate(capturedSiblingIndexAndParentList.GetCapturedLayoutListOfPlate());
		plateElementModel.SetSiblingIndexOfPlate(capturedSiblingIndexAndParentList.GetCapturedSiblingIndex());
		StartCoroutine(WaitRefreshingLayoutListAndCaptureInitialPosition());
	}
}