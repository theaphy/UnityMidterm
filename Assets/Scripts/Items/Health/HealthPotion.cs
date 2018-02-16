using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/HealingPotion")]
public class HealthPotion : Item {
	#region Variables
	public int healAmount = 25;
	CharacterStats characterStats;
	GameObject player;
	#endregion

	#region Methods
	public override void Use()
	{
		HealthManager.instance.Heal(healAmount);
		RemoveFromInventory();
	}
		#endregion
}
