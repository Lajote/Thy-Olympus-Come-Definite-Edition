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


        buttonPlay.clicked += () => GameManager.instance.GetComponent<Loader>().LevelLoader(levelName: "Day1_1");
    }
}
