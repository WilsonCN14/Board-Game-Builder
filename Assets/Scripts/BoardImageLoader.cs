using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Reference: https://www.youtube.com/watch?v=BLEjkIGrkLM





public class BoardImageLoader : MonoBehaviour
{
	// Based on board size selected, change background board image
	void Start() {

		if (GameUtility.boardSize == "LG")
		{
			transform.localScale = new Vector3(74, 63, 0);
		}
		else if (GameUtility.boardSize == "MD")
		{
			transform.localScale = new Vector3(53, 46, 0);
		}
		else
		{
			transform.localScale = new Vector3(33, 33, 0);
		}


	}


	void Update()
	{

	
	}

	// example of how to change
	// this.gameObject.GetComponent<SpriteRenderer>().sprite = DeadBird;
}


