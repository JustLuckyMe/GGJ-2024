using UnityEngine;

public class ToggleAnimation : MonoBehaviour
{
    private Animator m_animator;
    private bool isOpen = false;

    private void Start()
    {
        // Assuming the Animator is attached to the same GameObject
        m_animator = GetComponent<Animator>();

        if (m_animator == null)
        {
            Debug.LogError("Animator component not found on the GameObject.");
        }
    }

    public void OpenAnimation()
    {
        if(isOpen == false)
        {
            isOpen = !isOpen;
            m_animator.SetBool("isOpen", isOpen);
            
        }
        else
        {
            if (isOpen)
            {
                isOpen = !isOpen;
                m_animator.SetBool("isOpen", isOpen);

            }
        }
    }
}
