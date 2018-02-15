using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryUI : MonoBehaviour {
	#region Variables
	public GameObject inventoryUI;  // The entire UI
	public Transform itemsParent;   // The parent object of all the items
	public GameObject inventoryScreen;
	public GameObject inventoryButton;

	Inventory inventory;    // Our current inventory

	#endregion

	#region Methods
	void Start()
	{
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateUI;
	}
	void Update()
	{
		if (inventoryScreen.active == true)
		{
			
			UpdateUI();
		}
	}
	public void UpdateUI()
	{

		InventorySlot[] slots = GetComponentsInChildren<InventorySlot>();

		for (int i = 0; i < slots.Length; i++)
		{
			if (i < inventory.items.Count)
			{
				slots[i].AddItem(inventory.items[i]);
			}
			else
			{
				slots[i].ClearSlot();
			}
		}
	}

	public void OpenInventory() {
		inventoryButton.SetActive(false);
		inventoryScreen.SetActive(true);
	}
	public void CloseInventory() {
		inventoryButton.SetActive(true);
		inventoryScreen.SetActive(false);
	}

	#endregion
}