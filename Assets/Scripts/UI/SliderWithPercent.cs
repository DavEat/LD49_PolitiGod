using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderWithPercent : MonoBehaviour
{
    Slider m_slider;
    [SerializeField] TextMeshProUGUI m_text;

    void Awake()
    {
        m_slider = GetComponent<Slider>();
        m_slider.onValueChanged.AddListener(delegate { UpdateText(); });
    }
    void UpdateText()
    {
        m_text.text = (m_slider.value * 100).ToString("F0") + "%";
    }
}