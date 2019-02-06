using UnityEngine;
using System.Collections;

public class NumberWizards : MonoBehaviour
{
    int max;
    int min;
    int guess;


    // Use this for initialization
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {

        print("========================");
        print("Welcome to Number Wizard");
        print("Pick a number in your head, but don't tell me!");


		max = 1000;
		min = 1;
		guess = 500;

        print("The highest number you can pick is " + max);
        print("The lowest number you can pick is " + min);

        print("Is the number higher or lower then " + guess + " ?");



        max = max + 1;
    }


    void NextGuess()
    {
        guess = (max + min) / 2;
        print("Higher or Lower than " + guess + " ?");
        print("Up arrow = higher, down = higher, return = equal");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess;
            NextGuess();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;
            NextGuess();
        }
        else if(Input.GetKeyDown(KeyCode.Return))
        {
            print("I won !");
            StartGame();
        }
    }
}
