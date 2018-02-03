using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnterTriggerConsoleDebugAction2 : TriggerIfPlayerEntersAction {
    public override void performEnterAction(Collider platform, Collider other) {
        Debug.Log("player entered 2");
    }

    public override void performExitAction(Collider platform, Collider other) {
        Debug.Log("player left 2");
    }
}
