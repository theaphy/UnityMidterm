﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	#region Singleton

	public static Player instance;

	void Awake()
	{
		instance = this;
	}

	#endregion

	public CharacterCombat playerCombatManager;
	public PlayerStats playerStats;

}