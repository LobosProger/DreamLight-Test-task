using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class PlateElementChangePlaceController : MonoBehaviour, IPointerUpHandler
{
	private PlateElementChangePlaceModel plateElementModel;

	private IEnumerator Start()
	{
		// Just waiting and capturing initial position after refreshing and work of VerticalLayoutComponent.
		// Because in the start of frame, it assigns zero position to layout elements, so just wait one frame
		yield return new WaitForEndOfFrame();

		plateElementModel = GetComponent<PlateElementChangePlaceModel>();
		plateElementModel.CaptureInitialPlatePosition(transform.position);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		// TODO: Refactor it, remove model, write method which gives snapshot
		PlateElementChangePlaceModel anotherPlateModel = null;
		PlateElementChangePlaceController anotherPlateController = null;
		VerticalLayoutGroup anotherListLayout = null;

		if (IsEnteredPointerInAnotherPlateElement(eventData, out anotherPlateModel))
		{
			anotherPlateController = anotherPlateModel.GetComponent<PlateElementChangePlaceController>();
			ExchangePositionsOfPlates(anotherPlateModel, anotherPlateController);
		}
		else if(IsEnteredPointerInAnotherList(eventData, out anotherListLayout))
		{
			ChangeListOfPlateElement(anotherListLayout);
		}
		else
		{
			ReturnPlateToOldPosition();
		}
	}

	private void ExchangePositionsOfPlates(PlateElementChangePlaceModel anotherPlateModel, 
		PlateElementChangePlaceController anotherPlateController)
	{
		// TODO: Convert into structures, refactor 
		PlateElementLayoutSnapshot newLayoutDataForThisPlate = PlateElementLayoutSnapshot.CaptureLayoutSnapshotOfPlate(anotherPlateController.transform);
		PlateElementLayoutSnapshot newLayoutDataForExchangingPlate = PlateElementLayoutSnapshot.CaptureLayoutSnapshotOfPlate(transform);

		SetNewPlatePositionAndList(newLayoutDataForThisPlate);
		anotherPlateController.SetNewPlatePositionAndList(newLayoutDataForExchangingPlate);
	}

	// TODO: Refactor it, add logic in another script
	private bool IsEnteredPointerInAnotherPlateElement(PointerEventData eventData, out PlateElementChangePlaceModel anotherPlate)
	{
		anotherPlate = null;
		List<RaycastResult> allRaycastedElementsInPointer = new List<RaycastResult>();

		EventSystem.current.RaycastAll(eventData, allRaycastedElementsInPointer);
		foreach (RaycastResult eachRaycastedElement in allRaycastedElementsInPointer)
		{
			if (eachRaycastedElement.gameObject != this.gameObject && eachRaycastedElement.gameObject.TryGetComponent(out anotherPlate))
			{
				return true;
			}
		}

		return false;
	}

	// TODO: Refactor it, add logic in another script
	private bool IsEnteredPointerInAnotherList(PointerEventData eventData, out VerticalLayoutGroup anotherList)
	{
		anotherList = null;
		List<RaycastResult> allRaycastedElementsInPointer = new List<RaycastResult>();

		EventSystem.current.RaycastAll(eventData, allRaycastedElementsInPointer);
		foreach (RaycastResult eachRaycastedElement in allRaycastedElementsInPointer)
		{
			if (eachRaycastedElement.gameObject != plateElementModel.GetLayoutParentOfPlate().gameObject
				&& eachRaycastedElement.gameObject.TryGetComponent(out anotherList))
			{
				Debug.Log("Another list!");
				return true;
			}
		}

		Debug.Log("Same list or didn't detected!");
		return false;
	}

	private void ReturnPlateToOldPosition()
	{
		transform.position = plateElementModel.GetInitialPlatePosition();
	}

	private void ChangeListOfPlateElement(VerticalLayoutGroup anotherListLayout)
	{
		plateElementModel.SetLayoutParentOfPlate(anotherListLayout.transform);
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

	// TODO: Move it in another file, assign to namespace
	public class PlateElementLayoutSnapshot
	{
		private int siblingIndexOfPlateSnapshot;
		private Transform layoutListOfPlateSnapshot;

		private PlateElementLayoutSnapshot(int siblingIndexOfPlateSnapshot, Transform layoutListOfPlateSnapshot)
		{
			this.siblingIndexOfPlateSnapshot = siblingIndexOfPlateSnapshot;
			this.layoutListOfPlateSnapshot = layoutListOfPlateSnapshot;
		}

		public static PlateElementLayoutSnapshot CaptureLayoutSnapshotOfPlate(Transform plateElement)
		{
			int siblingIndexOfPlate = plateElement.GetSiblingIndex();
			Transform layoutListOfPlate = plateElement.parent;

			PlateElementLayoutSnapshot newSnapshot = new PlateElementLayoutSnapshot(siblingIndexOfPlate, layoutListOfPlate);
			return newSnapshot;
		}

		public int GetCapturedSiblingIndex()
		{
			return siblingIndexOfPlateSnapshot;
		}

		public Transform GetCapturedLayoutListOfPlate()
		{
			return layoutListOfPlateSnapshot;
		}
	}
}