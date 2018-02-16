using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {
	#region Singleton


	public static HealthManager instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType<HealthManager>();
			}
			return _instance;
		}
	}
	static HealthManager _instance;

	void Awake()
	{
		_instance = this;
	}

	#endregion

	#region Variables
	CharacterStats characterStats;
	#endregion

	#region Methods
	public void Start()
	{
		characterStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
	}


void Update () {
		
	}
	public void Heal(int HealAmount) {
		characterStats.Heal(HealAmount);
	}
	
	#endregion
}
