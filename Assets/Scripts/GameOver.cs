using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverText;
    public GameObject GameClearText;
    public GameObject GameOverScreen;
    public GameObject B_Retry;
    public GameObject B_MainMenu;
    public GameObject B_GameExit;
    public static GameObject GameOverSC;
    public static GameObject GameOverTXT;
    public static GameObject GameClearTXT;
    public static GameObject Retry;
    public static GameObject MainMenu;
    public static GameObject GameExit;
    void Start()
    {
        GameOver.GameOverSC = GameOverScreen;
        GameOver.GameOverTXT = GameOverText;
        GameOver.GameClearTXT = GameClearText;
        GameOver.Retry = B_Retry;
        GameOver.MainMenu = B_MainMenu;
        GameOver.GameExit = B_GameExit;
        GameOver.GameOverSC.gameObject.SetActive (false);
        GameOver.GameOverTXT.gameObject.SetActive (false);
        GameOver.GameClearTXT.gameObject.SetActive (false);
        GameOver.Retry.gameObject.SetActive (false);
        GameOver.MainMenu.gameObject.SetActive (false);
        GameOver.GameExit.gameObject.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void show()
    {
        GameOver.GameOverSC.gameObject.SetActive (true);
        GameOver.GameOverTXT.gameObject.SetActive (true);
        GameOver.Retry.gameObject.SetActive (true);
        GameOver.MainMenu.gameObject.SetActive (true);
        GameOver.GameExit.gameObject.SetActive (true);
        
    }

    public static void win()
    {
        GameOver.GameOverSC.gameObject.SetActive (true);
        GameOver.GameClearTXT.gameObject.SetActive (true);
        GameOver.Retry.gameObject.SetActive (true);
        GameOver.MainMenu.gameObject.SetActive (true);
        GameOver.GameExit.gameObject.SetActive (true);
        
    }
}
