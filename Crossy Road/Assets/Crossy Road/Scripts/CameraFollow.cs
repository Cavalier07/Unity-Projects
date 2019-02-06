using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public bool autoMove = true;
	public GameObject player = null;
	public Vector3 offset = new Vector3 (3, 6, -3);
	public float speed = 0.25f;

	Vector3 depth = Vector3.zero;
	Vector3 position = Vector3.zero;

	void Update()
	{
		//Check game can be played
		if(!Manager.instance.CanPlay())
			return;

		if (autoMove) 
		{
			//Move Camera Forward
			depth = this.gameObject.transform.position += new Vector3 (0, 0, speed * Time.deltaTime);

			//Follow the Player (left/right/forward/backwards)
			position = Vector3.Lerp (gameObject.transform.position , player.transform.position + offset, Time.deltaTime);
		
			//Update the camera object
			gameObject.transform.position = new Vector3 (position.x, offset.y, depth.z);
		} 
		else 
		{
			//Follow the Player (left/right/forward/backwards)
			position = Vector3.Lerp (gameObject.transform.position , player.transform.position + offset, Time.deltaTime);

			//Update the camera object
			gameObject.transform.position = new Vector3 (position.x, offset.y, position.z);
		}


	}
}
