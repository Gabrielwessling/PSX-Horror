using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoController : MonoBehaviour
{
    public Light flashlight;
    public bool flashOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Flashlight")){
            if (flashOn){
                flashOn = false;
                flashlight.gameObject.SetActive(false);
            } else {
                flashOn = true;
                flashlight.gameObject.SetActive(true);
            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
