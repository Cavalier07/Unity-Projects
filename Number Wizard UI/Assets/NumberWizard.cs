using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour{
	public Text text;


	int max;
	int min;
	int guess;
	int guessessAllowed = 25;
	
	// Use this for initialization
	void Start(){
		StartGame();
	}
	
	void StartGame(){	
		max = 1000;
		min = 1;
		NextGuess ();
	}
	
	
	void NextGuess(){

		guess = Random.Range(min , max + 1);
		text.text = guess.ToString();
		guessessAllowed = guessessAllowed - 1;
		
		if (guessessAllowed < 0) {
			Application.LoadLevel("Win");
		}
	}
	
	
	public void GuessHigher(){
		min = guess;
		NextGuess();
	}
	
	public void GuessLower(){
		max = guess;
		NextGuess();
	}
}
