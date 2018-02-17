using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement : MonoBehaviour {

	public float health;
	public float dmgOutput;

	private Transform playerTransform;

	//FSM variables
	private Animator animator;
	bool chasing = false;
	bool waiting = false;
	private float distanceFromTarget;
	public bool inConeView;

	Vector3 direction;
	private float walkSpeed = 1f;
	private int currentTarget;    
	private Transform[] waypoints = null;

	private void Awake()
	{
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

		// reference to FSM (animator)
		animator = gameObject.GetComponent<Animator>();

		// Add all our waypoints into the waypoints array
		Transform point1 = GameObject.Find("pt1").transform;
		Transform point2 = GameObject.Find("pt2").transform;
		Transform point3 = GameObject.Find("pt3").transform;
		Transform point4 = GameObject.Find("pt4").transform;
		Transform point5 = GameObject.Find("pt5").transform;
		waypoints = new Transform[5] {
			point1,
			point2,
			point3,
			point4,
			point5
		};

		health = 50;

	}

	private void Update()
	{

		if (chasing)
		{
			direction = playerTransform.position - transform.position;
			rotateRat();
		}


		if (!waiting)
		{
			transform.Translate(walkSpeed * direction * Time.deltaTime, Space.World);
		}

		if (health == 0) {
			Death ();
		}

	}

	private void FixedUpdate()
	{
		// Give values to FSM (animator)
		distanceFromTarget = Vector3.Distance(waypoints[currentTarget].position, transform.position);
		animator.SetFloat("distanceFromWaypoint", distanceFromTarget);
		animator.SetBool("playerInSight", inConeView);

	}

	public void SetNextPoint()
	{
		// pick a random waypoint 
		// make sure itsnot the same as the last one
		int nextPoint = -1;

		do
		{
			nextPoint =  Random.Range(0, waypoints.Length - 1);
		}
		while (nextPoint == currentTarget);

		currentTarget = nextPoint;

		// Load direction of next waypoint
		direction = waypoints[currentTarget].position - transform.position;
		rotateRat();
	}

	public void Chase()
	{
		// Load the direction of player
		direction = playerTransform.position - transform.position;
		rotateRat();
	}

	public void StopChasing()
	{
		chasing = false;
	}

	private void rotateRat()
	{
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
		direction = direction.normalized;
	}

	public void StartChasing()
	{
		chasing = true;
	}


	public void ToggleWaiting()
	{
		waiting  = !waiting;
	}

	public void Death ()
	{
		Object.Destroy(gameObject);
	}

}