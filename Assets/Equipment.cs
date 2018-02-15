using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Equipment")]
public class Equipment : Item {
	#region Variables
	public EquipmentSlot equipSlot;     // What slot to equip it in
	public int armorModifier;
	public int damageModifier;
	public SkinnedMeshRenderer prefab;
	#endregion

	#region Methods
	public override void Use()
	{
		EquipmentManager.instance.Equip(this);  // Equip
		RemoveFromInventory();  // Remove from inventory
	}
	#endregion
}
public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet }