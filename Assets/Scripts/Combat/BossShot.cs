using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BossShot : MonoBehaviour {

	#region Variables
	public Transform target;
	public float speed = 5f;

	private Rigidbody2D rb;
#endregion

#region Methods
	void Start () 
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
		rb = GetComponent<Rigidbody2D>();
	}
	

	void FixedUpdate () 
	{
		Vector2 direction = (Vector2)target.position - rb.position;
		direction.Normalize();
		Vector3 lookAtTarget = new Vector3(target.position.x, target.position.y, 0);
		transform.LookAt(lookAtTarget);
		rb.velocity = transform.forward * speed;
		transform.rotation = Quaternion.Euler(0f, 0f, 0f);
	}
	#endregion
}
