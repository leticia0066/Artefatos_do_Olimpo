using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMax(int value)
    {
        slider.maxValue = value;
        slider.value = value;
    }

    public void Set(int value)
    {
        slider.value = value;
    }
}