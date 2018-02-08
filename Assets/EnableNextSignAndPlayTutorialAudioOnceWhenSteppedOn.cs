using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableNextSignAndPlayTutorialAudioOnceWhenSteppedOn : TriggerIfPlayerEntersAction {
    public AudioClip startingClip = null;
    public AudioSource src;

    public GameObject enableNext = null;

    private bool playedAlready = false;

    public override void performEnterAction(Collider platform, Collider other) {
        if (enableNext != null) {
            enableNext.SetActive(true);
        }
    }

    public override void performExitAction(Collider platform, Collider other) {
    }

    // Use this for initialization
    void Start () {
        if (startingClip != null) {
            src.Stop();
            src.PlayOneShot(startingClip);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
