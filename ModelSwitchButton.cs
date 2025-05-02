
using UnityEngine;

public class ModelSwapButton : MonoBehaviour
{
    public MeshController meshController;
    public void OnNextModelClicked()
    {
        if (meshController != null)
            meshController.SwitchToNextModel();
        else
            Debug.LogWarning("MeshController not assigned on ModelSwapButton.");
    }
}



