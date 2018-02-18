using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	#region Variables
	Transform target;
	public int offset = -10;
	#endregion
	
	#region Methods
	void Start () {

	}
	
	void LateUpdate () {
	target = GameObject.FindGameObjectWithTag("Player").transform;
		transform.position = new Vector3(target.position.x, target.position.y, offset);
	}
	
	#endregion
}
