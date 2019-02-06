using UnityEngine;
using System.Collections;


public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider){
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		levelManager.LoadLevel ("Lose");
	}
}
