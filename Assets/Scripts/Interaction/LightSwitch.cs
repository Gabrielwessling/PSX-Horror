using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light lightsource;
    public GameObject lightbulb;
    public bool isOn;

    Material lightMat;

    void Awake()
    {
        lightMat = lightbulb.GetComponent<Renderer>().materials[1];
        if (isOn){
            lightsource.enabled = true;
            lightMat.SetColor("_EmissionColor", Color.white);
        } else {
            lightsource.enabled = false;
            lightMat.SetColor("_EmissionColor", Color.black);
        }
    }

    public void _turnLight()
    {
        if (isOn){
            lightsource.enabled = false;
            lightMat.SetColor("_EmissionColor", Color.black);
            isOn = false;
        } else {
            lightsource.enabled = true;
            lightMat.SetColor("_EmissionColor", Color.white);
            isOn = true;
        }
    }
}
