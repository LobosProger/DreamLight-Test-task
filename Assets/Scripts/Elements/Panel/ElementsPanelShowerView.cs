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

	public void ShowNameListAndAmountOfPlatesOnUI(string listName, int amountOfElements)
	{
		nameOfList.text = listName;
		amountOfPlatesInList.text = amountOfElements.ToString();
	}

	public void SwitchClampingPlatesByLayout(bool clamping)
	{
		panelOfPlates.enabled = clamping;
	}
}
