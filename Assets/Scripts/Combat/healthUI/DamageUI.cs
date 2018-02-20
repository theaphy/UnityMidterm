using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUI : MonoBehaviour {
	#region Variables
	const float stayTime = 1;


	public GameObject TextGraphic;
	public Text damageText;


	Transform cam;
	public Transform target;
	public CharacterStats stats;
	public static DamageUI instance;
	public CharacterStats enemyStats1;
	public CharacterStats playerStats;

	public float damage;
	public float oldHealth;
	float lastHealthChangeTime;
	#endregion

	#region Methods
	void Awake()
	{
		instance = this;
	}
	public void Init(Transform target, CharacterStats stats)
	{
		this.target = target;
		this.stats = stats;

		cam = Camera.main.transform;
		TextGraphic.SetActive(false);
		damageText.enabled = false;
		oldHealth = GetHealth();
	}
	public void Start()
	{
		playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
	}
	public void Update()
	{
		damage = GetDamage();
		damageText.text = ("- " + damage);
	}
	public void LateUpdate()
	{
		
		
		Debug.Log("enemy damage = " + GetDamage());

		if (target == null)
		{
			Destroy(gameObject);
			return;
		}
		transform.position = target.position;

		float newHealth = GetHealth();
		
		if (newHealth < oldHealth)
		{

			oldHealth = newHealth;

			lastHealthChangeTime = Time.time;
			TextGraphic.SetActive(true);
			damageText.enabled = true;
			
			
		}
		//Debug.Log("" + oldHealth);
		if (TextGraphic.activeSelf)
		{
			if (Time.time - lastHealthChangeTime > stayTime)
			{
				TextGraphic.SetActive(false);
				damageText.enabled = false;
			}
		}
		


	}
	float GetHealth()
	{
		return stats.currentHealth;
	}
	public void SetEnemyStats(CharacterStats enemyStats) {
		if (enemyStats != null){
			enemyStats1 = enemyStats;
		}
		
	}
	float GetDamage() {
		if (enemyStats1 != null)
		{
			return enemyStats1.damage.GetValue();
		}
		else {
			return playerStats.damage.GetValue();
		}
		//return enemyStats1.currentDamage;
	}
	#endregion
}
