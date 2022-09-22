using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public FirstPersonMovement FPMScript;
    public Jump jumpScript;
    public Animator johnAnimator;
    public float velocityDebug;
    public float velocityTotal;
    public bool isJumping;
    public bool isInteracting;

    // Start is called before the first frame update
    void Awake()
    {
        FPMScript = GetComponent<FirstPersonMovement>();
        jumpScript = GetComponent<Jump>();
        johnAnimator = GetComponentInChildren<Animator>();
    }
    void FixedUpdate()
    {
        if (!jumpScript.groundCheck.isGrounded){
            isJumping = true;
        } else {
            isJumping = false;
        }
        velocityTotal = FPMScript.rigidbody.velocity.magnitude;
        velocityTotal = Mathf.Round(velocityTotal * 100f) / 100f;
        velocityDebug = velocityTotal;
        johnAnimator.SetFloat("Velocity", velocityTotal);
        johnAnimator.SetBool("isJumping", isJumping);
        if (isInteracting){
            _interact();
        }
    }
    public void _interact()
    {
        johnAnimator.SetTrigger("Interact");
        isInteracting = false;
    }
}
