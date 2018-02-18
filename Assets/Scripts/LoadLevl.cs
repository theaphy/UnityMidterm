using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevl : MonoBehaviour {
	private string sceneName;

	// Use this for initialization
	void Start () {
		Scene scene = SceneManager.GetActiveScene();
		sceneName = scene.name;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "Player") {
			
			GameManager.instance.LoadNextLevel (sceneName);

		}
	}
}
