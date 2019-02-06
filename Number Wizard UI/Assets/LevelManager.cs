using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public void LoadLevel(string name)
	{
		Debug.Log ("Level Load Requested For " + name);
		Application.LoadLevel (name);
	}

}
