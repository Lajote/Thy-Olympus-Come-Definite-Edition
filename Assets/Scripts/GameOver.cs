using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverText;
    public GameObject GameClearText;
    public GameObject GameOverScreen;
    public static GameObject GameOverSC;
    public static GameObject GameOverTXT;
    public static GameObject GameClearTXT;
    void Start()
    {
        GameOver.GameOverSC = GameOverScreen;
        GameOver.GameOverTXT = GameOverText;
        GameOver.GameClearTXT = GameClearText;
        GameOver.GameOverSC.gameObject.SetActive (false);
        GameOver.GameOverTXT.gameObject.SetActive (false);
        GameOver.GameClearTXT.gameObject.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void show()
    {
        GameOver.GameOverSC.gameObject.SetActive (true);
        GameOver.GameOverTXT.gameObject.SetActive (true);
        
    }

    public static void win()
    {
        GameOver.GameOverSC.gameObject.SetActive (true);
        GameOver.GameClearTXT.gameObject.SetActive (true);
        
    }
}
