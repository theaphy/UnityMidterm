using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUIManager : MonoBehaviour {
	#region Variables
	public DamageUI damageUIPrefab;
	public static DamageUIManager instance;
	#endregion

	#region Methods
	void Awake()
	{
		instance = this;
	}

	public void Create(Transform target, CharacterStats stats)
	{
		DamageUI newUI = Instantiate(damageUIPrefab, transform) as DamageUI;
		newUI.Init(target, stats);
	}
	#endregion
}
