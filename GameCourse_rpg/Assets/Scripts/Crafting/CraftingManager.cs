using System.Linq;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    [SerializeField] Recipe[] _recipes;

    public void TryCrafting()
    {
        int itemsInCraftingInventory = Inventory.Instance.CraftingSlots
            .Count(t => t.IsEmpty == false);
        Debug.Log($"Trying to craft with {itemsInCraftingInventory}");
        foreach (var recipe in _recipes)
        {
            if (IsMacthingRecipe(recipe, Inventory.Instance.CraftingSlots))
            {
                Debug.Log($"Found thee recipe{recipe.name}");
                return;
            }
        }
    }

    bool IsMacthingRecipe(Recipe recipe, ItemSlot[] instanceCraftingSlots)
    {
        for (int i = 0; i < recipe.Ingredients.Count; i++)
        {
            if (recipe.Ingredients[i] != instanceCraftingSlots[i].Item)
                return false;
        }

        return true;
    }

    void OnValidate() => _recipes = Extensions.GetAllInstances<Recipe>();
}
