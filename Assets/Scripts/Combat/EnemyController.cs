using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterCombat))]
public class EnemyController : MonoBehaviour {
	#region Variables
	public float lookRadius = 10f;

	CharacterStats myStats;
	Transform target;
	CharacterCombat combatManager;
	#endregion

	#region Methods
	void Start()
	{
		myStats = GetComponent<CharacterStats>();
		target = Player.instance.transform;
		combatManager = GetComponent<CharacterCombat>();
	}
	void Update()
	{

		// Get the distance to the player
		float distance = Vector3.Distance(target.position, transform.position);

		// If inside the radius
		if (distance <= lookRadius)
		{
			SendEnemyStats(myStats);
			// Move towards the player
			combatManager.Attack(Player.instance.playerStats);
			}
		}
	public void SendEnemyStats(CharacterStats enemyStats)
	{
		if (gameObject.tag == "Boss") {
			DamageUI.instance.SetEnemyStats(enemyStats);
		}

		if (gameObject.tag == "Minions") {
			DamageUI.instance.SetEnemyStats(enemyStats);
		}
	}

	#endregion
}