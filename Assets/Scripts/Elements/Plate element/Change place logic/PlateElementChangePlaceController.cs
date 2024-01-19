using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

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
		PlateElementChangePlaceModel anotherPlateModel = null;
		PlateElementChangePlaceController anotherPlateController = null;

		if (IsEnteredPointerInAnotherPlateElement(eventData, out anotherPlateModel))
		{
			anotherPlateController = anotherPlateModel.GetComponent<PlateElementChangePlaceController>();
			ExchangePositionsOfPlates(anotherPlateModel, anotherPlateController);
			
			PlateElementEvents.OnChangedPlaceOfPlateElement?.Invoke();
		}
		else
		{
			ReturnPlateToOldPosition();
		}
	}

	private void ExchangePositionsOfPlates(PlateElementChangePlaceModel anotherPlateModel, 
		PlateElementChangePlaceController anotherPlateController)
	{
		Transform newLayoutListForThisPlate = anotherPlateModel.GetLayoutParentOfPlate();
		Vector2 newPositionForThisPlate = anotherPlateModel.GetInitialPlatePosition();
		
		Transform newLayoutListExchangingPlate = plateElementModel.GetLayoutParentOfPlate();
		Vector2 newPositionForExchangingPlate = plateElementModel.GetInitialPlatePosition();

		SetNewPlatePositionAndList(newPositionForThisPlate, newLayoutListForThisPlate);
		anotherPlateController.SetNewPlatePositionAndList(newPositionForExchangingPlate, newLayoutListExchangingPlate);
	}

	private void ReturnPlateToOldPosition()
	{
		Vector2 oldPlatePosition = plateElementModel.GetInitialPlatePosition();
		SetNewPlatePositionAndList(oldPlatePosition, transform.parent);
	}

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

	public void SetNewPlatePositionAndList(Vector2 newPosition, Transform listLayout)
	{
		plateElementModel.CaptureInitialPlatePosition(newPosition);
		plateElementModel.SetLayoutParentOfPlate(listLayout);
		transform.position = newPosition;
	}
}