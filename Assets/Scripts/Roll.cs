// References used https://www.youtube.com/watch?v=ouGJJzNPsSk


using System.Collections;
using UnityEngine;

public class Roll : MonoBehaviour {

    // Array of dice sides sprites loads from resources folder
    public Sprite[] objectSides;

    // Reference to sprite renderer to change sprites
    public SpriteRenderer rend;

    // GameFlow.cs uses the following data
    public static bool playerCanRoll = false;
    public static bool canDisplayResult = false;
    public static int finalSide;

    // Initialize
    public void Start () {

        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();

        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        //diceSides = Resources.LoadAll<Sprite>("DiceSides/");
    }

    // If you left click over the dice then RollTheDice coroutine is started
    public void OnMouseDown()
    {
        // GameFlow.cs makes playerCanRoll = true
        if (playerCanRoll)
        {
            canDisplayResult = false;
            StartCoroutine("RollObject");
        }
    }

    // Coroutine that rolls the dice
    public IEnumerator RollObject()
    {
        // Initial value of side set to 0
        int randomSide = 0;

        Debug.Log("initial side" + randomSide);

        // Loop to switch ides ramdomly
        // before final side appears.
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 5 (All inclusive)
            randomSide = Random.Range(0, 5);

            // Set sprite from array according to random value
            rend.sprite = objectSides[randomSide];

            // Pause before next iteration
            yield return new WaitForSeconds(0.05f);
        }

        finalSide = randomSide + 1;

        // Show final dice value in Console
        Debug.Log("final side" + finalSide);

        playerCanRoll = false;
        canDisplayResult = true;
    }
}
