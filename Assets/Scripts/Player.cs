using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName;
    public static Vector2 newPosition;
    public static bool canMove = false;
    public static string playerTurn;
    private float speed = 1.0f;

    void Update()
    {
        if (canMove == true && playerTurn == playerName)
        {
            transform.position = Vector2.MoveTowards(transform.position, newPosition, Time.deltaTime * speed);
        }
    }
}
