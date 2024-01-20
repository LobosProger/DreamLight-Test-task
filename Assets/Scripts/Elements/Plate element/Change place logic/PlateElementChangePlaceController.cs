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
		Transform newLayoutListForThisPlate = anotherPlateModel.GetLayoutParentOfPlate();
		int newSiblingIndexInLayoutForThisPlate = anotherPlateModel.transform.GetSiblingIndex();

		Transform newLayoutListExchangingPlate = plateElementModel.GetLayoutParentOfPlate();
		int newSiblingIndexInLayoutForExchangingPlate = transform.GetSiblingIndex();

		SetNewPlatePositionAndList(newSiblingIndexInLayoutForThisPlate, newLayoutListForThisPlate);
		anotherPlateController.SetNewPlatePositionAndList(newSiblingIndexInLayoutForExchangingPlate, newLayoutListExchangingPlate);
	}

	private void ChangeListOfPlateElement(VerticalLayoutGroup anotherListLayout)
	{
		plateElementModel.SetLayoutParentOfPlate(anotherListLayout.transform);
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

	public void SetNewPlatePositionAndList(int newSiblingIndex, Transform listLayout)
	{
		plateElementModel.SetLayoutParentOfPlate(listLayout);
		plateElementModel.SetSiblingIndexOfPlate(newSiblingIndex);
		StartCoroutine(WaitRefreshingLayoutListAndCaptureInitialPosition());
	}

	private IEnumerator WaitRefreshingLayoutListAndCaptureInitialPosition()
	{
		yield return new WaitForEndOfFrame();

		Vector2 newInitialPositionOfPlate = transform.position;
		plateElementModel.CaptureInitialPlatePosition(newInitialPositionOfPlate);
	}

	// TODO: Create logic of capturing needed data for simplify logic in function ExchangePlatePositions
	private class PlateElementDataSnapshot
	{

	}
}