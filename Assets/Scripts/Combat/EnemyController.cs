using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterCombat))]
public class EnemyController : MonoBehaviour {
	#region Variables
	public float lookRadius = 10f;

	Transform target;
	CharacterCombat combatManager;
	public GameObject[] wayPoints;
	Vector3 nextPosition;
	public bool doneMoving;
	public float moveSpeed = 5f;
	#endregion

	#region Methods
	void Start()
	{
		nextPosition = transform.position;
		target = Player.instance.transform;
		combatManager = GetComponent<CharacterCombat>();
	}

	private void FixedUpdate()
	{
		MoveBetweenWaypoints();
	}

	void Update()
	{

		if (transform.position != nextPosition)
		{
			//Debug.Log("doneMoving is false");
			doneMoving = false;
		}
		else if (transform.position == nextPosition)
		{
			doneMoving = true;
		}
		// Get the distance to the player
		float distance = Vector3.Distance(target.position, transform.position);

		// If inside the radius
		if (distance <= lookRadius)
		{

			// Move towards the player
				combatManager.Attack(Player.instance.playerStats);
			}
		}

	void MoveBetweenWaypoints() {
		//Debug.Log("MoveBetweenWaypointsStarted");
		for (int i = 0 ; i < wayPoints.Length; i++) {

			if (doneMoving == true)
			{
				nextPosition = wayPoints[i].transform.position;
				//Debug.Log("should be moving");
				
			
			}
		}
		transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);


	}

	#endregion
}