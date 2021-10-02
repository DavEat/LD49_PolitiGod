using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfosManager : Singleton<InfosManager>
{
    [SerializeField] float m_happiness = .5f;
    [SerializeField] float m_education = .5f;
    [SerializeField] float m_crimerate = .1f;
    [SerializeField] float m_poverty = .1f;

    [SerializeField] float m_floodChance = .1f;
    [SerializeField] float m_healthCrisis = .1f;
    [SerializeField] float m_manifestion = .01f;

    bool m_evacuated = false;
    bool m_confined = false;
    bool m_canProtest = true;

    public bool evacuated => m_evacuated;
    public bool confined => m_confined;
    public bool canProtest => m_canProtest;

    [SerializeField] Slider m_slider_happiness;
    [SerializeField] Slider m_slider_education;
    [SerializeField] Slider m_slider_crimerate;
    [SerializeField] Slider m_slider_poverty;
    
    [SerializeField] Slider m_slider_floodChance;
    [SerializeField] Slider m_slider_healthCrisis;
    [SerializeField] Slider m_slider_manifestion;

    void Start()
    {
        GameManager.inst.tick += OnTick;

        UpdateSliders();
    }

    void UpdateSliders()
    {
        m_slider_happiness.value = m_happiness;
        m_slider_education.value = m_education;
        m_slider_crimerate.value = m_crimerate;
        m_slider_poverty.value = m_poverty;

        m_slider_floodChance.value = m_floodChance;
        m_slider_healthCrisis.value = m_healthCrisis;
        m_slider_manifestion.value = m_manifestion;
    }

    void OnTick(int cycleNumber)
    {

    }

    public void SetEvacuated(bool value)
    {
        m_evacuated = value;
    }
    public void SetConfined(bool value)
    {
        m_confined = value;
    }
    public void SetCanProtest(bool value)
    {
        m_canProtest = value;
    }
}