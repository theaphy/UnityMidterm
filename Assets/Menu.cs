using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Menu : MonoBehaviour {
	public Text highScoreText;
	public DatabaseReference reference;
	public int[] globalHighScores;
	public GameObject highScoreTable;
	public Text[] scoreTexts;


	// Use this for initialization
	void Start () {
		GameManager.state = GameManager.GameState.menu;
		PlayerPrefs.SetInt ("Level1", 1);

		if (PlayerPrefs.HasKey("HighScore")) {
			highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
		} else {
			highScoreText.text = "High Score: " + 0;
		}

		globalHighScores = new int[] {0,0,0,0,0};

		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://the-eye-of-gruumsh.firebaseio.com/");
		reference = FirebaseDatabase.DefaultInstance.RootReference;

		FirebaseDatabase.DefaultInstance
			.GetReference("totalGoldScores")
			.ValueChanged += HandleValueChanged;


	}

	void HandleValueChanged(object sender, ValueChangedEventArgs args) {
		Debug.Log ("high scores updated at " + Time.time);
		Debug.Log (args.Snapshot);
		if (args.DatabaseError != null) {
			Debug.LogError(args.DatabaseError.Message);
			return;
		}

		for (int i = 0; i < 5; i++) {
			globalHighScores[i] = int.Parse(args.Snapshot.Child ("score" + i).Value.ToString());
			Debug.Log ( i + globalHighScores [i] + " Gold" );
		}

		if (GameManager.lastScore > globalHighScores [3]) {
			for (int i = 0; i < 4; i++) {
				if (GameManager.lastScore > globalHighScores [i]) {
					//shift scores after down
					for (int j = 3; j > i; j--) {
						globalHighScores [j] = globalHighScores [j - 1];
					}
					//set the calue at position i
					globalHighScores [i] = GameManager.lastScore;

					//reset so we dont push it twice
					GameManager.lastScore=0;
					//push these to firebase
					UpdateValues ();
					return;
				}
			}
		}

	}
	void UpdateValues () {
		for (int i = 0; i < 4; i++) {
			FirebaseDatabase.DefaultInstance
				.GetReference ("totalGoldScores").Child ("score" + i).SetValueAsync (globalHighScores [i]);
		}



	}
	void DisplayScores() {
		highScoreTable.SetActive (true);
		for (int i = 0; i < 4; i++) {
			scoreTexts [i].text = "" + globalHighScores [i];
		}
	}
}