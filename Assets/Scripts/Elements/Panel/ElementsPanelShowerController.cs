using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsPanelShowerController : MonoBehaviour
{
    [SerializeField] private PlateElementShowerModel prefabOfPlate;
    [SerializeField] private Transform panelOfPlates;

	private ElementsPanelShowerModel elementsPanelModel;

	private void Start()
	{
		elementsPanelModel = GetComponent<ElementsPanelShowerModel>();
		List<PlateElement> allPlatesList = elementsPanelModel.GetListOfPlateElements();

		foreach(PlateElement eachElementData in allPlatesList)
		{
			PlateElementShowerModel instantiatedPlateOnUI = Instantiate(prefabOfPlate, panelOfPlates);
			instantiatedPlateOnUI.SetPlateElementData(eachElementData);
		}
	}
}
