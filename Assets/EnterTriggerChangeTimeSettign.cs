using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TimeIntervals { Day, Month, Week, Year };

public class EnterTriggerChangeTimeSettign : TriggerIfPlayerEntersAction {
    // Set this to whatever default we choose, I'm going to go with day. 
    public TimeIntervals currentTimeInterval;

    public GameObject week;
    public GameObject day;
    public GameObject year;
    public GameObject month;

    public override void performEnterAction(Collider platform, Collider other) {
        switch (currentTimeInterval) {
            case TimeIntervals.Day:
                currentTimeInterval = TimeIntervals.Week;
                day.SetActive(false);
                week.SetActive(true);
                break;
            case TimeIntervals.Month:
                month.SetActive(false);
                day.SetActive(true);
                currentTimeInterval = TimeIntervals.Day;
                break;
            case TimeIntervals.Week:
                week.SetActive(false);
                month.SetActive(true);
                currentTimeInterval = TimeIntervals.Month;
                break;
        }
    }

    public override void performExitAction(Collider platform, Collider other) {
        
    }
}
