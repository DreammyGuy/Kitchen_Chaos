using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private CuttingCounter cuttingCounter;
    [SerializeField] private Image progressBarImage;

    private void Start()
    {
        cuttingCounter.OnCuttingProgressChanged += CuttingCounter_OnCuttingProgressChanged;
        progressBarImage.fillAmount = 0f; // Initialize progress bar to empty

        Hide(); // Initially hide the progress bar UI
    }

    private void CuttingCounter_OnCuttingProgressChanged(object sender, CuttingCounter.OnCuttingProgressChangedEventArgs e)
    {
        progressBarImage.fillAmount = e.cuttingProgressNormalized; // Update the progress bar based on the normalized cutting progress

        if (e.cuttingProgressNormalized == 1f || e.cuttingProgressNormalized == 0f)
        {
            Hide(); // Hide the progress bar when cutting is complete
        }
        else
        {
            Show(); // Show the progress bar while cutting is in progress
        }
    }

    private void Show()
    {
        gameObject.SetActive(true); // Show the progress bar UI
    }

    private void Hide()
    {
        gameObject.SetActive(false); // Hide the progress bar UI
    }

}
