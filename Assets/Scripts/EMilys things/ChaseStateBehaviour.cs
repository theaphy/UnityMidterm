using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseStateBehaviour : StateMachineBehaviour {
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		RatMovement ratEnemy = animator.gameObject.GetComponent<RatMovement>();
		ratEnemy.StartChasing();
	}
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		RatMovement ratEnemy = animator.gameObject.GetComponent<RatMovement>();
		ratEnemy.StopChasing();
	}

}
