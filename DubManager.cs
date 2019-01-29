using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DubManager : MonoBehaviour
{
    [SerializeField]
    public Sottotitolo[] narrativa;
    public Image background;
    public Text testo;

    private Animator animatorTesto;

    public float velComparsa;
    public float velScomparsa;

    private int currentPosition = 0;

    private bool comparsa = true;

    void Start(){
        animatorTesto = testo.gameObject.GetComponent<Animator>();
    }

    void Update(){
        if(!Input.GetButtonDown("Submit"))
            return;
        
        if(Input.GetButtonDown("Submit") && Input.GetAxisRaw("Submit") == 1){
            Debug.Log(currentPosition);
            if(comparsa){
                string textToDisplay = narrativa[currentPosition].messaggio;
                Sprite eventualeSfondo = null;
                testo.text = textToDisplay;
                
                
                
                animatorTesto.SetTrigger("In");
                
                eventualeSfondo = narrativa[currentPosition].sfondo;
                if(eventualeSfondo != null){
                    background.sprite = eventualeSfondo;
                    Debug.Log("CII");
                }
            }
            else{
                animatorTesto.SetTrigger("Out");
                if(background.sprite != narrativa[currentPosition+1].sfondo){
                    background.sprite = null;
                }
                currentPosition++;
            }
            comparsa = !comparsa;
            
            if(currentPosition == narrativa.Length)
                Debug.Log("Finito");
        }
    }
    



}
