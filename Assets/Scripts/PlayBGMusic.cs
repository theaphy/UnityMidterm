using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayBGMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Audio Stuff
		AudioSource bgMusic = GetComponent<AudioSource>();
		bgMusic.Play ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
