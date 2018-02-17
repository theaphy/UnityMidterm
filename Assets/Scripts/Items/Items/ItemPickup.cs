using UnityEngine;

public class ItemPickup : Interactable
{
	#region Variables
	public Item item;
	#endregion

	#region Methods
	public override void Interact()
	{
		base.Interact();

		PickUp();
	}
	void PickUp()
	{
		Debug.Log("Picking up " + item.name);
		Inventory.instance.Add(item);   

		Destroy(gameObject);
	}

	#endregion
}