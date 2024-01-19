using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class PlateElementPickerController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
	private PlateElementPickerModel plateElementPickerModel;

	private IEnumerator Start()
	{
		yield return new WaitForEndOfFrame();
		plateElementPickerModel = GetComponent<PlateElementPickerModel>();
		plateElementPickerModel.CaptureInitialPlatePosition(transform.position);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		Vector2 pointerPosition = eventData.position;
		plateElementPickerModel.CapturePointerPositionForOffset(pointerPosition);
	}

	public void OnDrag(PointerEventData eventData)
	{
		Vector2 pointerPosition = eventData.position;
		Vector2 dragPositionForPlate = pointerPosition + plateElementPickerModel.GetOffsetForDraggingElement();
		transform.position = dragPositionForPlate;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		PlateElementPickerModel anotherPlateModel = null;
		PlateElementPickerController anotherPlateController = null;

		if (IsEnteredPointerInAnotherPlateElement(eventData, out anotherPlateModel))
		{
			anotherPlateController = anotherPlateModel.GetComponent<PlateElementPickerController>();
			ExchangePositionsOfPlates(anotherPlateModel, anotherPlateController);
		} else
		{
			Vector2 oldPlatePosition = plateElementPickerModel.GetInitialPlatePosition();
			SetPlatePosition(oldPlatePosition);
		}
	}

	private bool IsEnteredPointerInAnotherPlateElement(PointerEventData eventData, out PlateElementPickerModel anotherPlate)
	{
		anotherPlate = null;
		List<RaycastResult> allRaycastedElementsInPointer = new List<RaycastResult>();
		
		EventSystem.current.RaycastAll(eventData, allRaycastedElementsInPointer);
		foreach(RaycastResult eachRaycastedElement in  allRaycastedElementsInPointer)
		{
			if(eachRaycastedElement.gameObject != this.gameObject && eachRaycastedElement.gameObject.TryGetComponent(out anotherPlate))
			{
				return true;
			}
		}

		return false;
	}

	private void ExchangePositionsOfPlates(PlateElementPickerModel anotherPlateModel, PlateElementPickerController anotherPlateController)
	{
		Vector2 newPositionForThisPlate = anotherPlateModel.GetInitialPlatePosition();
		Vector2 newPositionForExchangingPlate = plateElementPickerModel.GetInitialPlatePosition();

		SetPlatePosition(newPositionForThisPlate);
		anotherPlateController.SetPlatePosition(newPositionForExchangingPlate);
	}

	public void SetPlatePosition(Vector2 newPosition)
	{
		plateElementPickerModel.CaptureInitialPlatePosition(newPosition);
		transform.position = newPosition;
	}
}