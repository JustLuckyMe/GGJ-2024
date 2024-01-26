// MixMechanic.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixMechanic : MonoBehaviour
{
    public Transform tpDestination;
    private bool isTp;

    public float waitTime = 2f;
    public RecipeManager recipeManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable") && !isTp)
        {
            Debug.Log("Interactable inside");

            // Assuming your Interactable script has a list of ingredient names
            Interactable interactable = other.GetComponent<Interactable>();

            if (interactable != null)
            {
                List<string> collectedIngredients = interactable.collectedIngredients;

                // Print out the collected ingredients for debugging
                Debug.Log("Collected Ingredients: " + string.Join(", ", collectedIngredients));

                recipeManager.CheckRecipe(collectedIngredients);

                StartCoroutine(TpAfterDelay(other.transform)); //tp item to
            }
            else
            {
                Debug.LogWarning("Interactable script not found on the object.");
            }
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
