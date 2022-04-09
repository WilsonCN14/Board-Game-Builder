using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearQueue : MonoBehaviour
{
    public void cQueue() {

        BoardUtility.GameLocationQueue.Clear();
        GameUtility.boardSize = null;
        GameUtility.spinOrDice = null;
        GameUtility.gameName = null;
        GameUtility.gamePiece = null;
        GameUtility.spinOrDice = null;
       
    }
}
