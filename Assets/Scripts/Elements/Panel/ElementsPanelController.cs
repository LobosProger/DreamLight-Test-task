using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsPanelController : MonoBehaviour
{
    [SerializeField] private PlateElementModel prefabOfPlate;
    [SerializeField] private Transform panelOfPlates;

	private ElementsPanelModel elementsPanelModel;

	private void Start()
	{
		elementsPanelModel = GetComponent<ElementsPanelModel>();
		List<PlateElement> allPlatesList = elementsPanelModel.GetListOfPlateElements();

		foreach(PlateElement eachElementData in allPlatesList)
		{
			PlateElementModel instantiatedPlateOnUI = Instantiate(prefabOfPlate, panelOfPlates);
			instantiatedPlateOnUI.SetPlateElementData(eachElementData);
		}
	}
}
