using PlateElementNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsPanelSortingController : MonoBehaviour
{
	[SerializeField] private ToggleModel sortingByNumberToggle;
	[SerializeField] private ToggleModel sortingByNameToggle;

	private ElementsPanelShowerController elementsShowerController;
    private ElementsPanelSortingModel elementsPanelSortingModel;

	private void Start()
	{
		elementsShowerController = GetComponent<ElementsPanelShowerController>();
		elementsPanelSortingModel = GetComponent<ElementsPanelSortingModel>();
		
		sortingByNumberToggle.OnSwitchedToDescendingOrder += SortPlateElementsByNumber;
		sortingByNameToggle.OnSwitchedToDescendingOrder += SortPlateElementsByName;
	}

	private void SortPlateElementsByNumber(bool descendingOrder)
	{
		List<PlateElementData> sortedElements = elementsPanelSortingModel.GetSortedListOfPlatesByNumber(descendingOrder);
		elementsShowerController.ShowPlateElementsOnUI(sortedElements);
	}

	private void SortPlateElementsByName(bool descendingOrder)
	{
		List<PlateElementData> sortedElements = elementsPanelSortingModel.GetSortedListOfPlatesByName(descendingOrder);
		elementsShowerController.ShowPlateElementsOnUI(sortedElements);
	}
}
