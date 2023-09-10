using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIPanel : MonoBehaviour
{
    
    public DeveloperButton devButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        devButton.DevTools();
        
        //Define the buttons
        Button buttonScenes = root.Q<Button>("ButtonScenes"); //En el primero definimos  cómo referenciaremos el objeto "buttonXXXX" y en el segundo definimos cómo se llamarán desde los objetos del UI toolkit 
        Button buttonExit = root.Q<Button>("ButtonExit"); 



        buttonScenes.clicked += () => devButton.scenes(); // get active scene method
        buttonExit.clicked += () => devButton.exitDev(); // get active scene method

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
