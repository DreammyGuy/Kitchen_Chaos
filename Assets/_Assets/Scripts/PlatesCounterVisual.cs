using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private Transform plateVisualPrefab;
    [SerializeField] private PlatesCounter platesCounter;

    private List<GameObject> plateVisualTransformList;


    private void Awake()
    {
        plateVisualTransformList = new List<GameObject>();
    }
    private void Start()
    {
        platesCounter.OnPlateSpawned += PlatesCounter_OnPlateSpawned;
        platesCounter.OnPlateRemoved += PlatesCounter_OnPlateRemoved;
    }

    private void PlatesCounter_OnPlateRemoved(object sender, EventArgs e)
    {
        GameObject lastPlateVisual = plateVisualTransformList[plateVisualTransformList.Count - 1];
        plateVisualTransformList.RemoveAt(plateVisualTransformList.Count - 1);
        Destroy(lastPlateVisual);
    }

    private void PlatesCounter_OnPlateSpawned(object sender, EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(plateVisualPrefab, counterTopPoint);

        float plateVisualOffsetY = 0.1f;
        plateVisualTransform.localPosition = new Vector3(0f, plateVisualTransformList.Count * plateVisualOffsetY, 0f);
        plateVisualTransformList.Add(plateVisualTransform.gameObject);
    }
}
