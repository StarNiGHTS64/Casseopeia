using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource BGM;

    // Start is called before the first frame update
    void Start()
    {
        // Audio Source responsavel por emitir os sons
        BGM = GetComponent<AudioSource>();
        BGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // change music if spotted
    }

    public void ChangeBGM(AudioClip clip)
    {
        if(BGM.clip.name != clip.name)
        {
            BGM.Stop();
            BGM.clip = clip;
            BGM.Play();

        }
    }
}
