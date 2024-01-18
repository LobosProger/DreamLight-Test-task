using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlateElementPickerController : MonoBehaviour, IDragHandler
{
	public void OnDrag(PointerEventData eventData)
	{
		transform.position = eventData.position;
		//Debug.Log($"Dragging - {gameObject.name}");
	}
}
