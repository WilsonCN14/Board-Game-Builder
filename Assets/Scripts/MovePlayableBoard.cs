using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


//Reference: https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.MoveGameObjectToScene.html
// This script controls which aspects of the scene get loaded into the next scene

public class MovePlayableBoard : MonoBehaviour
{
    // Type in the name of the Scene you would like to load in the Inspector
    public string m_Scene;

    // Assign your GameObject you want to move Scene in the Inspector
    public GameObject m_gameObject;

    bool testBool = BoardUtility.playGameLoadedOnce;



    //public static EventSystem createGameEventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();

    void Update()
    {
        // Press the space key to add the Scene additively and move the GameObject to that Scene
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Loaded" + testBool);
           
            StartCoroutine(LoadYourAsyncScene());
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(m_Scene, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(m_gameObject, SceneManager.GetSceneByName(m_Scene));
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
