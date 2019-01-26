using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonsAnimator : MonoBehaviour
{

    //GOs
    public GameObject btnTutorial;
    public GameObject btnStart;
    public GameObject btnOptions;
    public GameObject btnCredits;
    public GameObject btnExit;
    

    //Buttons
    private Button btnTutorialButton;
    private Button btnStartButton;
    private Button btnOptionsButton;
    private Button btnCreditsButton;
    private Button btnExitButton;

    //Sound
    public AudioClip changeSound;
    private AudioSource source;

    //Anims
    private Animator btnTutorialAnim;
    private Animator btnStartAnim;
    private Animator btnOptionsAnim;
    private Animator btnCreditsAnim;
    private Animator btnExitAnim;

    private int currentSelection = 1;

    //public Animation animationIn;
    //public Animation animationOut;

    void Start(){
        btnTutorialAnim = btnTutorial.GetComponent<Animator>();
        btnStartAnim = btnStart.GetComponent<Animator>();
        btnOptionsAnim = btnOptions.GetComponent<Animator>();
        btnCreditsAnim = btnCredits.GetComponent<Animator>();
        btnExitAnim = btnExit.GetComponent<Animator>();
        btnTutorialButton = btnTutorial.GetComponent<Button>();
        btnStartButton = btnStart.GetComponent<Button>();
        btnOptionsButton = btnOptions.GetComponent<Button>();
        btnCreditsButton = btnCredits.GetComponent<Button>();
        btnExitButton = btnExit.GetComponent<Button>();

        btnTutorialAnim.SetTrigger("In");
        btnTutorialButton.Select();
        source = this.GetComponent<AudioSource>();
        source.clip = changeSound;
    }
    void Update(){

        if(Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") > .05f && currentSelection > 1){
            Debug.Log("Prova");
            if(currentSelection == 5){
                
                btnExitAnim.SetTrigger("Back");
                btnCreditsAnim.SetTrigger("In");
                btnCreditsButton.Select();
                

            }else if(currentSelection == 4){
                btnOptionsAnim.SetTrigger("In");
                btnOptionsButton.Select();
                btnCreditsAnim.SetTrigger("Back");
            }
            else if(currentSelection == 3){
                btnStartAnim.SetTrigger("In");
                btnStartButton.Select();
                btnOptionsAnim.SetTrigger("Back");
            }
            else{
                btnTutorialAnim.SetTrigger("In");
                btnTutorialButton.Select();
                btnStartAnim.SetTrigger("Back");
            }
            currentSelection--;
            source.Play();
            //su
        }
        else if(Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") < -.05f && currentSelection < 5){
            //giu
            Debug.Log("Prova");
            if(currentSelection == 1){
                
                btnTutorialAnim.SetTrigger("Back");
                btnStartAnim.SetTrigger("In");
                btnStartButton.Select();

            }else if(currentSelection == 2){
                btnOptionsAnim.SetTrigger("In");
                btnOptionsButton.Select();
                btnStartAnim.SetTrigger("Back");
            }
            else if(currentSelection == 3){
                btnCreditsAnim.SetTrigger("In");
                btnCreditsButton.Select();
                btnOptionsAnim.SetTrigger("Back");
            }
            else{
                btnExitAnim.SetTrigger("In");
                btnExitButton.Select();
                btnCreditsAnim.SetTrigger("Back");
            }
            currentSelection++;
            source.Play();
        }

    }

    

    

}
