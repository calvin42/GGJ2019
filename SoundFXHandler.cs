using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundFXHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource source;
    public AudioClip[] suoni;
    void Start()
    {
        source = this.gameObject.GetComponent<AudioSource>();
        
    }

    public void triggerSound(int index){

        source.clip = suoni[index];
        source.Play();

    }
}
