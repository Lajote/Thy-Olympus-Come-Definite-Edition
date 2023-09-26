using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        Button buttonPlay = root.Q<Button>("Play");
        Button buttonQuit = root.Q<Button>("Quit");

        buttonPlay.clicked += StartGame;
        buttonQuit.clicked += QuitGame;
    }

    // Function to start the game (you can customize this)
    private void StartGame()
    {
        GameManager.instance.GetComponent<Loader>().LevelLoader(levelName: "Day1_1");
    }

    // Function to quit the application
    private void QuitGame()
    {
        Application.Quit();
    }
}
