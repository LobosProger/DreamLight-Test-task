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
		List<PlateElementData> retrievingList = JsonConvert.DeserializeObject<List<PlateElementData>>(jsonOfList);
		
		return retrievingList;
	}

	public void SaveCreatedListIntoMemory(List<PlateElementData> retrievingList)
	{
		string jsonOfList = JsonConvert.SerializeObject(retrievingList);
		PlayerPrefs.SetString(keyOfStoringList, jsonOfList);
	}
}
