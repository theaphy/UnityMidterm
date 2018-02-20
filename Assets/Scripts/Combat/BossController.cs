using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

	#region Singelton
	public static BossController instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType<BossController>();
			}
			return _instance;
		}
	}
	static BossController _instance;

	void Awake()
	{
		_instance = this;
	}
	#endregion

	#region Variables
	CharacterStats stats;
	GameObject boss;
	Animator anim;
	public bool onBossLevel = false;
	public bool calledDecreasePhase1 = false;
	public bool calledDecreasePhase2 = false;
	public bool calledDecreasePhase3 = false;
	Vector3 originalScale;
	Vector3 desiredScale;
	public int scalingFramesLeft = 0;
	public int damageModifier = -10;
	public GameObject FireBall;
	public GameObject[] minions;
	public int numberOfMinions = 10;
	Transform target;
	public float lookRadius = 10f;




	#endregion

	#region Methods
	public void Start()
	{
		target = Player.instance.transform;
		originalScale = transform.localScale;
		desiredScale = originalScale *= .75f;
		stats = GetComponent<CharacterStats>();
		boss = GameObject.FindGameObjectWithTag("Boss").gameObject;
		stats = boss.GetComponent<CharacterStats>();
		if (boss != null)
		{
			anim = boss.GetComponent<Animator>();
			onBossLevel = true;
		}
	}

	void Update () {
		float distance = Vector3.Distance(target.position, transform.position);

		// If inside the radius
		if (distance <= lookRadius)
		{
			SendEnemyStats(stats);
		}

		if (GameObject.FindGameObjectsWithTag("Minions").Length == 0)
		{
			Attack();
		}
		if (scalingFramesLeft > 0)
		{
			//Debug.Log("Should shrink");
			transform.localScale = Vector3.Lerp(originalScale, desiredScale, Time.deltaTime * 10);
			scalingFramesLeft--;
		}

		if (!calledDecreasePhase1 && stats.currentHealth <= 750 && onBossLevel == true)
		{
			Attack();
			StartCoroutine(ReleaseMinions());
			originalScale = transform.localScale;
			desiredScale = originalScale *= .5f;
			stats.decreaseDamage(damageModifier);
			//anim.SetTrigger("DecreasingSize");
			//Debug.Log("about to chagne size");
			DecreaseSizePhase1();
			calledDecreasePhase1 = true;
		}
		if (!calledDecreasePhase2 && stats.currentHealth <= 500 && onBossLevel == true)
		{
			Attack();
			StartCoroutine(ReleaseMinions());
			originalScale = transform.localScale;
			desiredScale = originalScale *= .5f;
			stats.decreaseDamage(damageModifier);
			//anim.SetTrigger("DecreasingSize");
			//Debug.Log("about to chagne size");
			DecreaseSizePhase2();
			calledDecreasePhase2 = true;
		}
		if (!calledDecreasePhase3 && stats.currentHealth <= 250 && onBossLevel == true)
		{
			Attack();
			StartCoroutine(ReleaseMinions());
			originalScale = transform.localScale;
			desiredScale = originalScale *= .5f;
			stats.decreaseDamage(damageModifier);
			//anim.SetTrigger("DecreasingSize");
			//Debug.Log("about to chagne size");
			DecreaseSizePhase3();
			calledDecreasePhase3 = true;
		}
	}
	public void Attack() {
		//Debug.Log("attack started");
		anim.SetTrigger("JumpToPosition1");
	}
	public void EndAttack() {
		anim.ResetTrigger("JumpToPosition1");
	}
	public void ShootFireball()
	{
		Instantiate(FireBall, transform.position, Quaternion.identity);
	}
	public void DecreaseSizePhase1()
	{
		scalingFramesLeft = 12000;
	}
	public void DecreaseSizePhase2()
	{
		scalingFramesLeft = 12000;
	}
	public void DecreaseSizePhase3()
	{
		scalingFramesLeft = 12000;
	}
	public void ReleaseEnemies() {
		Debug.Log("pressed T");

	}
	public void SendEnemyStats(CharacterStats enemyStats)
	{
		DamageUI.instance.SetEnemyStats(enemyStats);
	}
	IEnumerator ReleaseMinions()
	{
		//Debug.Log("corouting started");
		for (int i = 0; i<numberOfMinions; i++)
		{
			Vector3 position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
			Vector3 smoothedPosition = Vector3.Lerp(transform.position, position, Time.deltaTime * 10);
			int index = Random.Range(0, minions.Length);
			Instantiate(minions[index], smoothedPosition, Quaternion.identity);
			//Debug.Log("" + numberOfMinions);
			yield return new WaitForSeconds(1f);
		}
		yield return null;

		//if (numberOfMinions <= 10)
		//{
		//	Vector3 position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
		//	Vector3 smoothedPosition = Vector3.Lerp(transform.position, position, Time.deltaTime * 10);
		//	int index = Random.Range(0, minions.Length);
		//	Instantiate(minions[index], smoothedPosition, Quaternion.identity);
		//	numberOfMinions++;
		//	Debug.Log("" + numberOfMinions);
		//}
		
	}
	#endregion
}

