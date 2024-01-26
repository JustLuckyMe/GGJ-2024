using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe
{
    public string name;
    public List<string> requiredIngredients;
    public GameObject resultPrefab; // The result object to spawn when the recipe is completed
}

