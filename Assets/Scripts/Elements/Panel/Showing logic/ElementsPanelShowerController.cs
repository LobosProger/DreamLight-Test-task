using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlateElementNamespace;
using UnityEngine.UI;
using TMPro;

public class ElementsPanelShowerController : MonoBehaviour
{
    [SerializeField] private PlateElementShowerModel prefabOfPlate;
	[SerializeField] private VerticalLayoutGroup panelOfPlates;

	private ElementsPanelShowerModel elementsPanelModel;
	private ElementsPanelShowerView elementsPanelView;
	
	private void Start()
	{
		InitializeNeededComponents();
		ShowPlateElementsOnUI();
		ShowNameListAndAmountOfPlatesOnUI();

		// After changing by plate element list, we trigger our list on updating actual amount of elements
		PlateElementEvents.OnChangedListOfPlateElement += ShowNameListAndAmountOfPlatesOnUI;
	}

	private void OnDestroy()
	{
		PlateElementEvents.OnChangedListOfPlateElement -= ShowNameListAndAmountOfPlatesOnUI;
	}

	private void InitializeNeededComponents()
	{
		elementsPanelModel = GetComponent<ElementsPanelShowerModel>();
		elementsPanelView = GetComponent<ElementsPanelShowerView>();
	}

	private void ShowPlateElementsOnUI()
	{
		List<PlateElementData> allPlatesList = elementsPanelModel.GetListOfAssignedPlateElementsFromInspector();
		elementsPanelView.ShowPlateElementsByListOnUI(prefabOfPlate, allPlatesList);
	}

	private void ShowNameListAndAmountOfPlatesOnUI()
	{
		string nameOfList = elementsPanelModel.GetNameOfList();
		int amountOfPlatesInList = elementsPanelModel.GetAmountOfPlatesInList();
		elementsPanelView.ShowNameListAndAmountOfPlatesOnUI(nameOfList, amountOfPlatesInList);
	}

	public void ShowPlateElementsOnUI(List<PlateElementData> platesListData)
	{
		elementsPanelView.ShowPlateElementsByListOnUI(prefabOfPlate, platesListData);
	}
}