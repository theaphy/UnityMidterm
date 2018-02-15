using UnityEngine;

public class CharacterStats : MonoBehaviour {
	#region Variables
	public Stat maxHealth;          // Maximum amount of health
	public int currentHealth { get; protected set; }    // Current amount of health

	public Stat damage;
	public Stat armor;

	#endregion

	#region Methods
	public virtual void Awake()
	{
		currentHealth = maxHealth.GetValue();
	}

	public virtual void Start()
	{

	}


	public void TakeDamage(int damage)
	{
		damage -= armor.GetValue();
		damage = Mathf.Clamp(damage, 0, int.MaxValue);

		currentHealth -= damage;
		Debug.Log(transform.name + " takes " + damage + " damage.");

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	// Heal the character.
	public void Heal(int amount)
	{
		currentHealth += amount;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth.GetValue());
	}
	public virtual void Die() {
		//meant to be overwritten
	}


	#endregion
}
