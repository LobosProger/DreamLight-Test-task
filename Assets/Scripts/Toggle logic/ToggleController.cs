using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
	[SerializeField] private Image arrowUp;
	[SerializeField] private Image arrowDown;

	private ToggleModel toggleModel;

	private void Start()
	{
		toggleModel = GetComponent<ToggleModel>();

		Toggle toggleComponent = GetComponent<Toggle>();
		toggleComponent.onValueChanged.AddListener(OnToggleClicked);
		toggleComponent.isOn = toggleModel.IsSelectedDescendingOrder();

		SwitchStateOfArrowOnUI();
	}

	private void SwitchStateOfArrowOnUI()
	{
		bool isSelectedDescendingOrder = toggleModel.IsSelectedDescendingOrder();
        if (isSelectedDescendingOrder)
        {
			arrowUp.enabled = true;
			arrowDown.enabled = false;
		} else
		{
			arrowUp.enabled = false;
			arrowDown.enabled = true;
		}
    }

	private void OnToggleClicked(bool stateOfToggle)
	{
		toggleModel.SwitchStateOfDescendingOrder(stateOfToggle);
		SwitchStateOfArrowOnUI();
	}
}
