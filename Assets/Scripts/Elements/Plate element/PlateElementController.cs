using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlateElementController : MonoBehaviour
{
	[SerializeField] private TMP_Text plateName;
	[SerializeField] private TMP_Text plateNumber;

    private PlateElementModel plateElementModel;

	private void Start()
	{
		plateElementModel = GetComponent<PlateElementModel>();

		PlateElement plateElementData = plateElementModel.GetPlateElementData();
		ShowPlateOnUI(plateElementData);
	}

	private void ShowPlateOnUI(PlateElement plateElementData)
	{
		plateName.text = plateElementData.nameOfPlate;
		plateNumber.text = plateElementData.numberOfPlate.ToString();
	}
}
