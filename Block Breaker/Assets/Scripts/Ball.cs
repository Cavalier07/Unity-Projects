using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	private Paddle paddle;
	private Vector3 paddleToBallVector; 
	private bool hasStarted = false;

	// Use this for initialization
	void Start () {

		//Looks for the paddle object in the scence
		paddle = GameObject.FindObjectOfType<Paddle>();

		//Gets the difference between the paddle and the ball
		paddleToBallVector = transform.position - paddle.transform.position;
	}	
	// Update is called once per frame
	void Update () {

		if (!hasStarted) {
			//Lock ball to paddle
			transform.position = paddle.transform.position + paddleToBallVector;

			//Launch Ball when mouse button is clicked
			if (Input.GetMouseButtonDown (0)) {
				rigidbody2D.velocity = new Vector2 (2f, 10f);
				hasStarted = true;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {

		Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));

		if (hasStarted && collision.gameObject.name == "Paddle")
		{			
			audio.Play ();
			rigidbody2D.velocity += tweak;
		}
	}
}
