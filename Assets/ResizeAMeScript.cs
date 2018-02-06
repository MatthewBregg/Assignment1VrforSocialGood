using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeAMeScript : MonoBehaviour {

    public float scaleToSize = 1.5f;
	
    public float smoothing = 1f;

    public float adjustYMovementScale = 1f;

    private void FixedUpdate() {
        float targetScalar = scaleToSize;
        Vector3 targetScale = new Vector3(targetScalar, targetScalar, targetScalar);
        Vector3 formerScale = transform.localScale;
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, smoothing * Time.deltaTime);

        float changeInYScale = (transform.localScale - formerScale).y;
        changeInYScale *= adjustYMovementScale;
        float nessecaryChangeInHeight = changeInYScale;

        Vector3 newPosition = transform.position;
        newPosition.y += nessecaryChangeInHeight;

        transform.position = newPosition;
        

    }
}
