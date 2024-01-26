using UnityEngine;
using System.Collections;

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

            // Assuming there's a script on the Interactable object to get the ingredient name
            string ingredientName = other.GetComponent<Ingredient>().ingredientName;

            recipeManager.AddIngredient(ingredientName);
            recipeManager.CheckRecipe();

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
