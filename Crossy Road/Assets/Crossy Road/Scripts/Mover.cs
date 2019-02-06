using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour 
{
	public float speed = 1.0f;
	public float moveDirection = 0;
	public bool parentOnTrigger = true; //Can you stand on it
	public bool hitBoxOnTrigger = false; //Will it Kill You
	public GameObject moverObject = null;

	private Renderer renderer = null;
	private bool isVisible = false;

	void Start()
	{
		renderer = moverObject.GetComponent<Renderer> ();
	}

	void Update()
	{
		//Move Object
		this.transform.Translate(speed * Time.deltaTime, 0 ,0);

		//Check Object can be seen
		IsVisible ();
	}

	void IsVisible()
	{
		//Check that camera has seen the mover
		if (renderer.isVisible) 
		{
			isVisible = true;
		}

		//Mover had previously been seen but has fallen off the camera
		if (!renderer.isVisible && isVisible) 
		{
			Debug.Log ("Mover :: IsVisible :: Mover out of Camera .. Destroying");
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		//Check if it's hit the player
		if (other.tag != "Player")
			return;

		Debug.Log ("Mover :: OnTriggerEnter :: Mover Hit Player");

		if (parentOnTrigger) 
		{
			Debug.Log ("Mover :: OnTriggerEnter :: Enter Parent to me");

			// Player Object will attach itself to mover
			other.transform.parent = this.transform;
		}

		if (hitBoxOnTrigger) 
		{
			Debug.Log ("Mover :: OnTriggerEnter :: Enter GotHit() . Game Over");

			//Player Object has been hit
			other.GetComponent<PlayerController> ().GotHit();
		}
	}

	void OnTriggerExit (Collider other)
	{
		//Check if it's hit the player
		if (other.tag != "Player")
			return;

		Debug.Log ("Mover :: OnTriggerExit :: Mover Hit Player");

		if (parentOnTrigger) 
		{
			Debug.Log ("Mover :: OnTriggerExit :: Enter Parent to me");

			// Player Object will detatch itself from the mover
			other.transform.parent = null;
		}
	}

}
