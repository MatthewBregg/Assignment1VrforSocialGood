using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
abstract public class TriggerIfPlayerEntersAction : MonoBehaviour {
    public abstract void performEnterAction(Collider platform, Collider other);
    public abstract void performExitAction(Collider platform, Collider other);
};

// Looks for any attached trigger if player enters action types, and runs them all.
public class TriggerIfPlayerEnters : MonoBehaviour {
    private TriggerIfPlayerEntersAction[] actions;
    // Use this for initialization
    void Start () {
		actions = GetComponents<TriggerIfPlayerEntersAction>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    bool playerInside = false;
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" ) {
            foreach (TriggerIfPlayerEntersAction action in actions ) {
                action.performEnterAction(this.GetComponent<Collider>(), other);
            }
            playerInside = true; // Do this to avoid running our actions repeadetly!
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            playerInside = false;
            foreach (TriggerIfPlayerEntersAction action in actions) {
                action.performExitAction(this.GetComponent<Collider>(), other);
            }
        }
        
    }
}
