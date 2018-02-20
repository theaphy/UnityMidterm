using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Equipment")]
public class Equipment : Item {
	#region Variables
	public EquipmentSlot equipSlot;
	public int armorModifier;
	public int damageModifier;
	#endregion

	#region Methods
	public override void Use()
	{
		EquipmentManager.instance.Equip(this);
		RemoveFromInventory();
	}
	#endregion
}
public enum EquipmentSlot { Head, Chest, Legs, Weapon }