using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/HealingPotion")]
public class HealthPotion : Item {
	#region Variables
	public int healAmount = 25;
	CharacterStats characterStats;
	GameObject player;
	#endregion

	#region Methods
	//public void Start {
		//characterStats = gameObject.GetComponent<CharacterStats>();
	//}

	public override void Use()
	{
		Debug.Log("Should Heal");
		characterStats.Heal(healAmount);
		RemoveFromInventory();
	}
		#endregion
}
