using PlateElementNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ElementsPanelStorageModel : MonoBehaviour
{
	[SerializeField] private string keyOfStoringList;

	public List<PlateElementData> GetSavedListFromMemory()
	{
		string jsonOfList = PlayerPrefs.GetString(keyOfStoringList);
		List<PlateElementDataForJSON> retrievingListPlateElementsList = JsonConvert.DeserializeObject<List<PlateElementDataForJSON>>(jsonOfList);

		List<PlateElementData> retrievingList = new List<PlateElementData>();
		foreach(PlateElementDataForJSON eachPreparedElement in retrievingListPlateElementsList)
		{
			PlateElementData plateElementData = new PlateElementData(eachPreparedElement.nameOfPlate, eachPreparedElement.numberOfPlate);
			retrievingList.Add(plateElementData);
		}

		return retrievingList;
	}

	public void SaveCreatedListIntoMemory(List<PlateElementData> retrievingList)
	{
		List<PlateElementDataForJSON> preparingPlateElementsList = new List<PlateElementDataForJSON>();
		foreach(PlateElementData eachPlateElement in retrievingList)
		{
			PlateElementDataForJSON preparingElementForJSON = new PlateElementDataForJSON(eachPlateElement.GetNameOfPlate(), eachPlateElement.GetNumberOfPlate());
			preparingPlateElementsList.Add(preparingElementForJSON);
		}

		string jsonOfList = JsonConvert.SerializeObject(preparingPlateElementsList);
		PlayerPrefs.SetString(keyOfStoringList, jsonOfList);
	}

	// This class was prepared because PlateElementData doesn't allow to convert to JSON during private variables
	// For it was prepared another class, allows to conducting transformations into JSON format
	private class PlateElementDataForJSON
	{
		public PlateElementDataForJSON(string nameOfPlate, int numberOfPlate)
		{
			this.nameOfPlate = nameOfPlate;
			this.numberOfPlate = numberOfPlate;
		}

		public string nameOfPlate;
		public int numberOfPlate;
	}
}
