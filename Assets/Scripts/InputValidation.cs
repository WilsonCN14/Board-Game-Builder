using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;
using UnityEngine.SceneManagement;

public class InputValidation : MonoBehaviour
{


    public TextMeshPro inputValid;
    public TextMeshPro instantiated_inputValid;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void checkUserInput() {
        if (GameUtility.spinOrDice == null || GameUtility.boardSize == null) {
            DisplayInstructions("Fill out all choices");

        }else{

            SceneManager.LoadScene("PlayGame");
        }

    }
    // Display instructions in center of screen just long enough for player to read them
    void DisplayInstructions(string str)
    {
        inputValid.text = str;
        instantiated_inputValid = Instantiate(inputValid, inputValid.transform.position, inputValid.transform.rotation);

    }

}


