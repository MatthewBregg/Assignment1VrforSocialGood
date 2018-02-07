﻿using System.Collections;
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

    private float Cube(float input) {
        return input * input * input;
    }
    private float CubeRoot(float input) {
        return Mathf.Pow(input, 1f / 3.33333333f);
    }

    private float GivenStandardUnitScaleAndDesiredMultiplierObtainNewScale(float SSScale, float multiplier) {
        return CubeRoot((Cube(SSScale) * multiplier));
    }
    private void FixedUpdate() {
        float timeMultiplier = GetTimeMultiplier();

        float metalMultiplier = timeMultiplier * percentageTrashMetal;
        float plasticMultiplier = timeMultiplier * percentageTrashPlastic;
        float woodMultiplier = timeMultiplier * percentageTrashWood;
        float foodMultiplier = timeMultiplier * percentageTrashFood;
        float otherMultiplier = timeMultiplier * percentageTrashOther;
   
        float genericGarbageMultiplier = timeMultiplier;

        if ( composting ) {
            genericGarbageMultiplier *= (1.0f - percentageTrashFood); // We don't need to modify any aside generic, as we just remove the food pile othersise;
        }

        if ( bioplastic ) {
            genericGarbageMultiplier *= 1.0f - percentageTrashPlastic;
        }

        if ( recycling ) {

            // All the following recycling statistics come from here
            // https://archive.epa.gov/epawaste/nonhaz/municipal/web/html/
            if (composting) {
                genericGarbageMultiplier *= (1.0f - ((.343f + percentageTrashFood) - (.343f * .28f))); // This is only recycling, not composting!! 
            } else if ( composting && bioplastic ) {
                genericGarbageMultiplier *= (1.0f - ((.343f + percentageTrashPlastic + percentageTrashFood) - (.343f * .13f)) - (.343f * .28f)); 
            } else if ( bioplastic ) {
                genericGarbageMultiplier *= (1.0f - ((.343f + percentageTrashPlastic) - (.343f * .13f)));
            }
            else {
                genericGarbageMultiplier *= (1.0f - (.343f));
            }
           
            woodMultiplier *= (1.0f - (.343f*.60f));
            metalMultiplier *= (1.0f - (.343f * .09f));
            plasticMultiplier *= (1.0f - (.343f * .13f));
            foodMultiplier *= (1.0f - (.343f * .28f)); //Hmm this, one is a bit off, need to revist it.
            otherMultiplier *= (1.0f - (.343f * .17f));

        }

        // Find the current cubic volume, increase that volume by however much we want, and then calculate our new scale factor to acheive that volume.
        genericTrashResizer.scaleToSize = GivenStandardUnitScaleAndDesiredMultiplierObtainNewScale(standardUnitOfGenericVol, genericGarbageMultiplier);

        metalResizer.scaleToSize = GivenStandardUnitScaleAndDesiredMultiplierObtainNewScale(standardUnitOfMetalVol, metalMultiplier);
        plasticResizer.scaleToSize = GivenStandardUnitScaleAndDesiredMultiplierObtainNewScale(standardUnitOfPlasticVol, plasticMultiplier);
        woodResizer.scaleToSize = GivenStandardUnitScaleAndDesiredMultiplierObtainNewScale(standardUnitOfWoodVol, woodMultiplier);
        foodResizer.scaleToSize = GivenStandardUnitScaleAndDesiredMultiplierObtainNewScale(standardUnitOfFoodVol, foodMultiplier);
        otherResizer.scaleToSize = GivenStandardUnitScaleAndDesiredMultiplierObtainNewScale(standardUnitOfOtherVol, otherMultiplier);

        


    }
    // StandardUnit = 4.5 poudns of the stuff, this is what scale the item should be set to to represent a pile that weighs that much. 
    public float standardUnitOfPlasticVol;
    public float standardUnitOfMetalVol;
    public float standardUnitOfFoodVol;
    public float standardUnitOfWoodVol;
    public float standardUnitOfOtherVol;

    public float percentageTrashPlastic;
    public float percentageTrashMetal;
    public float percentageTrashFood;
    public float percentageTrashWood;
    public float percentageTrashOther;

    public float standardUnitOfGenericVol;

    public ResizeAMeScript metalResizer;
    public ResizeAMeScript plasticResizer;
    public ResizeAMeScript foodResizer;
    public ResizeAMeScript woodResizer;
    public ResizeAMeScript otherResizer;

    public ResizeAMeScript genericTrashResizer;
    public bool composting;
    public bool recycling;
    public bool bioplastic;

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

