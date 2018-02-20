using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
	#region Variables
	CharacterStats stats;
	public GameObject gold;
	#endregion

	#region Methods
	void Start()
	{
		stats = GetComponent<CharacterStats>();
		stats.OnHealthReachedZero += Die;
	}
	public override void Interact()
	{
		
		//print("Interact");
		CharacterCombat combatManager = Player.instance.playerCombatManager;
		combatManager.Attack(stats);
	}
	void Die()
	{
		Vector3 dropPositoin = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1);
		if (gold != null) {
			Object.Instantiate(gold, dropPositoin, Quaternion.identity);
		}
		Destroy(gameObject);
	}



	#endregion
}