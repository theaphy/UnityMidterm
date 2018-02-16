using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterCombat))]
public class EnemyController : MonoBehaviour {
	#region Variables
	public float lookRadius = 10f;

	Transform target;
	CharacterCombat combatManager;
	#endregion

	#region Methods
	void Start()
	{
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
			// Move towards the player
				combatManager.Attack(Player.instance.playerStats);
			}
		}

	#endregion
}