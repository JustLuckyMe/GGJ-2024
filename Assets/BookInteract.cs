using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteract : MonoBehaviour
{
    [SerializeField] GameObject BookUI;
    [SerializeField] GameObject BookOnCounter;
    
    private bool isShown = false;

    public void OpenBook()
    {
        if(isShown == false)
        {
            Debug.Log("Player opened book");
            BookUI.SetActive(true);
            BookOnCounter.SetActive(false);
            isShown = true;
        }
        else
        {
            Debug.Log("Book is already shown");
        }
    }

    private void Update()
    {
        if (isShown && Input.GetKeyDown(KeyCode.E))
        {
            BookUI.SetActive(false);
            BookOnCounter.SetActive(true);
            isShown = false;
        }
    }
}
