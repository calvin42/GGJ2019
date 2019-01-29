using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneHandler : MonoBehaviour
{
    
    public int destinationSceneIndex;
    public Image background;

    void Awake(){
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeIn(){
        for (float f = 1.0f; f >= 0.0f; f -= 0.01f) 
        {
            background.color = new Color(0,0,0,f);
            yield return null;
        }
        Debug.Log("Cambio scena in");
    }

    public void triggerExitScene(){
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut(){
        for (float f = 0.0f; f <= 1.0f; f += 0.01f) 
        {
            background.color = new Color(0,0,0,f);
            yield return null;
        }
        Debug.Log("Cambio scena out "+ destinationSceneIndex);
        switch (destinationSceneIndex)
        {
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Menu No Tutorial");
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Cap0_Introduzione");
                break;
            case 4:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Opzioni");
                break;
            case 5:
                UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
                break;
            case 6:
                Application.Quit();
                break;
        }
        
    }

    public void setIndexScene(int newIndex){
        this.destinationSceneIndex = newIndex;
    }
}
