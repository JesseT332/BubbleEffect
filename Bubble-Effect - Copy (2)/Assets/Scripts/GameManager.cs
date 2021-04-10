using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerMovement playerMovement; //calls the player movement script

    //public BubbleMovement bubbleMovement;

    public Text scoreText; //calls the ext from the project
  
    private int scoreKeep;
  

    // Update is called once per frame
    void Update()
    {
        scoreKeep = playerMovement.points;
        //scoreKeep = bubbleMovement.points;


        scoreText.text = "SCORE: " + scoreKeep; //shows the score on the game scene
    }
}
