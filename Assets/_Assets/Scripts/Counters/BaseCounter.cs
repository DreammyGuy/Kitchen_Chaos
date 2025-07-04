using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{

    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;

    public virtual void Interact(Player player)
    {
        Debug.LogError("Interacting with BaseCounter");
    }

    public virtual void InteractAlternate(Player player)
    {
        Debug.LogError("AlterateInteracting with BaseCounter");
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }

    public void ClearKitchenObject()
    {
        this.kitchenObject = null;
    }
}
