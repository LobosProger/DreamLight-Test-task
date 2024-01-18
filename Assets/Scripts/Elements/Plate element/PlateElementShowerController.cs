using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlateElementShowerController : MonoBehaviour
{
	[SerializeField] private TMP_Text plateName;
	[SerializeField] private TMP_Text plateNumber;

    private PlateElementShowerModel plateElementModel;

	private void Start()
	{
		plateElementModel = GetComponent<PlateElementShowerModel>();

		PlateElement plateElementData = plateElementModel.GetPlateElementData();
		ShowPlateOnUI(plateElementData);
	}

	private void ShowPlateOnUI(PlateElement plateElementData)
	{
		plateName.text = plateElementData.nameOfPlate;
		plateNumber.text = plateElementData.numberOfPlate.ToString();
	}
}
