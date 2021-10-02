using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderTextControler : MonoBehaviour
{
    [SerializeField] string m_unit = "";
    [SerializeField] TextMeshProUGUI m_value;
    [SerializeField] Slider m_slider;
    [SerializeField] UnityEvent onChange;

    void Awake()
    {
        m_slider.onValueChanged.AddListener(delegate { SliderUpdated(); });
        SliderUpdated();
    }
    void SetValueText()
    {
        m_value.text = m_slider.value + m_unit;
    }
    void SliderUpdated()
    {
        SetValueText();
        onChange?.Invoke();
    }
}