using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{

	#region Variables
	public float health = 50f;
	#endregion

	#region Methods
	public void TakeDamage(float amount)
	{
		health -= amount;
		if (health <= 0)
		{
			Die();
		}
	}
	void Die()
	{
		Destroy(gameObject);
	}
	#endregion
}