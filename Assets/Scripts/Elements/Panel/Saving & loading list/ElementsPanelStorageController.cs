using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementsPanelStorageController : MonoBehaviour
{
    [SerializeField] private Button saveList;
    [SerializeField] private Button loadList;

	private ElementsPanelStorageModel elementsPanelStorageModel;

	private void Start()
	{
		elementsPanelStorageModel = GetComponent<ElementsPanelStorageModel>();

		saveList.onClick.AddListener(SaveCreatedList);
		loadList.onClick.AddListener(LoadCreatedList);
	}

	private void SaveCreatedList()
	{

	}

	private void LoadCreatedList()
	{

	}
}
