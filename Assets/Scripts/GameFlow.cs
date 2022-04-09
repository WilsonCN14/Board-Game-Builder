using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public enum GameState {START, PLAYER_1_TURN, PLAYER_2_TURN, FINISH}

public class GameFlow : MonoBehaviour
{
    public GameState state; 
    public GameObject player1;
    public GameObject player2;
    public Sprite girl;
    public Sprite boy;
    public Sprite cat;
    public Sprite dragon;
    public GameObject dice;
    public GameObject spinner;
    public GameObject startGameObject;
    public TextMeshProUGUI title;
    public TextMeshProUGUI goal;
    public Text heading;
    public TextMeshPro instructions;
    public GameObject restartGameObject;
    public TextMeshProUGUI winText;
    private GameObject player1Instance;
    private GameObject player2Instance;
    private GameObject rollObject;
    private string winner;

    void Start()
    {
        state = GameState.START;
        DescribeGame();
    }

    // Displays title, goal of the game, and the start button when player arrives at PlayGame scene
    void DescribeGame()
    {
        // Check for null because pre-made game has nothing in CreateGameMenu filled out
        if (GameUtility.gameName != null)
        {
            title.text = GameUtility.gameName;
        }

        if  (GameUtility.gameGoal != null) 
        {
            if (GameUtility.gameGoal == "money")
            {
                goal.text = "Goal: Reach the finish tile first to win a million dollars";
            } 
            else if (GameUtility.gameGoal == "world")
            {
                goal.text = "Goal: Reach the finish tile first to save the world";
            }
            else 
            {
                goal.text = "Goal: Race to reach the finish tile first";
            }
        }

        startGameObject.gameObject.SetActive(true);
    }

    public void SetUpGame() 
    {
        // Remove title and goal from middle of screen
        startGameObject.gameObject.SetActive(false);

        // Make copies of queue so one players movements don't affect other player's queue
        Queue<Vector3Int> player_1_tiles = new Queue<Vector3Int>(BoardUtility.GameLocationQueue.ToArray());
        Queue<Vector3Int> player_2_tiles = new Queue<Vector3Int>(BoardUtility.GameLocationQueue.ToArray());

        // Find start tile
        Vector3Int player_1_start = player_1_tiles.Dequeue();
        Vector3Int player_2_start = player_2_tiles.Dequeue();

        // Pick sprites for players
        if (GameUtility.gamePiece == "one") {
            player1.GetComponent<SpriteRenderer>().sprite = girl;
            player2.GetComponent<SpriteRenderer>().sprite = boy;

            // Scale sprites so they are slightly smaller than size of tile
            player1.transform.localScale = new Vector3(0.08f, 0.08f, 1);
            player2.transform.localScale = new Vector3(0.08f, 0.08f, 1);
        } else {
            player1.GetComponent<SpriteRenderer>().sprite = cat;
            player2.GetComponent<SpriteRenderer>().sprite = dragon;

            player1.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            player2.transform.localScale = new Vector3(0.3f, 0.3f, 1);
        }

        // Sprite initiates slightly off from center of tile so need to adjust position when initiating
        player1Instance = Instantiate(player1, new Vector3(player_1_start.x + 0.5f, player_1_start.y + 0.5f, player_1_start.z), transform.rotation);
        player2Instance = Instantiate(player2, new Vector3(player_2_start.x + 0.5f, player_2_start.y + 0.5f, player_2_start.z), transform.rotation);

        // Instantiate dice or spinner based on choice in create game
        if (GameUtility.spinOrDice == "dice") {
            rollObject = Instantiate(dice, dice.transform.position, dice.transform.rotation);
        } else {
            rollObject = Instantiate(spinner, spinner.transform.position, spinner.transform.rotation);
        }

        state = GameState.PLAYER_1_TURN;

        StartCoroutine(PlayerTurn(player_1_tiles, player_2_tiles));
    }

