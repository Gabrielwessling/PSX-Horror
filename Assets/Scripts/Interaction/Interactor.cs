using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    public LayerMask interactableLayermask = 8;
    public float interactDistance;
    public Camera cam;
    UnityEvent OnInteract;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactDistance, interactableLayermask))
        {
            if(hit.collider.GetComponent<Interactable>() != false)
            {
                OnInteract = hit.collider.GetComponent<Interactable>().OnInteract;
                if (Input.GetButtonDown("Interact")){
                    OnInteract.Invoke();
                }
            }
        }
    }
}
