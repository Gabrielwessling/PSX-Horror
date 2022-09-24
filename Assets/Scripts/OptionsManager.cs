using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class OptionsManager : MonoBehaviour
{
    GameSettings gameSettings;
    public TMPro.TMP_InputField sensitivityInput;
    public Slider sensitivitySlider;

    void Awake()
    {
        gameSettings = GetComponent<GameSettings>();
    }

    void Start()
    {
        sensitivitySlider.value = gameSettings.mouseSensitivity;
        sensitivityInput.text = gameSettings.mouseSensitivity.ToString("F1");
    }

    // Update is called once per frame
    public void updateSlider(Slider slider)
    {
        if (slider = sensitivitySlider) {
            gameSettings.mouseSensitivity = slider.value;
            sensitivityInput.text = slider.value.ToString("F1");
        }
    }
    public void updateText(TMPro.TMP_InputField _text)
    {
        if (_text = sensitivityInput) {
            gameSettings.mouseSensitivity = float.Parse(_text.text);
            sensitivitySlider.value = float.Parse(_text.text);
        }
    }
}
