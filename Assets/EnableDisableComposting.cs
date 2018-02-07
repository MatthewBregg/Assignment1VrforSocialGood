using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableComposting : TriggerIfPlayerEntersAction {
    public GameObject foodTrashPile;
    public OverallPileSizeManager pileSizeManager;

    public GameObject No;
    public GameObject Yes;
    public override void performEnterAction(Collider platform, Collider other) {
        pileSizeManager.composting = !pileSizeManager.composting;
        foodTrashPile.SetActive(!foodTrashPile.activeSelf);
        No.SetActive(!pileSizeManager.composting);
        Yes.SetActive(pileSizeManager.composting);
    }

    public override void performExitAction(Collider platform, Collider other) {
    }

}
