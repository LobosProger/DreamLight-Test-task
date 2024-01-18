using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlateElementNamespace;

public class ElementsPanelShowerController : MonoBehaviour
{
    [SerializeField] private PlateElementShowerModel prefabOfPlate;
    [SerializeField] private Transform panelOfPlates;

	private ElementsPanelShowerModel elementsPanelModel;

	private void Start()
	{
		elementsPanelModel = GetComponent<ElementsPanelShowerModel>();
		List<PlateElementData> allPlatesList = elementsPanelModel.GetListOfPlateElements();

		foreach(PlateElementData eachElementData in allPlatesList)
		{
			PlateElementShowerModel instantiatedPlateOnUI = Instantiate(prefabOfPlate, panelOfPlates);
			instantiatedPlateOnUI.SetPlateElementData(eachElementData);
		}
	}
}
