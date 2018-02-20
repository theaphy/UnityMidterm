using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerMoveTemp : MonoBehaviour
{

	#region Singleton
	public static PlayerMoveTemp instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType<PlayerMoveTemp>();
			}
			return _instance;
		}
	}
	static PlayerMoveTemp _instance;

	void Awake()
	{
		_instance = this;
	}

	#endregion

	#region Variables
	public float moveSpeed;
	private Vector3 target;
	CharacterStats cs;
	PlayerStats ps;
	public GameObject clickIndicate;
	private Vector3 spawnPoint;

	private float playerX;
	private float playerY;

	private float cameraX;
	private float cameraY;
	#endregion

	#region Methods

	void Start()
	{
		ps = gameObject.GetComponent<PlayerStats>();
		spawnPoint = transform.position;
		target = transform.position;

		//playerX = Mathf.Round(transform.position.x/(1));
		//playerY = Mathf.Round(transform.position.y/(1));

	}

	//	void Update () {
	//		if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) {
	//			transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
	//		}
	//		if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
	//		{
	//			transform.Translate(new Vector3(0f,Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
	//		}
	//	}

	void Update()
	{
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}

		if (Input.GetMouseButtonDown(0))
		{
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.z = transform.position.z;

			Instantiate(clickIndicate, target, Quaternion.identity);
		}
		transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
	}
	public void Respawn()
	{
		
		transform.position = spawnPoint;
		HealthManager.instance.Heal(1000);
		if (ps != null)
		{
			ps.SetReadyToDie(1);
		}
		else {
			Debug.Log("could not find playerStats");
		}
		
	}

	#endregion
}