using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject hasProgressGameObject;
    [SerializeField] private Image progressBarImage;

    private IHasProgress hasProgress;
    private void Start()
    {
        hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();
        if (hasProgress == null)
        {
            Debug.LogError("IHasProgress component not found on the specified GameObject.");
            return;
        }

        hasProgress.OnProgressChanged += HasProgress_OnCuttingProgressChanged;
        progressBarImage.fillAmount = 0f; // Initialize progress bar to empty

        Hide(); // Initially hide the progress bar UI
    }

    private void HasProgress_OnCuttingProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        progressBarImage.fillAmount = e.progressNormalized; // Update the progress bar based on the normalized cutting progress

        if (e.progressNormalized == 1f || e.progressNormalized == 0f)
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
