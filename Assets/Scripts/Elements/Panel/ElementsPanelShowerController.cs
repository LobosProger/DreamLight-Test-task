using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlateElementNamespace;
using UnityEngine.UI;

public class ElementsPanelShowerController : MonoBehaviour
{
    [SerializeField] private PlateElementShowerModel prefabOfPlate;
    [SerializeField] private Transform panelOfPlates;

	private ElementsPanelShowerModel elementsPanelModel;
	private VerticalLayoutGroup verticalLayoutForPlates;

	private IEnumerator Start()
	{
		verticalLayoutForPlates = GetComponent<VerticalLayoutGroup>();
		elementsPanelModel = GetComponent<ElementsPanelShowerModel>();
		ShowPlateElementsOnUI();

		yield return new WaitForEndOfFrame();
		SwitchClampingPlatesByLayout(false);
	}

	private void ShowPlateElementsOnUI()
	{
		List<PlateElementData> allPlatesList = elementsPanelModel.GetListOfPlateElements();

		foreach (PlateElementData eachElementData in allPlatesList)
		{
			PlateElementShowerModel instantiatedPlateOnUI = Instantiate(prefabOfPlate, panelOfPlates);
			instantiatedPlateOnUI.SetPlateElementData(eachElementData);
		}
	}

	private void SwitchClampingPlatesByLayout(bool clamping)
	{
		verticalLayoutForPlates.enabled = clamping;
	}
}
