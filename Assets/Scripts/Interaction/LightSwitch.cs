using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LightSwitch : MonoBehaviour
{
    public Light lightsource;
    public GameObject lightbulb;
    public bool hasVideo;
    public VideoPlayer vidPlayer;
    public bool isOn;

    Material lightMat;

    void Awake()
    {
        lightMat = lightbulb.GetComponent<Renderer>().materials[1];
        if (isOn){
            lightsource.enabled = true;
            lightMat.SetColor("_EmissionColor", Color.white);
            vidPlayer.Play();
        } else {
            lightsource.enabled = false;
            lightMat.SetColor("_EmissionColor", Color.black);
            vidPlayer.Stop();
        }
    }

    public void _turnLight()
    {
        if (isOn){
            lightsource.enabled = false;
            lightMat.SetColor("_EmissionColor", Color.black);
            isOn = false;
            vidPlayer.Stop();
        } else {
            lightsource.enabled = true;
            lightMat.SetColor("_EmissionColor", Color.white);
            isOn = true;
            vidPlayer.Play();
        }
    }
}
