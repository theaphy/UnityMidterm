using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTemp : MonoBehaviour {
	#region Variables
	public float moveSpeed;
	#endregion
	
	#region Methods
	
	void Update () {
		if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) {
			transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
		}
		if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
		{
			transform.Translate(new Vector3(0f,Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
		}
	}
	
	#endregion
}
