using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlateElementNamespace;

public class ElementsPanelShowerModel : MonoBehaviour
{
    [SerializeField] private List<PlateElementData> platesList = new List<PlateElementData>();

    public List<PlateElementData> GetListOfPlateElements()
	{
		return platesList;
	}
}
