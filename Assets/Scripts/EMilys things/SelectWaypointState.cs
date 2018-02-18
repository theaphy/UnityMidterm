using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWaypointState : StateMachineBehaviour {

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		RatMovement ratEnemy = animator.gameObject.GetComponent<RatMovement> ();
		ratEnemy.SetNextPoint ();
	}
}
