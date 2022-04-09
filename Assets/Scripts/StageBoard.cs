using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

//this script will be used to replicate the board created in the CreateGame scene with the BuildManager Script

public class StageBoard : MonoBehaviour
{

    public Tilemap SBTileMap;
    public Tile SBtile;
    public Vector3Int SBlocation;
    public Tile SBStartTile;
    public Tile SBfinishTile;


    // TEST DATA - UNCOMMENT AS NEEDED
    //test tiles
    //public Vector3Int test1 = new Vector3Int(-2, 0, 0);
    //public Vector3Int test2 = new Vector3Int(-2, -1, 0);
    //public Vector3Int test3 = new Vector3Int(-2, -2, 0);
    //public Vector3Int test4 = new Vector3Int(-2, -3, 0);
    //public Vector3Int test5 = new Vector3Int(-1, -3, 0);
    //public Vector3Int test6 = new Vector3Int(0, -3, 0);

    // END TEST DATA


    // Start is called before the first frame update
    private void Start()
    {

        // TEST DATA - uncomment if needed. Remember, you need populate the queue from the
        // BuildGame scene if you don't use this test data
        //BoardUtility.GameLocationQueue.Enqueue(test1);
        //BoardUtility.GameLocationQueue.Enqueue(test2);
        //BoardUtility.GameLocationQueue.Enqueue(test3);
        //BoardUtility.GameLocationQueue.Enqueue(test4);
        //BoardUtility.GameLocationQueue.Enqueue(test5);
        //BoardUtility.GameLocationQueue.Enqueue(test6);

        // END TEST DATA

        //print the whole queue
        foreach (var data in BoardUtility.GameLocationQueue)
        {
                // place a tile on that location on the map
                SBTileMap.SetTile(data, SBtile);
                Debug.Log(data);
        }
        setStartAndFin();

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void setStartAndFin()
    {

        Vector3Int temp = BoardUtility.GameLocationQueue.Peek();
        //Debug.Log("Temp " + temp);
        SBTileMap.SetTile(temp, null);
        // Sets the static variable start tile for gameplay
        SBTileMap.SetTile(temp, SBStartTile);
        BoardUtility.startTileLoc = temp;
       
        temp = BoardUtility.GameLocationQueue.Last();
        // Sets the static variable finish tile for gameplay
        BoardUtility.finishTileLoc = temp;
        SBTileMap.SetTile(temp, SBfinishTile);
        BoardUtility.GameLocationQueue.Enqueue(temp);

    }
}
