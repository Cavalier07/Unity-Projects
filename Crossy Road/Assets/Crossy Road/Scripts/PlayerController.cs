using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float moveDistance = 1;
	public float moveTime = 0.4f;
	public float colliderDistCheck = 1;
	public bool isIdle = true;
	public bool isDead = false;
	public bool isMoving = false;
	public bool isJumping = false;
	public bool jumpStart = false;
	public ParticleSystem particle = null;
	public GameObject chick = null;

	private Renderer renderer = null;
	private bool isVisible = false;

	void Start ()
	{
		renderer = chick.GetComponent<Renderer> ();
	}

	void Update()
	{
		//Check if game can be started
		if (!Manager.instance.CanPlay ())
			return;

		// If Player is dead we don't want to do anything
		if(isDead)	
			return;

		CanIdle ();
		CanMove ();
		IsVisible ();
	}


	void CanIdle()
	{
		//If Player is not Idle we don't want to do anything
		if(!isIdle)
			return;

		//Check if one of the arrow keys we want is pressed down
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			CheckIfCanMove ();
		} 
	}

	void CheckIfCanMove()
	{
		//Check if there is a collider box in front of player
		RaycastHit hit;
		Physics.Raycast (this.transform.position, -chick.transform.up, out hit , colliderDistCheck);
		Debug.DrawRay (this.transform.position, -chick.transform.up * colliderDistCheck, Color.red , 2); 

		if (hit.collider == null) 
		{
			SetMove ();
		} 
		else 
		{
			if (hit.collider.tag == "collider") 
			{
				Debug.Log ("PlayerController :: CheckIfCanMove ::  Collider has tag 'collider'");
			} 
			else 
			{
				SetMove ();
			}
		}
	}

	void SetMove()
	{
		//Set Correct Player State
		isIdle = false;
		isMoving = true;
		jumpStart = true;
	}

	void CanMove()
	{
		//If Player is already moving we don't want to do anything
		if (!isMoving)
			return;

		//Act Depending on Key Press
		if (Input.GetKeyUp (KeyCode.UpArrow)) 	  
		{
			Moving (new Vector3 (transform.position.x, transform.position.y, transform.position.z + moveDistance)); 
			SetMoveForwardState();
		} 
		else if ( Input.GetKeyUp (KeyCode.DownArrow))  
		{ 
			Moving (new Vector3 (transform.position.x, transform.position.y, transform.position.z - moveDistance));
		} 
		else if (Input.GetKeyUp (KeyCode.LeftArrow))  
		{
			Moving (new Vector3 (transform.position.x - moveDistance, transform.position.y, transform.position.z));
		} 
		else if (Input.GetKeyUp (KeyCode.RightArrow)) 
		{
			Moving (new Vector3 (transform.position.x + moveDistance, transform.position.y, transform.position.z));
		} 
	}

	void Moving(Vector3 position)
	{
		//Set Correct Player State
		isIdle = false;
		isMoving = true;
		isJumping = true;
		jumpStart = false;

		//Move Player
		LeanTween.move (this.gameObject, position, moveTime).setOnComplete(MoveComplete);
	}

	void MoveComplete()
	{
		//Set Correct Player State
		isJumping = false;
		isIdle = true;
		isMoving = false;
	}

	void SetMoveForwardState()
	{
		//Update Distance
		Manager.instance.UpdateDistanceCount();
	}

	void IsVisible()
	{
		//Check that camera has seen the player
		if (renderer.isVisible) 
		{
			isVisible = true;
		}

		//Player had previously been seen but has fallen off the camera
		if (!renderer.isVisible && isVisible) 
		{
			Debug.Log ("PlayerContoller :: IsVisible :: Player is off screen. Apply GotHit()");
			GotHit ();
		}
	}

	public void GotHit()
	{
		//Set Correct Player State
		isDead = true;

		//Play Particle
		ParticleSystem.EmissionModule emissionModule = particle.emission;
		emissionModule.enabled = true;

		//Send GameOver State
		Manager.instance.GameOver();
	}
}
