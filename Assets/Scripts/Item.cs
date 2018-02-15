using UnityEngine;

public class Item : ScriptableObject
{
	#region Variables
	new public string name = "New Item";    // Name of the item
	public Sprite icon = null;              // Item icon
	public bool showInInventory = true;
	#endregion

	#region Methods
	public virtual void Use()
	{
		// Use the item
		// Something may happen
	}

	// Call this method to remove the item from inventory
	public void RemoveFromInventory()
	{
		Inventory.instance.Remove(this);
	}

	#endregion
}