using PlateElementNamespace;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ElementsPanelStorageController : MonoBehaviour
{
	[SerializeField] private VerticalLayoutGroup panelOfPlates;
	[SerializeField] private Button saveList;
    [SerializeField] private Button loadList;

	private ElementsPanelShowerController elementsPanelShowerController;
	private ElementsPanelStorageModel elementsPanelStorageModel;

	private void Start()
	{
		elementsPanelShowerController = GetComponent<ElementsPanelShowerController>();
		elementsPanelStorageModel = GetComponent<ElementsPanelStorageModel>();

		saveList.onClick.AddListener(SaveCreatedList);
		loadList.onClick.AddListener(LoadCreatedList);
	}

	private void SaveCreatedList()
	{
		List<PlateElementData> plateElementsData = new List<PlateElementData>();
		List<PlateElementShowerModel> plateElementsModelList = panelOfPlates.GetComponentsInChildren<PlateElementShowerModel>().ToList();

		foreach (PlateElementShowerModel eachModel in plateElementsModelList)
		{
			plateElementsData.Add(eachModel.GetPlateElementData());
		}

		elementsPanelStorageModel.SaveCreatedListIntoMemory(plateElementsData);
	}

	private void LoadCreatedList()
	{
		List<PlateElementData> savedList = elementsPanelStorageModel.GetSavedListFromMemory();
		elementsPanelShowerController.ShowPlateElementsOnUI(savedList);
		StartCoroutine(WaitRefreshingElementsAndInvokeEvent());
	}

	// Wait after clearing panel with plate elements, because there is a problem with counting plates
	// during process clearing of panel
	private IEnumerator WaitRefreshingElementsAndInvokeEvent()
	{
		yield return new WaitForEndOfFrame();
		PanelElementsEvents.OnLoadedListFromMemory?.Invoke();
	}
}
