using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
	#region Variables
	CharacterStats stats;
	public PlayerStats playerStats;
	#endregion

	#region Methods
	public override void Start()
	{
		stats = GetComponent<CharacterStats>();
		stats.OnHealthReachedZero += Die;
		base.Start();
		EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
	}

	void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
	{
		if (newItem != null)
		{
			armor.AddModifier(newItem.armorModifier);
			damage.AddModifier(newItem.damageModifier);
		}

		if (oldItem != null)
		{
			armor.RemoveModifier(oldItem.armorModifier);
			damage.RemoveModifier(oldItem.armorModifier);
		}

	}
	void Die()
	{
		Debug.Log("Character Died");
		//Destroy(gameObject);
	}
	#endregion
}
