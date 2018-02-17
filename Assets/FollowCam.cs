using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

	public Transform player;


	void LateUpdate () {
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
	}
}
