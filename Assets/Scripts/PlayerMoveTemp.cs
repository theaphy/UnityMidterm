using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTemp : MonoBehaviour {
	#region Variables
	public float moveSpeed;
	private Vector3 target;
	#endregion
	
	#region Methods

	void Start () {
		target = transform.position;
	}
	
//	void Update () {
//		if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) {
//			transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
//		}
//		if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
//		{
//			transform.Translate(new Vector3(0f,Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
//		}
//	}

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = transform.position.z;
		}
		transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
	}    
	
	#endregion

}

