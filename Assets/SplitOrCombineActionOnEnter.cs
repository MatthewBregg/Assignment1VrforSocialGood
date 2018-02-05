using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitOrCombineActionOnEnter : TriggerIfPlayerEntersAction {
    public GameObject combinedPile;
    public GameObject splitPile;
    public override void performEnterAction(Collider platform, Collider other) {
       if ( splitPile.activeSelf ) {
            splitPile.SetActive(false);
            combinedPile.SetActive(true);
        } else {
            splitPile.SetActive(true);
            combinedPile.SetActive(false);
        }
    }

    public override void performExitAction(Collider platform, Collider other) {
     
    }

}
