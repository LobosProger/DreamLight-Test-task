using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlateElementNamespace;
using UnityEngine.UI;

public class ElementsPanelShowerController : MonoBehaviour
{
    [SerializeField] private PlateElementShowerModel prefabOfPlate;
	[SerializeField] private VerticalLayoutGroup panelOfPlates;

	private ElementsPanelShowerModel elementsPanelModel;
	
	private IEnumerator Start()
	{
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
			PlateElementShowerModel instantiatedPlateOnUI = Instantiate(prefabOfPlate, panelOfPlates.transform);
			instantiatedPlateOnUI.SetPlateElementData(eachElementData);
		}
	}

	private void SwitchClampingPlatesByLayout(bool clamping)
	{
		panelOfPlates.enabled = clamping;
	}
}
