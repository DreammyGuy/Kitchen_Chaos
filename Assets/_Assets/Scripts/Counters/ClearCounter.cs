using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // There is no kitchen object on ClearCounter
            if (player.HasKitchenObject())
            {
                // Player has a kitchen object
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                // Player has no kitchen object
            }
        }
        else
        {
            // There is a kitchen object on ClearCounter
            if (player.HasKitchenObject())
            {
                // Player has a kitchen object
            }
            else
            {
                // Player has no kitchen object
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
