using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : MonoBehaviour {

	float HP;
	public float MaxHP = 50;
	public int numBars = 2;
	float bar1min;
	int Damage;
	bool CombatType;
	public float maxHealthBarSlide;
	//float maxHealthBarSlide2;
	public GameObject HealthBar1;
	public GameObject HealthBar2;
	public GameObject marker;
	private SpriteRenderer healthBarSprite1;
	private SpriteRenderer healthBarSprite2;
	public GameObject Sceneloader;
	public int LoadNumber;
	Animator ani;



	// Use this for initialization
	void Start () {
		//maxHealthBarSlide =
		bar1min = (MaxHP / numBars) * (numBars-1);
		HP = MaxHP;
		CombatType = gameObject.GetComponent<BossBattle>().ReturnCombatType();
		healthBarSprite1 = HealthBar1.GetComponent<SpriteRenderer>();
		healthBarSprite2 = HealthBar2.GetComponent<SpriteRenderer>();
		setupBars();
		ani = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		if(HP <= 0)
		{
			//Destroy(gameObject);
			//gameObject.SetActive(false);
			gameObject.GetComponent<BossBattle>().SetQuiz(true);
			ani.SetBool("Died",true);
			StartCoroutine("SceneWait");

		}
	}

	public void SetCombatType(bool n)
	{
		CombatType = n;
	}
	public float ReturnHP()
	{
		return HP;
	}
	public void LightUp(bool n)
	{
		marker.SetActive(n);
	}
	public void getHit(int damage)
	{

		Vector3 mi;
		if(HP > 0)
		{
			if(HP < bar1min)
			{
				mi = HealthBar2.transform.localScale;
			}
			else
			{
				mi = HealthBar1.transform.localScale;
			}
			HP = HP - damage;
			float v =(float) (maxHealthBarSlide * (HP/100));
			mi.x = (float) v;
			if(HP < bar1min)
			{
				HealthBar2.transform.localScale = mi;

				mi.x = 0;
				HealthBar1.transform.localScale = mi;
			}
			else
			{
				HealthBar1.transform.localScale = mi;
			}
			//Debug.Log(HP);
		}

	}
	void setupBars()
	{
		int damage = 0;
		//Debug.Log(damage);
		Vector3 mi;

		mi = HealthBar2.transform.localScale;
		HP = HP - damage;
		float v =(float) (maxHealthBarSlide * (HP/100));
		mi.x = (float) v;

		HealthBar2.transform.localScale = mi;

		HealthBar1.transform.localScale = mi;

	}
	IEnumerator SceneWait()
	{
		yield return new WaitForSeconds(3);
		Sceneloader.GetComponent<ChangeScene>().LoadSpashScene(LoadNumber);
	}
}
