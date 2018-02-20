using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {
	#region Variables
	public float attackRate = 1f;
	private float attackCountdown = 0f;

	public event System.Action OnAttack;

	public Transform healthBarPos;
	public Transform damageIndicatorPos;
	public GameObject slash;
	public bool createdDamageIndicator = false;

	CharacterStats myStats;
	CharacterStats enemyStats;

	#endregion

	#region Methods
	void Start()
	{
		myStats = GetComponent<CharacterStats>();
		HealthUIManager.instance.Create(healthBarPos, myStats);
		if (damageIndicatorPos != null) {
			DamageUIManager.instance.Create(damageIndicatorPos, myStats);
		}
		

	}

	void Update()
	{
		attackCountdown -= Time.deltaTime;
	}

	public void Attack(CharacterStats enemyStats)
	{
		
		if (attackCountdown <= 0f)
		{
			this.enemyStats = enemyStats;
			attackCountdown = 1f / attackRate;

			StartCoroutine(DoDamage(enemyStats, .6f));

			if (OnAttack != null)
			{
				OnAttack();
			}
		}
	}



	IEnumerator DoDamage(CharacterStats stats, float delay)
	{
		//print("Start");
		yield return new WaitForSeconds(delay);

		Debug.Log(transform.name + " swings for " + myStats.damage.GetValue() + " damage");
		enemyStats.TakeDamage(myStats.damage.GetValue());
		Vector3 spawnpoint = new Vector3(enemyStats.gameObject.transform.position.x, enemyStats.gameObject.transform.position.y, enemyStats.gameObject.transform.position.z - 1);
		if (slash != null) {
			GameObject childObject = Instantiate(slash, spawnpoint, Quaternion.identity) as GameObject;
			childObject.transform.localScale = enemyStats.gameObject.transform.localScale;
			childObject.transform.SetParent(enemyStats.gameObject.transform);
		}





	}
	#endregion
}
