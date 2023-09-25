using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int collected;
    public int maxEther;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }
    public enum GameState
    {
        Idle,
        InGame,
        GameOver,
        Menu,
        Pause,
        Victory,
        Load
    }

    public GameState gameState = GameState.Idle;




    public void GameStart()
    {
        gameState = GameState.InGame;
    }

    public void GameOver()
    {
        gameState = GameState.GameOver;
    }

    public void GamePause()
    {
        gameState = GameState.Pause;
    }
    public void GameMenu()
    {
        gameState = GameState.Menu;
    }
    public void Victory()
    {
        gameState = GameState.Victory;
    }
    public void Load()
    {
        gameState = GameState.Load;
    }
}
