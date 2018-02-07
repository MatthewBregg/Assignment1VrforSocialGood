using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TimeIntervals { Day, Month, Week, Year, FiveYears };

public class EnterTriggerChangeTimeSettign : TriggerIfPlayerEntersAction {
    // Set this to whatever default we choose, I'm going to go with day. 
    public TimeIntervals currentTimeInterval;

    public GameObject week;
    public GameObject day;
    public GameObject year;
    public GameObject month;
    public GameObject fiveYear;

    public override void performEnterAction(Collider platform, Collider other) {
        switch (currentTimeInterval) {
            case TimeIntervals.Day:
                currentTimeInterval = TimeIntervals.Week;
                day.SetActive(false);
                week.SetActive(true);
                break;
            case TimeIntervals.Month:
                month.SetActive(false);
                year.SetActive(true);
                currentTimeInterval = TimeIntervals.Year;
                break;
            case TimeIntervals.Week:
                week.SetActive(false);
                month.SetActive(true);
                currentTimeInterval = TimeIntervals.Month;
                break;
            case TimeIntervals.Year:
                year.SetActive(false);
                fiveYear.SetActive(true);
                currentTimeInterval = TimeIntervals.FiveYears;
                break;
            case TimeIntervals.FiveYears:
                fiveYear.SetActive(false);
                day.SetActive(true);
                currentTimeInterval = TimeIntervals.Day;
                break;
        }
    }

    public override void performExitAction(Collider platform, Collider other) {
        
    }
}
