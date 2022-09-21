using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public bool isOpen;
    public Quaternion transformOpen;
    public Quaternion transformClosed;

    // Start is called before the first frame update
    void Awake()
    {
        if (isOpen){
            transformOpen = transform.localRotation;
        } else {
            transformClosed = transform.localRotation;
        }
    }

    // Update is called once per frame
    public void _OpenDoor()
    {
        if (isOpen){
            transform.localRotation = transformClosed;
            isOpen = false;
        } else {
            transform.localRotation = transformOpen;
            isOpen = true;
        }
    }
}
