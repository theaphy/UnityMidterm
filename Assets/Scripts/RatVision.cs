using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatVision : MonoBehaviour {

	public RatMovement ratEnemy;


	void OnTriggerEnter2D(Collider2D o)
	{

		if (o.gameObject.tag == "Player")
		{
			ratEnemy.inConeView = true;
		}
	}

	void OnTriggerExit2D(Collider2D o)
	{


		if (o.gameObject.tag == "Player")
		{
			ratEnemy.inConeView = false;
		}
	}
}