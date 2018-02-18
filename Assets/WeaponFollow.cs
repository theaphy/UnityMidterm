using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollow : MonoBehaviour {
	#region Variables
	private Vector3 mousePos;
	private Vector3 initialPos;

	Vector3 mouse_pos;
	Transform target; //Assign to the object you want to rotate
	Vector3 object_pos;
	float angle;

	public float rotateSpeed = 50f;
	#endregion

	#region Methods
	private void Start()
	{
		
	}
	private void Update()
	{
		initialPos = transform.parent.transform.position;
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 allowedPos = mousePos - initialPos;
		allowedPos = Vector2.ClampMagnitude(allowedPos, 2f);
		transform.position = initialPos + allowedPos;
	}
	private void LateUpdate()
	{
		mouse_pos = Input.mousePosition;
		mouse_pos.z = 5.23f;
		object_pos = Camera.main.WorldToScreenPoint(transform.position);
		mouse_pos.x = mouse_pos.x - object_pos.x + 10f;
		mouse_pos.y = mouse_pos.y - object_pos.y + 10f;
		angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
	}

	#endregion
}