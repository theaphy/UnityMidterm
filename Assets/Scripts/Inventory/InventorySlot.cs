using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class InventorySlot : MonoBehaviour {
	#region Variables
	public Image icon;
	public Button removeButton;

	Item item;
	#endregion

	#region Methods
	public void AddItem(Item newItem)
	{
		item = newItem;

		icon.sprite = item.icon;
		icon.enabled = true;
		removeButton.interactable = true;
	}
	public void ClearSlot()
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;
		removeButton.interactable = false;
	}

	public void RemoveItemFromInventory()
	{
		Inventory.instance.Remove(item);
	}

	// Use the item
	public void UseItem()
	{
		if (item != null)
		{
			item.Use();
		}
	}
	#endregion
}