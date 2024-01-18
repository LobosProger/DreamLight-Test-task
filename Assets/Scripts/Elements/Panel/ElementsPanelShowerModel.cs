using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsPanelShowerModel : MonoBehaviour
{
    [SerializeField] private List<PlateElement> platesList = new List<PlateElement>();

    public List<PlateElement> GetListOfPlateElements()
	{
		return platesList;
	}
}

[System.Serializable]
public struct PlateElement
{
	public string nameOfPlate;
	public int numberOfPlate;
}
