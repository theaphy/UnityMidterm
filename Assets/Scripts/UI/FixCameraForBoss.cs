using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixCameraForBoss : MonoBehaviour {
	#region Variables
	Camera mainCamera;
	public float newZoomLevel = -7f;
	#endregion
	
	#region Methods
	void Update () {
		//if (Input.GetKey(KeyCode.KeypadPlus))
		//{
		//	CameraFollow.instance.ChangeOffset(newZoomLevel);
		//}
		//if (Input.GetKey(KeyCode.KeypadMinus)) {
		//	CameraFollow.instance.ChangeOffset(-newZoomLevel);
		//}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			CameraFollow.instance.GetNewOffset(newZoomLevel);
			Destroy(gameObject);
		}
	}

	#endregion
}
