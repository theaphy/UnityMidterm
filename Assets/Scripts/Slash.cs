using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour {
	#region Variables
	Animator anim;
	#endregion
	
	#region Methods
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		StartCoroutine(DestroySelf());
	}

	IEnumerator DestroySelf() {
		yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
		Destroy(gameObject);
	}
	
	#endregion
}
