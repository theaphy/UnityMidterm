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

	#endregion

	#region Methods
	public void Start()
	{
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
		if (scalingFramesLeft > 0)
		{
			Debug.Log("Should shrink");
			transform.localScale = Vector3.Lerp(originalScale, desiredScale, Time.deltaTime * 10);
			scalingFramesLeft--;
		}

		if (!calledDecreasePhase1 && stats.currentHealth <= 750 && onBossLevel == true)
		{
			originalScale = transform.localScale;
			desiredScale = originalScale *= .5f;
			stats.decreaseDamage(damageModifier);
			//anim.SetTrigger("DecreasingSize");
			Debug.Log("about to chagne size");
			DecreaseSizePhase1();
			calledDecreasePhase1 = true;
		}
		if (!calledDecreasePhase2 && stats.currentHealth <= 500 && onBossLevel == true)
		{
			originalScale = transform.localScale;
			desiredScale = originalScale *= .5f;
			stats.decreaseDamage(damageModifier);
			//anim.SetTrigger("DecreasingSize");
			Debug.Log("about to chagne size");
			DecreaseSizePhase2();
			calledDecreasePhase2 = true;
		}
		if (!calledDecreasePhase3 && stats.currentHealth <= 250 && onBossLevel == true)
		{
			originalScale = transform.localScale;
			desiredScale = originalScale *= .5f;
			stats.decreaseDamage(damageModifier);
			//anim.SetTrigger("DecreasingSize");
			Debug.Log("about to chagne size");
			DecreaseSizePhase3();
			calledDecreasePhase3 = true;
		}
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

	#endregion
}
