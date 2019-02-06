using UnityEngine;
using System.Collections;

public class AnimatorController : MonoBehaviour 
{
	public PlayerController playerController = null;

	private Animator animator = null;

	void Start()
	{
		animator = this.GetComponent<Animator> ();
	}

	void Update()
	{
		//Player can move from any state to isDead
		if (playerController.isDead) 
		{
			animator.SetBool ("dead", true);
		} 
			
		//Player can only be in one of the following states
		if (playerController.jumpStart) 
		{
			animator.SetBool ("jumpStart", true);
		}
		else if (playerController.isJumping) 
		{
			animator.SetBool ("jump", true);
		}
		else
		{
			animator.SetBool ("jumpStart", false);
			animator.SetBool ("jump", false);
		}

		//If Player is in Idle we don't want to rotate
		if (!playerController.isIdle) 
		{
			return;
		}

		//Roatate the Player Object
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			gameObject.transform.rotation = Quaternion.Euler (270, 0 , 0);
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			gameObject.transform.rotation = Quaternion.Euler (270, 180, 0);
		}
		else if (Input.GetKeyDown (KeyCode.LeftArrow)) 
		{
			gameObject.transform.rotation = Quaternion.Euler (270, -90, 0);
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow)) 
		{
			gameObject.transform.rotation = Quaternion.Euler (270, 90, 0);
		}
	}
}
