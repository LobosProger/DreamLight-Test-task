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

	private IEnumerator CreatingEachElementByListOnUI(PlateElementShowerModel prefabPlate, List<PlateElementData> plateElements)
	{
		ClearPanelOfPlateElements();
		foreach (PlateElementData eachElementData in plateElements)
		{
			PlateElementShowerModel instantiatedPlateOnUI = Instantiate(prefabPlate, panelOfPlates.transform);
			instantiatedPlateOnUI.SetPlateElementData(eachElementData);
		}

		/*
		// Switch layout to turn on state to automatically refresh plate elements to assign to them position
		SwitchClampingPlatesByLayout(true);
		yield return new WaitForEndOfFrame();
		// Switch layout to turn off state to able move any plate element to another list
		SwitchClampingPlatesByLayout(false);

		yield return new WaitForEndOfFrame();
		SwitchClampingPlatesByLayout(false);
		*/
		yield return null;
	}

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

	public void SwitchClampingPlatesByLayout(bool clamping)
	{
		panelOfPlates.enabled = clamping;
	}

	public void ShowPlateElementsByListOnUI(PlateElementShowerModel prefabPlate, List<PlateElementData> plateElements)
	{
		StartCoroutine(CreatingEachElementByListOnUI(prefabPlate, plateElements));
	}
}