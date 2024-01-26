using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixMechanic : MonoBehaviour
{
    // this script checks if something interactable is inside the bowl and if so make it disappear and the object will enter an array for the recipe
    public Transform tpDestination;
    private bool isTp;

    public float waitTime = 2f;


    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable") && !isTp)
        {
            Debug.Log("Interactable inside");
            
            StartCoroutine(TpAfterDelay(other.transform)); //tp item to
        }
    }

    private IEnumerator TpAfterDelay(Transform objectToTeleport)
    {
        isTp = true;

        yield return new WaitForSeconds(waitTime);

        objectToTeleport.position = tpDestination.position;

        isTp = false;
    }
}
