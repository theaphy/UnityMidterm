using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : Interactable {


	bool isOpen;
	public Item[] items;

	public override void Interact ()
	{
		base.Interact ();
		if (!isOpen) {
			StartCoroutine (CollectTreasure ());
		}
	}

	IEnumerator CollectTreasure() {

		isOpen = true;

		yield return new WaitForSeconds (1f);
		print ("Chest opened");
		foreach (Item i in items) {
			Inventory.instance.Add (i);
		}
	}
}
