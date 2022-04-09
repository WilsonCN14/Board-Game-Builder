using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Tilemaps;
using System.Linq;
using UnityEngine.SceneManagement;


public class DefaultGameLoad : MonoBehaviour
{
 
    public Vector3Int location;

    static public Queue<Vector3Int> tempQueue = new Queue<Vector3Int>();


    //test tiles
    public Vector3Int spot1 = new Vector3Int(-4, 0, 0);
    public Vector3Int spot2 = new Vector3Int(-4, 1, 0);
    public Vector3Int spot3 = new Vector3Int(-4, 2, 0);
    public Vector3Int spot4 = new Vector3Int(-3, 2, 0);
    public Vector3Int spot5 = new Vector3Int(-2, 2, 0);
    public Vector3Int spot6 = new Vector3Int(-1, 2, 0);
    public Vector3Int spot21 = new Vector3Int(-1, 1, 0);
    public Vector3Int spot7 = new Vector3Int(-1, 0, 0);
    public Vector3Int spot8 = new Vector3Int(0, 0, 0);
    public Vector3Int spot9 = new Vector3Int(1, 0, 0);
    public Vector3Int spot10 = new Vector3Int(2, 0, 0);
    public Vector3Int spot11 = new Vector3Int(3, 0, 0);
    public Vector3Int spot12 = new Vector3Int(4, 0, 0);
    public Vector3Int spot13 = new Vector3Int(4, -1, 0);
    public Vector3Int spot14 = new Vector3Int(4, -2, 0);
    public Vector3Int spot15 = new Vector3Int(4, -3, 0);
    public Vector3Int spot16 = new Vector3Int(3, -3, 0);
    public Vector3Int spot17 = new Vector3Int(2, -3, 0);
    public Vector3Int spot18 = new Vector3Int(1, -3, 0);
    public Vector3Int spot20 = new Vector3Int(1, -2, 0);




    public void LoadFakeGameboard()
    {

        //set large board size
        GameUtility.boardSize = "LG";

        GameUtility.gamePiece = "one";

        GameUtility.spinOrDice = "dice";

   

        // comment this out if you want to create a real queue from clicks
        BoardUtility.GameLocationQueue.Enqueue(spot1);
        BoardUtility.GameLocationQueue.Enqueue(spot2);
        BoardUtility.GameLocationQueue.Enqueue(spot3);
        BoardUtility.GameLocationQueue.Enqueue(spot4);
        BoardUtility.GameLocationQueue.Enqueue(spot5);
        BoardUtility.GameLocationQueue.Enqueue(spot6);
        BoardUtility.GameLocationQueue.Enqueue(spot21);
        BoardUtility.GameLocationQueue.Enqueue(spot7);
        BoardUtility.GameLocationQueue.Enqueue(spot8);
        BoardUtility.GameLocationQueue.Enqueue(spot9);
        BoardUtility.GameLocationQueue.Enqueue(spot10);
        BoardUtility.GameLocationQueue.Enqueue(spot11);
        BoardUtility.GameLocationQueue.Enqueue(spot12);
        BoardUtility.GameLocationQueue.Enqueue(spot13);
        BoardUtility.GameLocationQueue.Enqueue(spot14);
        BoardUtility.GameLocationQueue.Enqueue(spot15);
        BoardUtility.GameLocationQueue.Enqueue(spot16);
        BoardUtility.GameLocationQueue.Enqueue(spot17);
        BoardUtility.GameLocationQueue.Enqueue(spot18);
        BoardUtility.GameLocationQueue.Enqueue(spot20);



        SceneManager.LoadScene("PlayGame");


    }
}
