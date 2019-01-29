using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

namespace Level2 {
    public class PlayerController : MonoBehaviour
    {
        public float MovementSpeed;
        public float JumpSpeed;
        public float JumpStep;
        public float MaxForce;
        public int TotalJumps;
        public GameObject tmpt;
        private SoundFXHandler soundFXHandler;
        //public GameObject side;
        //public GameObject fly;
        public GameObject player;
        public GameObject chthulu;

        public bool landed = false;
        public bool flying = false;


        private Rigidbody2D rb2d; 

        private int jumpDone = 0;
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D> ();
            rb2d.freezeRotation = true;
            tmpt.GetComponent<TextMeshProUGUI>().SetText("Jumps: {0}", TotalJumps);
            soundFXHandler = this.gameObject.GetComponent<SoundFXHandler>();
        }


        private void Jump(float horizontal, float vertical){
            Debug.Log("Jumping!");
            Debug.Log("horizontal: " + horizontal);
            Debug.Log("verticial: " + vertical);
            soundFXHandler.triggerSound(0);
            //if(Input.GetKeyDown(KeyCode.Space)){
                Debug.Log("Jump -> Keydown pressed");
                //MoveToLayer(fly.transform, 0);
                //MoveToLayer(front.transform, 9);
                //MoveToLayer(side.transform, 9);
                if (TotalJumps > 0)
                {
                    TotalJumps--;
                    Vector2 jump = new Vector2(horizontal, JumpStep);
                    rb2d.AddForce(jump * JumpSpeed);
                    jumpDone++;
                    flying = true;
                    landed = false;
                    tmpt.GetComponent<TextMeshProUGUI>().SetText("Jumps: {0}", TotalJumps);
                }
            //}
        }

        void MoveToLayer(Transform root, int layer)
        {
            root.gameObject.layer = layer;
            foreach (Transform child in root)
                MoveToLayer(child, layer);
        }



        void Update()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = 0;


            if (rb2d.velocity.magnitude < MaxForce)
            {
                //Vector2 movement = new Vector2(moveHorizontal, moveVertical);
                //rb2d.AddForce(movement * MovementSpeed);
                //front.transform.position = new Vector2(front.transform.position.x, 100);
                //side.transform.position = new Vector2(side.transform.position.x, -1);
                //MoveToLayer(side.transform, 0);
                //MoveToLayer(front.transform, 9);
                //MoveToLayer(fly.transform, 9);

                if (Mathf.Approximately(rb2d.velocity.magnitude, 0.0f) && moveHorizontal == 0 && landed)
                {
                    chthulu.GetComponent<Animator>().SetTrigger("W2I");
                }
                else if (moveHorizontal != 0 && landed && !flying)
                {
                    //front.transform.position = new Vector2(front.transform.position.x, -1);
                    //side.transform.position = new Vector2(side.transform.position.x, 100);
                    //MoveToLayer(front.transform, 0);
                    //MoveToLayer(fly.transform, 9);
                    //MoveToLayer(side.transform, 9);
                    chthulu.GetComponent<Animator>().SetTrigger("I2W");
                }
            }
            //if(rb2d.velocity.magnitude == 0)
            //{
            //    chthulu.GetComponent<Animator>().SetTrigger("W2I");
            //}

            //if (moveHorizontal == 0)
            //{
            //    chthulu.GetComponent<Animator>().SetTrigger("W2I");
            //}

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (landed && !flying)
                {
                    chthulu.GetComponent<Animator>().SetTrigger("I2F");
                }
                //if (landed)
                //{
                //    if (Mathf.Approximately(rb2d.velocity.magnitude, 0.0f))
                //    {
                //        chthulu.GetComponent<Animator>().SetTrigger("I2F");
                //    }
                //    else
                //    {
                //        chthulu.GetComponent<Animator>().SetTrigger("W2F");
                //    }
                //}
                Jump(Input.GetAxis("Horizontal"), 0);
            }

        }

        void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = 0;


            if (rb2d.velocity.magnitude < MaxForce)
            {
                Vector2 movement = new Vector2(moveHorizontal, moveVertical);
                rb2d.AddForce(movement * MovementSpeed);
                
            }
            
        }

        //void Update()
        //{

        //}

        void OnCollisionEnter2D(Collision2D col)
        {
            //if (landed)
            //{
            //    return;
            //}
            Debug.Log("OnCollisionEnter");
            if (Input.GetAxis("Horizontal") == 0 && flying)
            {
                chthulu.GetComponent<Animator>().SetTrigger("F2I");
                flying = false;
            }
            else if(flying)
            {
                chthulu.GetComponent<Animator>().SetTrigger("F2W");
                flying = false;
            }
            //else
            //{
            //    chthulu.GetComponent<Animator>().SetTrigger("W2I");
            //}
            landed = true;
            if (col.gameObject.name == "BottomBorder")
            {
                Debug.Log("Collided");
                //MoveToLayer(front.transform, 0);
                //MoveToLayer(fly.transform, 9);
                //MoveToLayer(side.transform, 9);

            }
            //chthulu.GetComponent<Animator>().SetTrigger("F2I");
        }
    }
}