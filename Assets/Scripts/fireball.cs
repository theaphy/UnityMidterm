using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {

	#region Variables
	public GameObject projectile;
	public GameObject shotPoint;
	public GameObject crouchShotPoint;
	public GameObject player;
	public float shotForce = 8.0f;
	public float shotTTL = 5.0f;
	public float rechargeTime = 2.2f;
	public AudioClip launchNoise;
	public bool crouching;

	private float lastShotTime;
	private SpriteRenderer sR;
	private Animator anim;
	private int moveHash;
	private int idleHash;
	private int flyHash;
	private int crouchHash;
	#endregion

	#region Methods
	void Start()
	{
		anim = GetComponent<Animator>();
		moveHash = Animator.StringToHash("Moving");
		flyHash = Animator.StringToHash("flying");
		idleHash = Animator.StringToHash("idle");
		crouchHash = Animator.StringToHash("crouch");
	}
	void Update () 
	{
		if (Input.GetAxis("Fire1") > 0 && Time.time > lastShotTime + rechargeTime)
		{
			Shoot();
		}
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			shotPoint.SetActive(false);
			crouchShotPoint.SetActive(true);
			anim.SetBool(crouchHash, true);
			anim.SetBool(flyHash, false);
			anim.SetBool(moveHash, false);
			anim.SetBool(idleHash, false);
			crouching = true;
		}
		else {
			anim.SetBool(crouchHash, false);
			shotPoint.SetActive(true);
			crouchShotPoint.SetActive(false);
			crouching = false;
		}

	}
	void Shoot()
	{
		if (crouching == true)
		{
			lastShotTime = Time.time;

			if (launchNoise != null)
			{
				AudioSource.PlayClipAtPoint(launchNoise, crouchShotPoint.transform.position, 3f);
			}
			GameObject newshot = Object.Instantiate(projectile, crouchShotPoint.transform.position, crouchShotPoint.transform.rotation);
			sR = newshot.GetComponent<SpriteRenderer>();
			newshot.GetComponent<Rigidbody2D>().AddForce(shotForce * transform.localScale.x * Vector2.right, ForceMode2D.Force);
			if (transform.localScale.x == -1)
			{
				sR.flipX = true;
			}
			else if (transform.localScale.x == 1)
			{
				sR.flipX = false;
			}



			Object.Destroy(newshot, shotTTL);
		}
		else {
			lastShotTime = Time.time;

			if (launchNoise != null)
			{
				AudioSource.PlayClipAtPoint(launchNoise, shotPoint.transform.position, 3f);
			}
			GameObject newshot = Object.Instantiate(projectile, shotPoint.transform.position, shotPoint.transform.rotation);
			sR = newshot.GetComponent<SpriteRenderer>();
			newshot.GetComponent<Rigidbody2D>().AddForce(shotForce * transform.localScale.x * Vector2.right, ForceMode2D.Force);
			if (transform.localScale.x == -1)
			{
				//Debug.Log("Facing Left");
				sR.flipX = true;
			}
			else if (transform.localScale.x == 1)
			{
				//Debug.Log("Facing Right");
				sR.flipX = false;
			}



			Object.Destroy(newshot, shotTTL);
		}
	}
	#endregion
}