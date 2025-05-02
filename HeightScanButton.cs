// HeightScanButton.cs
using UnityEngine;

public class HeightScanButton : MonoBehaviour
{
    public HeightScanner heightScanner;
    public void OnScanHeightClicked()
    {
        if (heightScanner != null)
            heightScanner.ScanUserHeight();
        else
            Debug.LogWarning("HeightScanner not assigned on HeightScanButton.");
    }
}


