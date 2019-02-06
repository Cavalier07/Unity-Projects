using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;

	private int timesHit = 0;
	private LevelManager levelManager;
	private bool isBreakable;


	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");

		//Keep Track of Breakable Bricks
		if (isBreakable)
			breakableCount = breakableCount + 1;

		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		if (isBreakable) 
		{
			AudioSource.PlayClipAtPoint(crack , transform.position , 0.5f);
			HandleHits ();
		}
	
	}

	void HandleHits()
	{
		int maxHits = hitSprites.Length + 1;
		timesHit ++;
		if (timesHit >= maxHits)
		{
			breakableCount = breakableCount - 1;
			levelManager.BrickDestroyed();
			Destroy (gameObject);
			LoadSmoke();
		}
		else
		{
			LoadSprites ();
		}
	}

	void LoadSprites()
	{
		int spriteIndex = timesHit - 1;

		if(hitSprites[spriteIndex])
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		else
			Debug.LogError ("Brick Sprite Missing");
	}

	void LoadSmoke()
	{
		GameObject smokePuff = Instantiate(smoke , transform.position , Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer> ().color;
		smokePuff.particleSystem.Play ();
	}
}
