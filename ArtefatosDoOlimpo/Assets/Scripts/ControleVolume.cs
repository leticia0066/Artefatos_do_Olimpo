using UnityEngine;
using UnityEngine.UI;

public class ControleVolume : MonoBehaviour
{
    public Slider slider;


    void Start()
    {
        slider.value = AudioListener.volume;
    }


    public void MudarVolume()
    {
        AudioListener.volume = slider.value;
    }
}