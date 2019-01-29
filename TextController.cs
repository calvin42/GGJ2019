using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;


public class Subtitle{
    public string subs;
    public float duration;

    public Subtitle(string line, float dur){
        subs = line;
        duration = dur;
    }
    
}

public class TextController : MonoBehaviour
{
    public Camera mainCamera;
    public string nextScene;
    private TextMeshProUGUI m_textMeshPro;
    //private TMP_FontAsset m_FontAsset;

    private  string label;// = "The <#0050FF>count is: </color>{0:2}";
    // public Animator animator;
    private float m_frame;
    private int dialogueCounter;
    private float timeBase, waitAudio;
    private float lastSubDuration;
    private List<Subtitle> subtitles;
    Rigidbody2D rb2D;
    private bool updateLine;
    private float seconds;
    public GameObject[] enemyList;
    bool spacePressed;
    bool started;
        
    void Start()
    {
        // Add new TextMesh Pro Component
        m_textMeshPro = GetComponent<TextMeshProUGUI>();

        // rb2D = gameObject.AddComponent<Rigidbody2D>();
        started = false;
        dialogueCounter = 0;
        timeBase = 6;
        waitAudio = 2.5f;
        //textMeshPro.fontColor = new Color32(255, 255, 255, 255);
        spacePressed = false;
        lastSubDuration = 0.3f;
        // m_textMeshPro.text = "Bullo1: Ancora ti ostini a gironzolare per il quartiere truccato?";
        updateLine = true;
        subtitles = new List<Subtitle>();
        subtitles.Add(new Subtitle("Bullo1: Ancora ti ostini a gironzolare per il quartiere truccato?",3f));
        subtitles.Add(new Subtitle("Bullo2: Già, non ti rendi conto che rimani diverso da noi",3.5f));
        subtitles.Add(new Subtitle("Bullo2: e anzi vai avanti a ridicolizzarti coi trucchi", 3.5f));
        subtitles.Add(new Subtitle("Bullo2: e con altre stupide trovate per imitarci?", 3.5f));
        subtitles.Add(new Subtitle("Cthulhu: Ditemi, cos’avete contro di me?", 2.5f));
        subtitles.Add(new Subtitle("Cthulhu: Che cosa vi ho fatto?", 1.5f));
        subtitles.Add(new Subtitle("Cthulhu: Possiamo anche essere diversi esteticamente", 3.5f));
        subtitles.Add(new Subtitle("Cthulhu: ma ciò non vi rende migliori di me, non trovate?", 3.5f));
        subtitles.Add(new Subtitle("Bullo1: Ancora non capisci, Cthulhu, che non sarai mai uno di noi",3.5f));
        subtitles.Add(new Subtitle("Bullo1: Sei solo, non hai amici e nonostante questo ti credi migliore di noi?", 4.5f));
        subtitles.Add(new Subtitle("Bullo1: O ci accusi di essere cattivi?", 3.5f));
        subtitles.Add(new Subtitle("Bullo2: Beh, forse siamo cattivi", 3.5f));
        subtitles.Add(new Subtitle("Bullo2: Anzi, diamogli un assaggio...", 3.5f));
        subtitles.Add(new Subtitle("Cthulhu: Non avvicinatevi, non provateci nemmeno, non oggi", 3.5f));
        subtitles.Add(new Subtitle("Bullo1: Altrimenti?", 3.5f));
        subtitles.Add(new Subtitle("Cthulhu: Altrimenti mi arrabbio", 3.5f));
    }


    void Update()
    {
        // label = subtitles[dialogueCounter];
        
        

        if (waitAudio < 0){
            ChangeScene();
        }
        // Debug.Log(m_frame);
        timeBase -= Time.deltaTime;
        if ( timeBase < 0 && dialogueCounter < subtitles.Count){
            if(!started){
                started = true;
                gameObject.GetComponent<SoundFXHandler>().triggerSound(1);
            }

            m_textMeshPro.text = subtitles[dialogueCounter].subs;
            timeBase = subtitles[dialogueCounter++].duration;
            // StartCoroutine(WaitSub());

        }
        // m_frame += 1 * Time.deltaTime;
        // if (dialogueCounter >= subtitles.Count){
        //     m_textMeshPro.text = "Premi barra spaziatrice";
        //     if (Input.GetKeyDown(KeyCode.Space)){
        //         foreach (GameObject enemy in enemyList)
        //         {
        //             enemy.transform.position += new Vector3(0, 100*Time.deltaTime, 0);
        //         }
        //     }
            // GameObject.Find("Main Camera").GetComponent<CameraMovement>().doZoomOut = true;
            // mainCamera.orthographicSize = 3.0f;
        // }
        if (dialogueCounter >= subtitles.Count && !spacePressed){
            m_textMeshPro.text = "Premi barra spaziatrice";
            if (Input.GetKeyDown(KeyCode.Space)){
                spacePressed = true;
                m_textMeshPro.text = "UAAAAAAAAARGHHHHHHHHHHH";
                gameObject.GetComponent<SoundFXHandler>().triggerSound(0);
                foreach (GameObject enemy in enemyList)
                {
                    float x;
                    if (enemy.transform.position.x < transform.position.x){
                        x = -300;
                    } else{
                        x = 300;
                    }

                    rb2D = enemy.gameObject.GetComponent<Rigidbody2D>();
                    Vector2 force = new Vector2(x, 1000);
                    rb2D.AddForce(force*Time.deltaTime);
                }

            }
        }
        if (spacePressed)
            waitAudio -= Time.deltaTime;
    }

    public void ChangeScene(){
        SceneManager.LoadScene(nextScene);
    }
    
}



