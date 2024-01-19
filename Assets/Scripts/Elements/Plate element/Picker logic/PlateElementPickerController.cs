using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlateElementPickerController : MonoBehaviour, IPointerDownHandler, IDragHandler
{
	private PlateElementPickerModel plateElementPickerModel;

	private void Start()
	{
		plateElementPickerModel = GetComponent<PlateElementPickerModel>();
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
}