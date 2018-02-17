using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveTemp : MonoBehaviour
{
	#region Variables
	public float moveSpeed;
	private Vector3 target;

	private float playerX;
	private float playerY;

	private float cameraX;
	private float cameraY;
	#endregion

	#region Methods

	void Start()
	{
		target = transform.position;

		playerX = Mathf.Round(transform.position.x/(1));
		playerY = Mathf.Round(transform.position.y/(1));

		Debug.Log (playerX);
		Debug.Log (playerY);
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

	void Update()
	{
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}

		if (Input.GetMouseButtonDown(0))
		{
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = transform.position.z;
			playerX = Mathf.Round(transform.position.x/(1));
			cameraX = Mathf.Round(Input.mousePosition.x/(1));

			Debug.Log (cameraX);
			Debug.Log (transform.position.x);


		}
		transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
	}
	#endregion
}