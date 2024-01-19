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
	
	private IEnumerator Start()
	{
		InitializeNeededComponents();
		ShowPlateElementsOnUI();

		yield return new WaitForEndOfFrame();
		ShowNameListAndAmountOfPlatesOnUI();
	}

	private void InitializeNeededComponents()
	{
		elementsPanelModel = GetComponent<ElementsPanelShowerModel>();
		elementsPanelView = GetComponent<ElementsPanelShowerView>();
	}

	private void ShowPlateElementsOnUI()
	{
		List<PlateElementData> allPlatesList = elementsPanelModel.GetListOfPlateElements();

		foreach (PlateElementData eachElementData in allPlatesList)
		{
			PlateElementShowerModel instantiatedPlateOnUI = Instantiate(prefabOfPlate, panelOfPlates.transform);
			instantiatedPlateOnUI.SetPlateElementData(eachElementData);
		}
	}

	private void ShowNameListAndAmountOfPlatesOnUI()
	{
		string nameOfList = elementsPanelModel.GetNameOfList();
		int amountOfPlatesInList = elementsPanelModel.GetAmountOfPlatesInList();

		elementsPanelView.SwitchClampingPlatesByLayout(false);
		elementsPanelView.ShowNameListAndAmountOfPlatesOnUI(nameOfList, amountOfPlatesInList);
	}
}