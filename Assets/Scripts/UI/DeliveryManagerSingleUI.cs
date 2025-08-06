using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DeliveryManagerSingleUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipeNameText;
    [SerializeField] private Transform container;
    [SerializeField] private Transform iconTemplate;


    public void Awake()
    {
        iconTemplate.gameObject.SetActive(false);
    }

    public void SetRecipeName(RecipeSO waitingRecipeSO)
    {
        recipeNameText.text = waitingRecipeSO.recipeName;

        foreach (Transform child in container)
        {
            if (child == iconTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach (KitchenObjectSO kitchenObjectSO in waitingRecipeSO.kitchenObjectSOList)
        {
            Transform iconTransform = Instantiate(iconTemplate, container);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<UnityEngine.UI.Image>().sprite = kitchenObjectSO.sprite;
        }
    }
}
