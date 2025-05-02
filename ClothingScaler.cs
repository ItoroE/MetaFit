using UnityEngine;
using UnityEngine.UI;

public class ClothingScaler : MonoBehaviour
{
    public Slider widthSlider;
    private Transform clothingTarget;

    private float originalWidth;

    void Start()
    {
        if (widthSlider != null)
        {
            widthSlider.onValueChanged.AddListener(OnSliderChanged);
        }
    }

    public void SetClothingTarget(Transform newTarget)
    {
        clothingTarget = newTarget;

        if (clothingTarget != null)
        {
            originalWidth = clothingTarget.localScale.x;
            OnSliderChanged(widthSlider.value); 
        }
    }

    private void OnSliderChanged(float value)
    {
        if (clothingTarget != null)
        {
            Vector3 scale = clothingTarget.localScale;
            scale.x = originalWidth * value; 
            clothingTarget.localScale = scale;
        }
    }
}
