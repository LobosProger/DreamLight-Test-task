using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateElementPickerModel : MonoBehaviour
{
    private Vector2 capturedOffsetPosition;

    public void CapturePointerPositionForOffset(Vector2 capturedPosition)
    {
        Vector2 elementPosition = transform.position;
		capturedOffsetPosition = elementPosition - capturedPosition;
	}

    public Vector2 GetOffsetForDraggingElement()
    {
        return capturedOffsetPosition;
	}
}
