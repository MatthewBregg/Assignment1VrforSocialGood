

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnAwakeFromExistingAudioSource : MonoBehaviour {

    public AudioClip toPlay;
    public AudioSource src;

	// Use this for initialization
	void Start () {
        src.Stop();
        src.PlayOneShot(toPlay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
