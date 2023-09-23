using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class SucessLevel : MonoBehaviour
{
    [Serializable]
    public class SucessLevelClass : UnityEvent {}
    bool winning = false;

    [FormerlySerializedAs("LastLevel")]
    [SerializeField]
    public SucessLevelClass sucessLevel = new SucessLevelClass();
    
    public int index;
    Scene currentScene;

    public CharacterController CC;
    public int ether;
    void Start()
    {
        
    }
    private void Update()
    {
        ether = CC.collected;
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
                GameManager.instance.GetComponent<Loader>().LevelLoader(levelIndex: (index + 1)); //Loads desired Level. Optional arguments: int levelIndex ; string levelName
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Player")&&(ether>=2)))
        {   //
            winning = true;
        }


    }
}
