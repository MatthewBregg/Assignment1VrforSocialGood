using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGenericRecycling : TriggerIfPlayerEntersAction {

    public OverallPileSizeManager pileSizeManager;

    public GameObject No;
    public GameObject Yes;
    public override void performEnterAction(Collider platform, Collider other) {
        pileSizeManager.recycling = !pileSizeManager.recycling;
        No.SetActive(!pileSizeManager.recycling);
        Yes.SetActive(pileSizeManager.recycling);
    }

    public override void performExitAction(Collider platform, Collider other) {
       
    }
}


