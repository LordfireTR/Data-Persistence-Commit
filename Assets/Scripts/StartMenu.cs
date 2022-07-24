using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectDataPersistanceHandler;
    private DataPersistanceHandler scriptDataPersistanceHandler;

    void Start()
    {
        scriptDataPersistanceHandler = objectDataPersistanceHandler.GetComponent<DataPersistanceHandler>();
    }
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit()
        #endif
    }

    public void SetPlayerName(string input)
    {
        scriptDataPersistanceHandler.playerName = input;
    }
}
