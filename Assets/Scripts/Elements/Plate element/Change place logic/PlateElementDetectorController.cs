using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlateElementDetectorController : MonoBehaviour
{
	public bool IsEnteredPointerInAnotherPlateElement(PointerEventData eventData, out PlateElementChangePlaceController anotherPlate)
	{
		anotherPlate = null;
		List<RaycastResult> allRaycastedObjects = GetAllRaycastedObjectsInPointerField(eventData);

		foreach (RaycastResult eachRaycastedElement in allRaycastedObjects)
		{
			if (!IsPlateElementIsSame(eachRaycastedElement) && eachRaycastedElement.gameObject.TryGetComponent(out anotherPlate))
			{
				return true;
			}
		}

		return false;
	}

	public bool IsEnteredPointerInAnotherList(PointerEventData eventData, out VerticalLayoutGroup anotherList)
	{
		anotherList = null;
		List<RaycastResult> allRaycastedObjects = GetAllRaycastedObjectsInPointerField(eventData);
		
		foreach (RaycastResult eachRaycastedElement in allRaycastedObjects)
		{
			if (!IsParentLayoutListIsSame(eachRaycastedElement) && eachRaycastedElement.gameObject.TryGetComponent(out anotherList))
			{
				return true;
			}
		}

		return false;
	}

	private List<RaycastResult> GetAllRaycastedObjectsInPointerField(PointerEventData eventData)
	{
		List<RaycastResult> allRaycastedElementsInPointer = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventData, allRaycastedElementsInPointer);
		
		return allRaycastedElementsInPointer;
	}

	private bool IsParentLayoutListIsSame(RaycastResult raycastedObject)
	{
		bool isSame = raycastedObject.gameObject.transform == transform.parent;
		return isSame;
	}

	private bool IsPlateElementIsSame(RaycastResult raycastedObject)
	{
		bool isSame = raycastedObject.gameObject == gameObject;
		return isSame;
	}
}