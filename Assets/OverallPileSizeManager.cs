using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverallPileSizeManager : MonoBehaviour {


    public EnterTriggerChangeTimeSettign currentTimeIntervalHolder;


	// Use this for initialization
	void Start () {
		
	}

    
	
	// Update is called once per frame
	void Update () {

		
	}


    private void FixedUpdate() {
        float timeMultiplier = GetTimeMultiplier();
        metalResizer.scaleToSize = timeMultiplier * standardUnitOfMetalScale;
        plasticResizer.scaleToSize = timeMultiplier * standardUnitOfPlasticScale;
        woodResizer.scaleToSize = timeMultiplier * standardUnitOfWoodScale;
        foodResizer.scaleToSize = timeMultiplier * standardUnitOfFoodScale;
        genericTrashResizer.scaleToSize = timeMultiplier * standardUnitOfGenericScale;
        
    }
    // StandardUnit = 4.5 poudns of the stuff, this is what scale the item should be set to to represent a pile that weighs that much. 
    public float standardUnitOfPlasticScale;
    public float standardUnitOfMetalScale;
    public float standardUnitOfFoodScale;
    public float standardUnitOfWoodScale;

    public float standardUnitOfGenericScale;

    public ResizeAMeScript metalResizer;
    public ResizeAMeScript plasticResizer;
    public ResizeAMeScript foodResizer;
    public ResizeAMeScript woodResizer;

    public ResizeAMeScript genericTrashResizer;

    private float GetTimeMultiplier() {
        TimeIntervals time = currentTimeIntervalHolder.currentTimeInterval;
        switch(time) {
            case TimeIntervals.Day:
                return 1;
            case TimeIntervals.Week:
                return 7;
            case TimeIntervals.Month:
                return 30;
            case TimeIntervals.Year:
                return 365;
            default:
                Debug.Assert(false);
                return 0;
        }
    }
}

