using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public Image heart1, heart2, heart3;

    public Slider Ether;

    public Slider Health;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UpdateGemCount();
    }

    void Update()
    {
        
    }
    
    public void UpdateHealthDisplay()
    {
        switch (PlayerHealthController.instance.currentHealth)
        {
            
        }
    }

    public void UpdateGemCount()
    {
        Ether.value = CharacterController.instance.collected;
    }

    public void PauseButtonClicked()
    {
        GameManager.instance.gameState = GameManager.GameState.Pause;
    }

    public void MenuButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGameButtonClicked()
    {
        GameManager.instance.gameState = GameManager.GameState.InGame;
    }

    public void RestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Add this line
    }

    public void ExitGameButtonClicked()
    {
        Application.Quit(); // Add this line
    }

}
