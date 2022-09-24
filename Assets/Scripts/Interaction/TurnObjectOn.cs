using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnObjectOn : MonoBehaviour
{
    public GameObject objectToBeTurned;
    public bool isOn;
    public AudioSource audioOn;
    // Start is called before the first frame update
    void Start()
    {
        if (isOn) {
            audioOn.Play();
            objectToBeTurned.SetActive(true);
        } else {
            audioOn.Stop();
            objectToBeTurned.SetActive(false);
        }
    }

    // Update is called once per frame
    public void _turnObject()
    {
        if (!isOn) {
            audioOn.Play();
            objectToBeTurned.SetActive(true);
            isOn = true;
        } else {
            audioOn.Stop();
            objectToBeTurned.SetActive(false);
            isOn = false;
        }
    }
}
