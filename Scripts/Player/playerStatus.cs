using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStatus : MonoBehaviour {
	private float minHealth,currentHealth, HitDamage, Lives;
	public int maxHealth = 100;
	public GameObject HealthBar;
	private int LaneNum;
	private float maxHeathScale;
	private float scaleChange;
	private SpriteRenderer sprite;
	private SpriteRenderer healthSprite;
	private string currentLevel;
	private string currentLevelSection;
	private int numPages = 0;
	public GameObject pauseText;
	//menu book
	public GameObject pauseBook;
	private bool BoughtBook;
	Animator ani;
	public Text PageCount;
	string defaultPageCountText = "Number of Pages: ";
	//death
	bool StartDeath = false;
	public GameObject deathMarker;
	public float speed = 1f;
	public GameObject RespawnMarker;
	public GameObject DeathPanel;
	Collider2D  Mcol;
	Collider2D[] myColliders;
	public GameObject Sceneloader;
	int timer;



	// Use this for initialization
	void Start () {
		// rend = flash.GetComponent<SpriteRenderer>();
		// clear = rend.color;
		//menu book
		myColliders = gameObject.GetComponents<Collider2D>();
		Mcol = gameObject.GetComponent<Collider2D>();
		pauseBook.SetActive(false);
		BoughtBook = false;
		ani = GetComponent<Animator>();

		//

		maxHeathScale =HealthBar.transform.localScale.x;
		currentHealth = maxHealth;
		sprite = GetComponent<SpriteRenderer>();
		healthSprite = HealthBar.GetComponent<SpriteRenderer>();
		pauseText.GetComponent<BookTextTrigger>().TriggerText();
	}
	public void UpdateLane(int n)
	{
		LaneNum = n;
		//Debug.Log(LaneNum);
	}
	public int returnLane()
	{
		return LaneNum;
	}
	public void UpdateHealth(int n)
	{
		Vector3 mi = HealthBar.transform.localScale;
		currentHealth = currentHealth - n;


		float v =(float) (maxHeathScale * (currentHealth/100));
		mi.x = (float) v;
		HealthBar.transform.localScale = mi;

		//Debug.Log(n + " current Health " + currentHealth + " ----" + v);

	}
	public float returnHealth()
	{
		return currentHealth;
	}
	public string returnLevelSection()
	{
		return currentLevelSection;
	}
	void Update ()
	{
		switch (LaneNum)
		{
			case 1:
				sprite.sortingLayerName = "LowLane";
				healthSprite.sortingLayerName = "LowLane";
				break;
			case 2:
				sprite.sortingLayerName = "MidLane";
				healthSprite.sortingLayerName = "MidLane";
				break;
			case 3:
				sprite.sortingLayerName = "HighLane";
				healthSprite.sortingLayerName = "HighLane";
				break;
		}
		if(currentHealth <= 0 && StartDeath == false)
		{
			ani.SetBool("Dead",true);
			gameObject.GetComponent<playerMove>().CanMove(false);
			//Mcol.enabled = false;
			foreach(Collider2D bc in myColliders) bc.enabled = false;
			StartDeath = true;
			timer = 0;

		}
		if(StartDeath)
		{
			transform.position = Vector3.Lerp(transform.position,deathMarker.transform.position
			,speed*Time.deltaTime);
			DeathPanel.SetActive(true);
			sprite.sortingLayerName = "StartScreen";
			DeathPanel.GetComponent<Dead>().Change();
			timer++;
			if(timer >= 100)
			{
				StartCoroutine("SceneWait");
			}
		}
	}
	void respawn()
	{
		transform.position = RespawnMarker.transform.position;
	}

	void OnTriggerStay2D(Collider2D level)
	{
		if (level.gameObject.name == "LeftSection")
		{
			currentLevelSection = "LeftSection";
		}
		else if (level.gameObject.name == "RightSection")
		{
			currentLevelSection = "RightSection";
		}
		else if (level.gameObject.name == "MidSection")
		{
			currentLevelSection = "MidSection";
		}

	}
	void  OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.name == "LowLane")
		{
			LaneNum = 1;
		}
		else if (col.gameObject.name == "MidLane")
		{
			LaneNum = 2;
		}
		else if (col.gameObject.name == "HighLane")
		{
			LaneNum = 3;
		}
	}
	public void AddPage()
	{
		numPages = numPages +1;
		PageCount.text = defaultPageCountText + numPages.ToString();
	}
	public bool SubtractPages(int n)
	{
		if(numPages - n >=0)
		{
			numPages = numPages -n;
			PageCount.text = defaultPageCountText + numPages.ToString();
			return true;
		}
		else
		{
			return false;
		}
	}
	public int returnCash()
	{
		return numPages;
	}

	public void BuyBook(bool n)
	{
		BoughtBook = n;
		if(BoughtBook)
		{
			pauseBook.SetActive(true);
		}
	}

	IEnumerator SceneWait()
	{
		yield return new WaitForSeconds(5);
		Sceneloader.GetComponent<ChangeScene>().LoadScene(8);
	}


}
