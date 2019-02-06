using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed = 15.0f;
	public float padding = 1.0f;

	private float xMax;
	private float xMin;
	
	// Use this for initialization
	void Start () {
		//Set the min/max for x based on the camera
		float distance = transform.position.z - Camera.main.transform.position.z;
		
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1,0,distance));

		xMin = leftMost.x + padding;
		xMax = rightMost.x - padding;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 newPosition = transform.position;

		if(Input.GetKey(KeyCode.LeftArrow))
			newPosition  += Vector3.left * speed * Time.deltaTime;
		else if (Input.GetKey(KeyCode.RightArrow))       
			newPosition += Vector3.right * speed * Time.deltaTime;

		//Restrict Player from moving outside of the playspace
		float newX = Mathf.Clamp (newPosition.x, xMin, xMax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.y);
	}
}
