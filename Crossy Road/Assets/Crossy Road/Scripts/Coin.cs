using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour 
{

	public int coinValue = 1;

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") 
		{
			Debug.Log ("Coin :: OnTriggerEnter :: Player Picked up a coin");

			//Update Coint Count
			Manager.instance.UpdateCoinCount(coinValue);

			Destroy (this.gameObject);

		}
	}

}
