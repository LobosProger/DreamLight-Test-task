using PlateElementNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ElementsPanelStorageModel : MonoBehaviour
{
	// Initially, there is was created logic, that assigns key for storage via Unity inspector (by writing preferred name of key)
	// But, I have changed below logic by assigning key via adding name and hash.
	// It provides ability to automatically save everything and resolves problem if for example,
	// programmer or game designer forgot about assigning key to list for storage

	private string keyOfStoringList => gameObject.name + gameObject.GetHashCode().ToString();

	private List<PlateElementDataForJSON> GetSpecialPreparedListOfPlatesFromMemory()
	{
		string jsonOfList = PlayerPrefs.GetString(keyOfStoringList);
		List<PlateElementDataForJSON> retrievingListPlateElementsList = JsonConvert.DeserializeObject<List<PlateElementDataForJSON>>(jsonOfList);

		return retrievingListPlateElementsList;
	}

	private List<PlateElementData> GetListWithPlatesFromSpecialPreparedListForJSON(List<PlateElementDataForJSON> specialPreparedList)
	{
		List<PlateElementData> retrievingList = new List<PlateElementData>();
		foreach (PlateElementDataForJSON eachPreparedElement in specialPreparedList)
		{
			PlateElementData plateElementData = new PlateElementData(eachPreparedElement.nameOfPlate, eachPreparedElement.numberOfPlate);
			retrievingList.Add(plateElementData);
		}

		return retrievingList;
	}

	private List<PlateElementDataForJSON> PrepareListOfPlatesToListForJSON(List<PlateElementData> plateElementsList)
	{
		List<PlateElementDataForJSON> preparingPlateElementsList = new List<PlateElementDataForJSON>();
		foreach (PlateElementData eachPlateElement in plateElementsList)
		{
			PlateElementDataForJSON preparingElementForJSON = new PlateElementDataForJSON(eachPlateElement.GetNameOfPlate(), eachPlateElement.GetNumberOfPlate());
			preparingPlateElementsList.Add(preparingElementForJSON);
		}

		return preparingPlateElementsList;
	}

	private void SavePreparedSpecialListIntoMemory(List<PlateElementDataForJSON> preparingPlateElementsList)
	{
		string jsonOfList = JsonConvert.SerializeObject(preparingPlateElementsList);
		PlayerPrefs.SetString(keyOfStoringList, jsonOfList);
	}

	public List<PlateElementData> GetSavedListFromMemory()
	{
		List<PlateElementDataForJSON> retrievingSpecialPreparedListPlateElementsList = GetSpecialPreparedListOfPlatesFromMemory();
		List<PlateElementData> retrievingListWithPlates = GetListWithPlatesFromSpecialPreparedListForJSON(retrievingSpecialPreparedListPlateElementsList);

		return retrievingListWithPlates;
	}

	public void SaveCreatedListIntoMemory(List<PlateElementData> retrievingList)
	{
		List<PlateElementDataForJSON> preparingPlateElementsList = PrepareListOfPlatesToListForJSON(retrievingList);
		SavePreparedSpecialListIntoMemory(preparingPlateElementsList);
	}



	// This class was prepared because PlateElementData doesn't allow to convert to JSON during private variables
	// For it was prepared another class, allows to conducting transformations into JSON format with public variables
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
