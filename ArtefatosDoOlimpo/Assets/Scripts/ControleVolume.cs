using UnityEngine;
using UnityEngine.UI;

public class ControleVolume : MonoBehaviour
{
    public Slider sliderVolume;

    void Start()
    {
        sliderVolume.value = AudioListener.volume;
    }

    public void AlterarVolume()
    {
        AudioListener.volume = sliderVolume.value;
    }
}