using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager uiManager;

    public float EtherPersent;

    public Slider Ether;

    public Slider Health;

    private void Awake()
    {
        uiManager = this;
    }
    void Start()
    {
        UpdateEtherCount();
    }

    void Update()
    {
        
    }
    
    public void UpdateHealthDisplay()
    {
        Health.value = PlayerHealthController.instance.currentHealth;
       
    }

    public void UpdateEtherCount()
    {
        EtherPersent= (float)GameManager.instance.collected / (float)GameManager.instance.maxEther;
        Debug.Log(EtherPersent);
        Ether.value = EtherPersent;
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
