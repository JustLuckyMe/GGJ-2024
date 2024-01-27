using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMicrowave : MonoBehaviour
{
    Animator m_Animator;

    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            //Send the message to the Animator to activate the trigger parameter named "Crouch"
            m_Animator.SetBool("isOpen", true);
        }
    }
}
