using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using PlateElementNamespace;

public class ElementsPanelSortingModel : MonoBehaviour
{
	[SerializeField] private VerticalLayoutGroup panelOfCreatedElements;

	private List<PlateElementData> GetListOfCreatedPlateElementsData()
	{
		List<PlateElementData> plateElementsData = new List<PlateElementData>();
		List<PlateElementShowerModel> plateElementsModelList = panelOfCreatedElements.GetComponentsInChildren<PlateElementShowerModel>().ToList();

		foreach (PlateElementShowerModel eachModel in plateElementsModelList)
		{
			plateElementsData.Add(eachModel.GetPlateElementData());
		}

		return plateElementsData;
	}

	public List<PlateElementData> GetSortedListOfPlatesByNumber(bool descendingSort)
	{
		List<PlateElementData> sortingElements = GetListOfCreatedPlateElementsData();
		if (descendingSort)
		{
			sortingElements = sortingElements.OrderByDescending(element => element.GetNumberOfPlate()).ToList();
		}
		else
		{
			sortingElements = sortingElements.OrderByDescending(element => element.GetNumberOfPlate()).Reverse().ToList();
		}

		return sortingElements;
	}
}