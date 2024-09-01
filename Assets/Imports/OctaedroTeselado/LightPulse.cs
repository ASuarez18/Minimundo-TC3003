using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour
{
    private Light light;
    public float minIntensity = 1.0f; // Intensidad m�nima
    public float maxIntensity = 4.0f; // Intensidad m�xima
    public float pulseSpeed = 1.0f; // Velocidad del pulso

    private float initialIntensity;

    void Start()
    {
        light = GetComponentInChildren<Light>();
        initialIntensity = light.intensity;
    }

    void Update()
    {
        // Calcular la nueva intensidad usando una funci�n sinusoidal
        float newIntensity = minIntensity + Mathf.PingPong(Time.time * pulseSpeed, maxIntensity - minIntensity);
        light.intensity = newIntensity;
    }
}
