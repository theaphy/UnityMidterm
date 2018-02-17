using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour {

	public static PlayerAnimationManager instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType<PlayerAnimationManager>();
			}
			return _instance;
		}
	}
	static PlayerAnimationManager _instance;

	void Awake()
	{
		_instance = this;
	}
	#region Variables

	#endregion

	#region Methods
	void Start () {
		
	}
	
	void Update () {
		
	}
	
	#endregion
}
