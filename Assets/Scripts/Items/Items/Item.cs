using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
	#region Variables
	new public string name = "New Item";    
	public Sprite icon = null;              
	public bool showInInventory = true;
	#endregion

	#region Methods
	public virtual void Use()
	{
		// meant to be overwritten
	}

	public void RemoveFromInventory()
	{
		Inventory.instance.Remove(this);
	}

	#endregion
}