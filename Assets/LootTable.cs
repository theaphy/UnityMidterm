using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LootTable", menuName = "LootTable")]
public class LootTable : ScriptableObject
{
	#region Variables
	new public string name = "New LootTable";
	GameObject[] droppableItems;
	#endregion

	#region Methods
	public void DropItem() {

	}
	#endregion
}
