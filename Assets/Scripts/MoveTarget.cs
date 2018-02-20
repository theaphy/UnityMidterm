using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour {
#region Variables
	[SerializeField]
    Transform[] wayPoints;
    int currentWayPoint = 0;
    Rigidbody2D rb;
    [SerializeField]
    float moveSpeed = 5;
	#endregion
#region Methods
	void Start () {
        rb = GetComponent<Rigidbody2D>();	
	}
	

	void Update () {
        Movement();
	}
    void Movement() {
        if (Vector2.Distance(transform.position, wayPoints[currentWayPoint].position) < .25f) {
            currentWayPoint += 1;
            currentWayPoint = currentWayPoint % wayPoints.Length;
        }
        Vector3 _dir = (wayPoints[currentWayPoint].position - transform.position).normalized;
        rb.MovePosition(transform.position + _dir * moveSpeed * Time.deltaTime);
    }
#endregion
}
