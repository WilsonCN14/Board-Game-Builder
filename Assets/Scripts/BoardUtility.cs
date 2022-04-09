using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;

public class BoardUtility
{
    // coordinates of start tile
    public static Vector3Int startTileLoc;

    //coordinates of finish tile
    public static Vector3Int finishTileLoc;

    //Small Board Boundaries
    private static int SMxLeft = -3;
    public static int SMxRight = 2;
    public static int SMyBottom = -2;
    public static int SMyTop = 1;

    //Med Board Boundaries
    public static int MDxLeft = -5;
    public static int MDxRight = 5;
    public static int MDyBottom = -3;
    public static int MDyTop = 2;

    //Large Board Boundaries
    public static int LGxLeft = -7;
    public static int LGxRight = 6;
    public static int LGyBottom = -4;
    public static int LGyTop = 3;

    // Board Boundaries
    public static int xLeft;
    public static int xRight;
    public static int yBottom;
    public static int yTop;


    /// Queue that holds all playable tiles/locations in the created board
    static public Queue<Vector3Int> GameLocationQueue = new Queue<Vector3Int>();


    // use this to determine if the game has been loaded once
    public static bool playGameLoadedOnce = false;

    // This method checks to see what size the user has designated and uses this to set the boundaries
    // The parameter being entered will come from early on when the user chooses the board size
    public static void setBoardSize(string boardSize) {

        if (boardSize == "SM") {
            xLeft = SMxLeft;
            xRight = SMxRight;
            yBottom = SMyBottom;
            yTop = SMyTop;
            //Debug.Log("Boardsize "+ boardSize);

        } else if (boardSize == "MD") {
            xLeft = MDxLeft;
            xRight = MDxRight;
            yBottom = MDyBottom;
            yTop = MDyTop;
            //Debug.Log("Boardsize " + boardSize);
        }
        else {
            xLeft = LGxLeft;
            xRight = LGxRight;
            yBottom = LGyBottom;
            yTop = LGyTop;
            //Debug.Log("Boardsize " + boardSize);
        }
    }


}