    IEnumerator PlayerTurn(Queue<Vector3Int> player_1_tiles, Queue<Vector3Int> player_2_tiles) 
    {
        while (state != GameState.FINISH)
        {
            Debug.Log(player_1_tiles.Count);
            Debug.Log(player_2_tiles.Count);

            // Tell player to roll dice/spin spinner
            if (state == GameState.PLAYER_1_TURN)
            {
                heading.text = "Player 1 Turn";
                DisplayInstructions("Player 1 Turn");
            }
            else 
            {
                heading.text = "Player 2 Turn";
                DisplayInstructions("Player 2 Turn");
            }

            // Let Roll.cs know the player can roll
            Roll.playerCanRoll = true;

            // Wait for player to roll the dice
            yield return StartCoroutine(WaitForResult());

            // Obtain roll results
            int steps = Roll.finalSide;
            Roll.canDisplayResult = false;
            
            // Move player piece and check if player won
            if (state == GameState.PLAYER_1_TURN)
            {
                yield return StartCoroutine(MovePlayer(steps, player_1_tiles, "Player 1"));
                Player.canMove = false;
                
                // Keep going until land on last tile
                if (player_1_tiles.Count > 1)
                {
                    state = GameState.PLAYER_2_TURN;
                }
                else
                {
                    heading.text = "Player 1 Wins!!!";
                    DisplayInstructions("Player 1 Wins!!!");
                    state = GameState.FINISH;
                    EndGame(player1);
                }
            }
            else 
            {
                yield return StartCoroutine(MovePlayer(steps, player_2_tiles, "Player 2"));

                // Keep going until land on last tile
                if (player_2_tiles.Count > 1)
                {
                    state = GameState.PLAYER_1_TURN;
                }
                else
                {
                    heading.text = "Player 2 Wins!!!";
                    DisplayInstructions("Player 2 Wins!!!");
                    state = GameState.FINISH;
                    EndGame(player2);
                }
            }
        }
    }

    // Display instructions in center of screen just long enough for player to read them
    void DisplayInstructions(string str)
    {
        instructions.text = str;
        TextMeshPro instantiated_instructions = Instantiate(instructions, instructions.transform.position, instructions.transform.rotation);
        Destroy(instantiated_instructions, 1);
    }

    IEnumerator WaitForResult()
    {
        while (!Roll.canDisplayResult)
        {
            yield return null;
        }
    }

    IEnumerator MovePlayer(int steps, Queue<Vector3Int> tiles, string playerTurn)
    {
        Player.canMove = true;
        Player.playerTurn = playerTurn;

        if (steps > tiles.Count - 1)
        {
            // Stop before taking off all tiles because need to land on finish tile
            steps = tiles.Count - 1;
        }

        for (int i = 0; i < steps; i++)
        {
            Vector3Int new_position = tiles.Dequeue();
            Player.newPosition = new Vector2(new_position.x + 0.5f, new_position.y + 0.5f);
            yield return new WaitForSeconds(1.5f);
        }
    }

    void EndGame(GameObject player)
    {
        // Display game results
        restartGameObject.gameObject.SetActive(true);

        // Figure out who won
        if (player = player1)
        {
            winner = "Player 1";
        }
        else
        {
            winner = "Player 2";
        }

        // Display who won and what they won
        if  (GameUtility.gameGoal == null) 
        {
            winText.text = winner + " won!";
        }
        else 
        {
            if (GameUtility.gameGoal == "money")
            {
                winText.text = winner + " won a million dollars!";
            } 
            else if (GameUtility.gameGoal == "world")
            {
                winText.text = winner + " saved the world!";
            }
            else 
            {
                winText.text = " won the race!";
            }
        }
    }

    public void RestartGame()
    {
        // Turn off game results
        restartGameObject.gameObject.SetActive(false);

        // Destroy any instantiated objects
        Destroy(player1Instance);
        Destroy(player2Instance);
        Destroy(rollObject);

        // Start from beginning
        Start();
    }

}
