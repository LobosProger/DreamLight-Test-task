using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlateElementChangePlaceController : MonoBehaviour, IPointerUpHandler
{
	private PlateElementPickerModel plateElementPickerModel;

	private IEnumerator Start()
	{
		// Just waiting and capturing initial position after refreshing and work of VerticalLayoutComponent.
		// Because in the start of frame, it assigns zero position to layout elements, so just wait one frame
		yield return new WaitForEndOfFrame();

		plateElementPickerModel = GetComponent<PlateElementPickerModel>();
		plateElementPickerModel.CaptureInitialPlatePosition(transform.position);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		PlateElementPickerModel anotherPlateModel = null;
		PlateElementChangePlaceController anotherPlateController = null;

		if (IsEnteredPointerInAnotherPlateElement(eventData, out anotherPlateModel))
		{
			anotherPlateController = anotherPlateModel.GetComponent<PlateElementChangePlaceController>();
			ExchangePositionsOfPlates(anotherPlateModel, anotherPlateController);
		}
		else
		{
			ReturnPlateToOldPosition();
		}
	}

	private void ExchangePositionsOfPlates(PlateElementPickerModel anotherPlateModel, PlateElementChangePlaceController anotherPlateController)
	{
		Vector2 newPositionForThisPlate = anotherPlateModel.GetInitialPlatePosition();
		Vector2 newPositionForExchangingPlate = plateElementPickerModel.GetInitialPlatePosition();

		SetPlatePosition(newPositionForThisPlate);
		anotherPlateController.SetPlatePosition(newPositionForExchangingPlate);
	}

	private void ReturnPlateToOldPosition()
	{
		Vector2 oldPlatePosition = plateElementPickerModel.GetInitialPlatePosition();
		SetPlatePosition(oldPlatePosition);
	}

	private bool IsEnteredPointerInAnotherPlateElement(PointerEventData eventData, out PlateElementPickerModel anotherPlate)
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

	public void SetPlatePosition(Vector2 newPosition)
	{
		plateElementPickerModel.CaptureInitialPlatePosition(newPosition);
		transform.position = newPosition;
	}
}