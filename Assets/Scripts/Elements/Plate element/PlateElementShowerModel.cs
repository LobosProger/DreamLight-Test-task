using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateElementShowerModel : MonoBehaviour
{
    private PlateElement plateElement;

    public void SetPlateElementData(PlateElement plateElement)
    {
        this.plateElement = plateElement;
    }

	public PlateElement GetPlateElementData()
	{
        return plateElement;
	}
}
