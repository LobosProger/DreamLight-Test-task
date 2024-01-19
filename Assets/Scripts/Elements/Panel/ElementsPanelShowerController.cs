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
	[SerializeField] private TMP_Text nameOfList;
	[SerializeField] private TMP_Text amountOfPlatesInList;

	private ElementsPanelShowerModel elementsPanelModel;
	
	private IEnumerator Start()
	{
		elementsPanelModel = GetComponent<ElementsPanelShowerModel>();
		ShowPlateElementsOnUI();

		yield return new WaitForEndOfFrame();
		SwitchClampingPlatesByLayout(false);
		ShowAmountOfPlatesAndNameListOnUI();
		PlateElementEvents.OnChangedPlaceOfPlateElement += ShowAmountOfPlatesAndNameListOnUI;
	}

	private void OnDestroy()
	{
		PlateElementEvents.OnChangedPlaceOfPlateElement -= ShowAmountOfPlatesAndNameListOnUI;
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

	private void ShowAmountOfPlatesAndNameListOnUI()
	{
		nameOfList.text = elementsPanelModel.GetNameOfList();
		amountOfPlatesInList.text = elementsPanelModel.GetAmountOfPlatesInList().ToString();
	}

	private void SwitchClampingPlatesByLayout(bool clamping)
	{
		panelOfPlates.enabled = clamping;
	}
}
