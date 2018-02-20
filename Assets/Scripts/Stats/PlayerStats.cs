using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : CharacterStats
{
	#region Variables
	CharacterStats stats;
	public PlayerStats playerStats;
	public bool readyToDie = true;

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
	public void SetReadyToDie(int yes) {
		if (yes == 1) {
			readyToDie = true;
		}
		
	}
	void Die()
	{
		if (readyToDie == true) {
			GameManager.instance.DecreaseLivesOnlyOnce();
			GameManager.instance.Death();
			Debug.Log("Character Died");
			readyToDie = false;
		}

		
		//Destroy(gameObject);
	}
	#endregion
}
