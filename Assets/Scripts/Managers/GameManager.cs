using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	public static int lives = 3;
	public GameObject deathScreen;
	public GameObject slainby;
	public GameObject Continue;
	public GameObject yesPanel;
	public GameObject NoPanel;
	public GameObject returnToMenu;
	public GameObject returnToMenuButton;
	public static GameObject player;
	public bool died = false;

	#endregion

	#region Methods
	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");

		goldText.text = "" + goldCount;


	}
	
	public void Respawn () {
		deathScreen.SetActive(false);
		slainby.SetActive(false);
		returnToMenu.SetActive(false);
		returnToMenuButton.SetActive(false);
		Continue.SetActive(false);
		yesPanel.SetActive(false);
		NoPanel.SetActive(false);
		player.SendMessage("Respawn");
	}
	public void AddGold(int goldAmount) {
		goldCount += goldAmount;
		goldText.text = "" + goldCount;

		PlayerPrefs.SetInt ("PlayerGold", goldCount);

	}


	public void LoadNextLevel (string calledFrom) {
		switch (calledFrom)
		{
		case "Level 1":
			SceneManager.LoadScene ("Level 2");
			break;
		case "Level 2":
			SceneManager.LoadScene ("Level 3");
			break;
		case "Level 3":
			SceneManager.LoadScene("Level 4");
			break;
		case "Level 4":
			SceneManager.LoadScene("Boss level");
			break;
		default:
			SceneManager.LoadScene ("Level 1");
			break;
		}
	}
	public void LoadMenu() {
		SceneManager.LoadScene("Menu");
	}
	public void DecreaseLivesOnlyOnce() {
		died = true;
	}
	public void Death() {
		if (died == true) {
			lives--;
			died = false;
		}
		if (lives <= 0)
		{
			deathScreen.SetActive(true);
			slainby.SetActive(true);
			returnToMenu.SetActive(true);
			returnToMenuButton.SetActive(true);
			
		}
		else
		{
			deathScreen.SetActive(true);
			slainby.SetActive(true);
			Continue.SetActive(true);
			yesPanel.SetActive(true);
			NoPanel.SetActive(true);
		}
	}
	#endregion
}
