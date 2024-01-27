using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public List<Recipe> recipes;
    public List<string> collectedIngredients = new List<string>();
    public Transform playerHand; // Reference to the player's hand

    public void SetPlayerHand(Transform hand)
    {
        playerHand = hand;
    }

    public void AddIngredient(string ingredientName)
    {
        collectedIngredients.Add(ingredientName);
    }

    public void CheckRecipe()
    {
        foreach (Recipe recipe in recipes)
        {
            if (CheckIfRecipeMatches(recipe))
            {
                // Recipe matched, spawn the result object in the player's hand
                SpawnResultObjectInHand(recipe.resultPrefab);
                // Clear the collected ingredients
                collectedIngredients.Clear();
                // You can add additional logic here, like playing a sound or showing a message
            }
        }
    }

    private bool CheckIfRecipeMatches(Recipe recipe)
    {
        // Check if collected ingredients match the required ingredients of the recipe
        return recipe.requiredIngredients.Count == collectedIngredients.Count &&
               recipe.requiredIngredients.TrueForAll(collectedIngredients.Contains);
    }

    private void SpawnResultObjectInHand(GameObject resultPrefab)
    {
        // Instantiate the result object at the player's hand position
        Instantiate(resultPrefab, playerHand.position, playerHand.rotation);
    }
}
