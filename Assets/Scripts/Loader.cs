using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    public GameObject ui_carga;
    public Image ui_barra;
    public int index;
    Scene currentScene;
    public void SubirNivel()
    {
        StartCoroutine("cargar");
    }
    public IEnumerator cargar()
    {

        currentScene =  SceneManager.GetActiveScene();
        index = currentScene.buildIndex;
        ui_carga.SetActive(true);
        AsyncOperation carga = SceneManager.LoadSceneAsync(index + 1, LoadSceneMode.Single);
        while(!carga.isDone)
        {
            ui_barra.fillAmount= carga.progress;
            yield return null;
        }
    }

    public void LevelLoader(int levelIndex = 999, string levelName = "Tartaros") //Loads desired Level. Optional arguments: int levelIndex ; string levelName
    {
        try
        {
            if (levelIndex != 999)
            {
                Debug.Log("Vamos bien");
                SceneManager.LoadScene(sceneBuildIndex: levelIndex);

            }
            else if (levelName != "Tartaros")
            {
                Debug.Log("nos vamos pa: " + levelName);
                SceneManager.LoadScene(sceneName: levelName);
            }
        }
        catch { }
        finally { }
    }
}
