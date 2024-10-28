using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    public Light pointLight;       // The light that will flicker
    public float minIntensity = 0.5f; // Minimum light intensity
    public float maxIntensity = 3f;   // Maximum light intensity
    public float flickerSpeed = 0.1f; // Flicker speed

    private float targetIntensity;    // Target intensity
    private float smoothSpeed = 0.5f; // Smoothing speed

    void Start()
    {
        if (pointLight == null)
        {
            pointLight = GetComponent<Light>();
        }
    }

    void Update()
    {
        // Define a random target intensity between the min and max values
        targetIntensity = UnityEngine.Random.Range(minIntensity, maxIntensity); // Use fully qualified name

        // Smoothly transition from the current intensity to the target intensity
        pointLight.intensity = Mathf.Lerp(pointLight.intensity, targetIntensity, smoothSpeed * Time.deltaTime * flickerSpeed);

        pointLight.color = new Color(1f, UnityEngine.Random.Range(0.2f, 0.3f), UnityEngine.Random.Range(0.2f, 0.3f));
    }
}



