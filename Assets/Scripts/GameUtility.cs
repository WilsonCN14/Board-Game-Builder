using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUtility : MonoBehaviour
{

    // check against these for game settings
    public static string gameName;
    public static string boardSize;
    public static string gamePiece;
    public static string gameGoal;
    public static string spinOrDice;

    // use this bool to see if default game should be used


    public TextMeshPro instr;
    public TextMeshPro instantiated_instr;


    //public void userInput(string name) {
    //    Debug.Log(name);
    //}

    //********************
    // Board size toggles
    //********************

    public void smBoardSizeToggle(bool tog){
        if (tog == true) {
            boardSize = "SM";
            Debug.Log(boardSize);
        }
    }
    public void mdBoardSizeToggle(bool tog)
    {
        if (tog == true)
        {
            boardSize = "MD";
            Debug.Log(boardSize);
        }
    }

    public void lgBoardSizeToggle(bool tog)
    {
        if (tog == true)
        {
            boardSize = "LG";
            Debug.Log(boardSize);
        }
    }

    //********************
    // Game Piece toggles
    //********************

    public void toggleOne(bool tog)
    {
        if (tog == true)
        {
            gamePiece = "one";
            Debug.Log("Game piece: " + gamePiece);
        }
    }
    public void toggleTwo(bool tog)
    {
        if (tog == true)
        {
            gamePiece = "two";
            Debug.Log("Game piece: " + gamePiece);
        }
    }

    //********************
    // Game Goal toggles
    //********************

    public void moneyToggle(bool tog)
    {
        if (tog == true)
        {
            gameGoal = "money";
            Debug.Log(gameGoal);
        }
    }
    public void worldToggle(bool tog)
    {
        if (tog == true)
        {
            gameGoal = "world";
            Debug.Log(gameGoal);
        }
    }

    public void raceToggle(bool tog)
    {
        if (tog == true)
        {
            gameGoal = "race";
            Debug.Log(gameGoal);
        }
    }

    //********************
    // Dice or Spinner toggles
    //********************

    public void diceToggle(bool tog)
    {
        if (tog == true)
        {
            spinOrDice = "dice";
            Debug.Log(spinOrDice);
        }
    }
    public void spinnerToggle(bool tog)
    {
        if (tog == true)
        {
            spinOrDice = "spinner";
            Debug.Log(spinOrDice);
        }
    }


    //********************
    // save Game Name
    //********************

    public void saveGamename(string gName)
    {
        gameName = gName;
        Debug.Log(gameName);
    }


    // Display instructions in center of screen just long enough for player to read them
    public void DisplayInstructions(string str)
    {
        instr.text = str;
        instantiated_instr = Instantiate(instr, instr.transform.position, instr.transform.rotation);

    }

}
