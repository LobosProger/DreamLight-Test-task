using PlateElementNamespace;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ElementsPanelShowerView : MonoBehaviour
{
	[SerializeField] private VerticalLayoutGroup panelOfPlates;
	[SerializeField] private TMP_Text nameOfList;
	[SerializeField] private TMP_Text amountOfPlatesInList;

	private void ClearPanelOfPlateElements()
	{
		foreach (Transform eachPlateElement in panelOfPlates.transform)
		{
			Destroy(eachPlateElement.gameObject);
		}
	}

	public void ShowNameListAndAmountOfPlatesOnUI(string listName, int amountOfElements)
	{
		nameOfList.text = listName;
		amountOfPlatesInList.text = amountOfElements.ToString();
	}

	public void ShowPlateElementsByListOnUI(PlateElementShowerModel prefabPlate, List<PlateElementData> plateElements)
	{
		ClearPanelOfPlateElements();
		foreach (PlateElementData eachElementData in plateElements)
		{
			PlateElementShowerModel instantiatedPlateOnUI = Instantiate(prefabPlate, panelOfPlates.transform);
			instantiatedPlateOnUI.SetPlateElementData(eachElementData);
		}
	}
}