using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	#region Singleton

	public static Inventory instance;

	void Awake()
	{
		instance = this;
	}

	#endregion

	#region Variables
	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public int space = 10;  


	public List<Item> items = new List<Item>();
	#endregion

	#region Methods
	public void Add(Item item)
	{
		if (item.showInInventory)
		{
			if (items.Count >= space)
			{
				Debug.Log("Not enough room.");
				return;
			}

			items.Add(item);

			if (onItemChangedCallback != null)
				onItemChangedCallback.Invoke();
		}
	}

	public void Remove(Item item)
	{
		items.Remove(item);

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}
	#endregion
}