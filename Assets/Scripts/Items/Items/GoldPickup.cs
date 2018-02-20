using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : Interactable
{
	#region Variables

	#endregion

	#region Methods
	public override void Interact()
	{
		base.Interact();

		PickUp();
	}
	void PickUp()
	{
		GameManager.instance.AddGold(7);//1 
		Destroy(gameObject);
	}
	#endregion
}
