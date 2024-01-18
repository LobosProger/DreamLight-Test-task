using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlateElementNamespace;

public class PlateElementShowerModel : MonoBehaviour
{
    private PlateElementData plateElement;

    public void SetPlateElementData(PlateElementData plateElement)
    {
        this.plateElement = plateElement;
    }

	public PlateElementData GetPlateElementData()
	{
        return plateElement;
	}
}
