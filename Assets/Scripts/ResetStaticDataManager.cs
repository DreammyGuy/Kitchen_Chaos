using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStaticDataManager : MonoBehaviour
{
   private void Awake()
   {
        // Reset the static data manager to its initial state
        BaseCounter.ResetStaticData();
        TrashCounter.ResetStaticData();
        CuttingCounter.ResetStaticData();
    }
}
