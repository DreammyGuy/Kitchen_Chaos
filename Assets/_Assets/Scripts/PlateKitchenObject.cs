using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;

    private List<KitchenObjectSO> kitchenObjectSOList;
     
    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if (!validKitchenObjectSOList.Contains(kitchenObjectSO))
        {
            // Invalid ingredient for this plate
            return false;
        }
        if (kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            // Ingredient already exists on the plate
            return false;
        } 
        else
        {
            kitchenObjectSOList.Add(kitchenObjectSO);
            return true;
        }
    }
}
