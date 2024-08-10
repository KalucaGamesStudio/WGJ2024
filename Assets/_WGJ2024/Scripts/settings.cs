using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class settings : MonoBehaviour
{
    [Header("Light")]
    public Slider LightSlider;
    public float ValueLightSlider;
    public Image PanelLight;

    [Header("Volumen")]
    public Slider VolumenSlider;
    public float ValueVolSlider;
    public Image _Mute;
    public AudioSource Ambiental;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        //Volumen
        VolumenSlider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = VolumenSlider.value;
        Mute();
        Ambiental.Play();
        //Light
        LightSlider.value = 0;
        ValueLightSlider = 0;
        PanelLight.color = new Color(PanelLight.color.r, PanelLight.color.g, PanelLight.color.b, LightSlider.value);

    }

    public void SliderChange(float valor)
    {
        ValueVolSlider = valor;
        PlayerPrefs.SetFloat("volumenAudio", ValueVolSlider);
        AudioListener.volume = VolumenSlider.value;
        Mute();

    }
    public void Mute()
    {
        if (ValueVolSlider == 0)
        {
            _Mute.enabled = true;

        }
        else
        {
            _Mute.enabled = false;
        }

    }
    public void SliderChangeLight(float valor)
    {

        ValueLightSlider = valor;
        PlayerPrefs.SetFloat("brillo", ValueLightSlider);
        PanelLight.color = new Color(PanelLight.color.r, PanelLight.color.g, PanelLight.color.b, LightSlider.value);
    }
    
}
