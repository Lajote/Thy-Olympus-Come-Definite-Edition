using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    public static UiController instance;

    public Image heart1, heart2, heart3;

    public Text GemText;

    public Sprite heartFull, heartEmpty;

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
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;

                break;

            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;

                break;

            case 1:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;

            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;

            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;

                break;
        }
    }

    public void UpdateGemCount()
    {
        GemText.text = CharacterController.instance.collected.ToString();
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
