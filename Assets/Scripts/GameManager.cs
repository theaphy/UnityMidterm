using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	#region Singleton
	public static GameManager instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType<GameManager>();
			}
			return _instance;
		}
	}
	static GameManager _instance;

	void Awake()
	{
		_instance = this;
	}

	#endregion

	#region Variables
	public int goldCount = 0;
	public Text goldText;
	#endregion

	#region Methods
	void Start() {
		if (!PlayerPrefs.HasKey ("PlayerGold") || PlayerPrefs.GetInt ("PlayerGold") == 0) 
		{
			goldCount = 0;

		} else {
			goldCount = PlayerPrefs.GetInt ("PlayerGold");
			Debug.Log (goldCount);
		}


		goldText.text = "" + goldCount;
	}
	
	void Update () {
		
	}
	public void AddGold(int goldAmount) {
		goldCount += goldAmount;
		goldText.text = "" + goldCount;

		PlayerPrefs.SetInt ("PlayerGold", goldCount);

	}
	
	#endregion
}
