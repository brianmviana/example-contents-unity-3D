using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megaman : MonoBehaviour {

    public AudioSource megamanAudio;
    public AudioClip[] audioClips;

    public void PlayStep(){
        int index = Random.Range(0, audioClips.Length);
        megamanAudio.clip = audioClips[index];
        megamanAudio.pitch = Random.Range(0.8f, 1.1f);
        megamanAudio.Play();
    }

}

