using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlateElementNamespace;
using UnityEngine.UI;

public class ElementsPanelShowerModel : MonoBehaviour
{
	[SerializeField] private string nameOfList;
    [SerializeField] private List<PlateElementData> platesList = new List<PlateElementData>();
	[SerializeField] private VerticalLayoutGroup panelOfPlates;

	public List<PlateElementData> GetListOfAssignedPlateElementsFromInspector()
	{
		return platesList;
	}

	public string GetNameOfList()
	{
		return nameOfList;
	}

	public int GetAmountOfPlatesInList()
	{
		return panelOfPlates.transform.childCount;
	}
}
