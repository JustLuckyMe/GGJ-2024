using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixMechanic : MonoBehaviour
{
    // this script checks if something interactable is inside the bowl and if so make it disappear and go
    public Transform tpDestination;
    public float waitTime;

    private bool isTp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable") && !isTp)
        {
            Debug.Log("Interactable inside");
            
            StartCoroutine(TpAfterDelay(other.transform)); //tp item
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
