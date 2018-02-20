using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bossfireball : MonoBehaviour {
	#region Variables
	public float speed = 5f;
	CharacterStats stats;
	Rigidbody2D rb;
	#endregion

	#region Methods
	void Start () {
		stats = GetComponent<CharacterStats>();
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		rb.AddForce(Vector2.down * speed);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			CharacterCombat combatManager = Player.instance.playerCombatManager;
			combatManager.Attack(stats);
			Debug.Log("Player takes" + stats);
			Invoke("DestroySelf", 1f);
		}
		if (collision.gameObject.tag == "Wall") {
			//Debug.Log("should destroy self");
			Destroy(gameObject);
		}
	}
	void DestroySelf() {
		Destroy(gameObject);
	}

	#endregion
}
