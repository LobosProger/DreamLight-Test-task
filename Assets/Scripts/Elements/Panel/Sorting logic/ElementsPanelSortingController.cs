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
	}

	private void SortPlateElementsByNumber(bool descendingOrder)
	{
		List<PlateElementData> sortedElements = elementsPanelSortingModel.GetSortedListOfPlatesByNumber(descendingOrder);
		elementsShowerController.ShowPlateElementsByListOnUI(sortedElements);
	}
}
