using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateElementChangePlaceModel : MonoBehaviour
{
	private Vector2 initialPlatePosition;

	public void CaptureInitialPlatePosition(Vector2 initialPosition)
	{
		initialPlatePosition = initialPosition;
	}

	public Vector2 GetInitialPlatePosition()
	{
		return initialPlatePosition;
	}

	public Transform GetLayoutParentOfPlate()
    {
        return transform.parent;
    }

    public void SetLayoutParentOfPlate(Transform parentLayout)
    {
        transform.SetParent(parentLayout);
    }

	public int GetSiblingIndexOfPlate()
	{
		return transform.GetSiblingIndex();
	}

	public void SetSiblingIndexOfPlate(int newSiblingIndex)
	{
		transform.SetSiblingIndex(newSiblingIndex);
	}
}
