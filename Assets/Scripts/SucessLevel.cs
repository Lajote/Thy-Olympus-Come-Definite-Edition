using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
public class SucessLevel : MonoBehaviour
{

    public LightsON darkness;
    [Serializable]
    public class SucessLevelClass : UnityEvent {}
    bool winning = false;
    bool win;

    [FormerlySerializedAs("LastLevel")]
    [SerializeField]
    public SucessLevelClass sucessLevel = new SucessLevelClass();
    
    public int index;
    Scene currentScene;
    public Image WinText;
    private float targetAlpha = 100f;
    public float alphaChangeSpeedON = 10.0f;
    public float countDown = 8;


    public int ether;
    void Start()
    {
        win = false;
    }
    private void Update()
    {
        ether = GameManager.instance.collected;
        if (Input.GetKeyDown(KeyCode.Q)&&winning)
        {
            currentScene = SceneManager.GetActiveScene();
            index = currentScene.buildIndex;

            if (index == 3)
            {
                sucessLevel.Invoke();
            }
            else
            {
                // sucessLevel.Invoke();

                darkness.lightsOn();
                AudioManager.audioManager.BgmStop();
                AudioManager.audioManager.win();
                WinText.color = new Color(WinText.color.r, WinText.color.g, WinText.color.b, Mathf.Lerp(WinText.color.a, targetAlpha, alphaChangeSpeedON * Time.deltaTime));

                win = true;
                // GameManager.instance.GetComponent<Loader>().LevelLoader(levelIndex: (index + 1)); //Loads desired Level. Optional arguments: int levelIndex ; string levelName



            }


        }

        
        if (win) { countDown = countDown - 1 * Time.deltaTime;

            if (countDown <= 0)
            {
                WIN();
            }
        
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Player")&&(ether>=GameManager.instance.maxEther)))
        {   //
            winning = true;
        }


    }

    private void WIN()
    {
        GameManager.instance.GetComponent<Loader>().LevelLoader(levelIndex: (index + 1));
        
    }
}
