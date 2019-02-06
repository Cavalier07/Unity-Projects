using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	public float minX;
	public float maxX;

	private Ball ball;



	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (autoPlay)
			AutoPlay ();
		else
			MoveWithMouse ();
	}


	void MoveWithMouse()
	{
		//Get Mouse Location
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16; //16 Game Blocks
		
		//Create New Paddle Position
		Vector3 paddlePos = new Vector3(Mathf.Clamp(mousePosInBlocks, minX, maxX), transform.position.y , 0f);
		
		//Set Paddle Location
		transform.position = paddlePos;
	}

	void AutoPlay()
	{
		//Get Mouse Location
		Vector3 ballPosition = ball.transform.position;
		
		//Create New Paddle Position
		Vector3 paddlePos = new Vector3(Mathf.Clamp(ballPosition.x, minX, maxX), transform.position.y , 0f);
		
		//Set Paddle Location
		transform.position = paddlePos;
	}
}
