using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyUseBioPlastics : TriggerIfPlayerEntersAction {

    public OverallPileSizeManager pileSizeManager;
    public GameObject pilePlastic;
    public GameObject No;
    public GameObject Yes;
    public override void performEnterAction(Collider platform, Collider other) {
        pileSizeManager.bioplastic = !pileSizeManager.bioplastic;
        No.SetActive(!pileSizeManager.bioplastic);
        Yes.SetActive(pileSizeManager.bioplastic);
        pilePlastic.SetActive(!pilePlastic.activeSelf);
    }

    public override void performExitAction(Collider platform, Collider other) {

    }
}



