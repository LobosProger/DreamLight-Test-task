using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class PlateElementPickerController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
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

	public void OnPointerUp(PointerEventData eventData)
	{
		PlateElementPickerController anotherPlate = null;

		if (IsEnteredInPointerAnotherPlateElement(eventData, out anotherPlate))
		{
			Debug.Log($"Entered into: {anotherPlate.name}");
		}
	}

	private bool IsEnteredInPointerAnotherPlateElement(PointerEventData eventData, out PlateElementPickerController anotherPlate)
	{
		anotherPlate = null;
		List<RaycastResult> allRaycastedElementsInPointer = new List<RaycastResult>();
		
		EventSystem.current.RaycastAll(eventData, allRaycastedElementsInPointer);
		foreach(RaycastResult eachRaycastedElement in  allRaycastedElementsInPointer)
		{
			if(eachRaycastedElement.gameObject != gameObject && eachRaycastedElement.gameObject.TryGetComponent(out anotherPlate))
			{
				return true;
			}
		}

		return false;
	}
}
