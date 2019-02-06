using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Manager : MonoBehaviour 
{
	public Text coin = null;
	public Text distance = null;
	public Camera camera = null;
	public GameObject guiGameOver = null;

	private int currentCoins = 0;
	private int currentDistance = 0;
	private bool canPlay = false;

	private static Manager s_Instance;

	//Singleton - Can only have 1 Manager in the game at a time
	public static Manager instance
	{
		get
		{
			if (s_Instance == null )
			{
				s_Instance = FindObjectOfType ( typeof (Manager) ) as Manager;
			}

			return s_Instance;
		}

	}


	void Start()
	{
		//TODO - Level Generator Start up
	
	
	}

	public void UpdateCoinCount(int value)
	{
		//Update Total
		currentCoins = currentCoins + value;

		//Update Text
		coin.text = currentCoins.ToString();
	}
		
	public void UpdateDistanceCount()
	{
		//Update Total
		currentDistance = currentDistance + 1;

		//Update Text
		distance.text = currentDistance.ToString();

		//TODO: generate new level piece here
	}

	public bool CanPlay()
	{
		return canPlay;
	}

	public void StartPlay()
	{
		canPlay = true;
	}

	public void GameOver()
	{
		//Shake Camera
		camera.GetComponent<CameraShake> ().Shake ();

		//Pause Camera
		camera.GetComponent<CameraFollow> ().enabled = false;

		//Load GUID
		GuiGameOver();
	}

	void GuiGameOver()
	{
		Debug.Log ("Game Over");

		//Turn GUI Game Over Object On
		guiGameOver.SetActive (true);
	}

	public void PlayAgain()
	{
		//Reload Scene - As map is random
		Scene scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (scene.name);
	}

	public void Quit()
	{
		Application.Quit ();
	}

}
