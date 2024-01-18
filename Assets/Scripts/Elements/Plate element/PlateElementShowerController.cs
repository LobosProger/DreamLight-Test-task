using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlateElementNamespace;
using TMPro;

public class PlateElementShowerController : MonoBehaviour
{
	[SerializeField] private TMP_Text plateName;
	[SerializeField] private TMP_Text plateNumber;

    private PlateElementShowerModel plateElementModel;

	private void Start()
	{
		plateElementModel = GetComponent<PlateElementShowerModel>();

		PlateElementData plateElementData = plateElementModel.GetPlateElementData();
		ShowPlateOnUI(plateElementData);
	}

	private void ShowPlateOnUI(PlateElementData plateElementData)
	{
		plateName.text = plateElementData.GetNameOfPlate();
		plateNumber.text = plateElementData.GetNumberOfPlate().ToString();
	}
}
