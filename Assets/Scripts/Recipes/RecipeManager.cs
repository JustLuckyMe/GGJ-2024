using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public List<Recipe> recipes;
    public List<string> collectedIngredients = new List<string>();

    public Transform SpawnPosition;

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
                // Recipe matched, spawn the result object
                SpawnResultObject(recipe.resultPrefab);
                // Clear the collected ingredients
                //collectedIngredients.Clear();
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

    private void SpawnResultObject(GameObject resultPrefab)
    {
        // Instantiate the result object at a specific position or use the player's position, for example
        Instantiate(resultPrefab, SpawnPosition.position, Quaternion.identity);
    }
}
