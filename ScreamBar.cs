using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreamBar : MonoBehaviour
{
    public float fillingSpeed;
    public float decreasingSpeed;
    public float defillingSpeed;
    public bool isFilling;
    private bool isDecreasing = false;
    private float startDefilling = 0.1f;
    //GOs

    public Image fillObject;

    void Start(){
        
    }
    void Update(){
        if(isFilling)
            StartCoroutine("StartFilling");
        if(fillObject.fillAmount >= 1.0f)
            GameOver();
            // isFilling = true;
        startDefilling -= Time.deltaTime;
        if (startDefilling - Time.deltaTime < 0){
            startDefilling = 0.1f;
            StartCoroutine("Decrease");
        }
        
        // else
        //     isFilling = false;

        // if(!isDecreasing)
        //     StartCoroutine("StartFilling");
    }
    void GameOver(){

    }
    IEnumerator StartFilling(){

        // while(fillObject.fillAmount < 1.0f){
        fillObject.fillAmount += fillingSpeed*.001f;
        fillObject.color = new Color(fillObject.fillAmount,1-fillObject.fillAmount,0);
        Debug.Log(fillObject.color);
        Debug.Log(fillObject.fillAmount);
        // yield return null;
        // }
        isFilling = false;
        return null;
    }

    IEnumerator Decrease(){

        // while(fillObject.fillAmount > 0.0f){
            fillObject.fillAmount -= decreasingSpeed*.001f;
            fillObject.color = new Color(fillObject.fillAmount,1-fillObject.fillAmount,0);
            if(fillObject.fillAmount < 0.001f)
                return null;
            return null;
        // }
        // isDecreasing = false;
    }

}
