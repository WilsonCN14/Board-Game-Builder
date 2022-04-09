using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;
using System.Linq;
using UnityEngine.UI;

// reference: https://www.youtube.com/watch?v=qFXnBourCQk

public class BuildManager : MonoBehaviour
{


    public TextMeshPro boardInstructions;
    public TextMeshPro instantiated_instructions;
    //public Text boardHeading;

    public Tilemap TileMap;

    public Tile tile;

    public Tile startTile;
 

    public Vector3Int location;

    static public Queue<Vector3Int> tempQueue = new Queue<Vector3Int>();

    //Small Board Boundaries
    //int SBxLeft = -3;
    //int SBxRight = 2;
    //int SByBottom = -2;
    //int SByTop = 1;

    //Med Board Boundaries
    //int MDxLeft = -5;
    //int MDxRight = 5;
    //int MDyBottom = -3;
    //int MDyTop = 2;

    //Large Board Boundaries
    //int LGxLeft = -7;
    //int LGxRight = 6;
    //int LGyBottom = -4;
    //int LGyTop = 3;



    //test tiles
    //public Vector3Int test1 = new Vector3Int(-2, 0, 0);
    //public Vector3Int test2 = new Vector3Int(-2, -1, 0);
    //public Vector3Int test3 = new Vector3Int(-2, -2, 0);
    //public Vector3Int test4 = new Vector3Int(-2, -3, 0);
    //public Vector3Int test5 = new Vector3Int(-1, -3, 0);
    //public Vector3Int test6 = new Vector3Int(0, -3, 0);
    //public Vector3Int test7 = new Vector3Int(-2, 0, 0);

    private void Start()
    {

        //boardHeading.text = "Click board to add tile";
        DisplayInstructions("Left click in board to add tiles one at a time in the order you want to play");

        // comment this out if you want to create a real queue from clicks
        //BoardUtility.GameLocationQueue.Enqueue(test1);
        //BoardUtility.GameLocationQueue.Enqueue(test2);
        //BoardUtility.GameLocationQueue.Enqueue(test3);
        //BoardUtility.GameLocationQueue.Enqueue(test4);
        //BoardUtility.GameLocationQueue.Enqueue(test5);
        //BoardUtility.GameLocationQueue.Enqueue(test6);
        //BoardUtility.GameLocationQueue.Enqueue(test7);

    }

private void Update(){

        if (Input.GetMouseButtonDown(0)) {
           
            // store mouse position of mouse click
            Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // store location of tilemap
            location = TileMap.WorldToCell(mp);

            

            //Set the size of the board based on user's settings stored in GameUtility.cs
            BoardUtility.setBoardSize(GameUtility.boardSize);

            //if boundary is not exceeded
            if ((location.x <= BoardUtility.xRight && location.x >= BoardUtility.xLeft) && (location.y <= BoardUtility.yTop && location.y >= BoardUtility.yBottom)) {

                // place a tile on that location on the map
                //TileMap.SetTile(location, tile);

                setTileType();

                //As soon as mouse click, destroy instructions
                Destroy(instantiated_instructions);

                //Uncomment this if you want to load the queue from clicks
                // store location in the Game Location Queue
                //print the whole queue
                //foreach (var data in BoardUtility.GameLocationQueue)
                //{
                //    Debug.Log("Queue: " + data);
                //}
            }
        }

        if (Input.GetMouseButtonDown(1))
        {

            //Store position as coordinates in world rather than screen pixels
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // setting tile to whatever the selected tile is

            TileMap.SetTile(TileMap.WorldToCell(position), null);

         
            Debug.Log("position: " + position);

        }



    }

    public void setTileType()
    {

        Debug.Log("CURRENT COUNT " + BoardUtility.GameLocationQueue.Count);
        if (BoardUtility.GameLocationQueue.Count == 0)
        {

            TileMap.SetTile(location, startTile);
            BoardUtility.GameLocationQueue.Enqueue(location);
            //startTileLoc = location;
        }
        else if (BoardUtility.GameLocationQueue.Count > 0) {
            TileMap.SetTile(location, tile);
            BoardUtility.GameLocationQueue.Enqueue(location);
        }
    }

    // Display instructions in center of screen just long enough for player to read them
    public void DisplayInstructions(string str)
    {
        boardInstructions.text = str;
        instantiated_instructions = Instantiate(boardInstructions, boardInstructions.transform.position, boardInstructions.transform.rotation);

    }


}

