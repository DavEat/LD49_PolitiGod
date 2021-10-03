using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfosManager : Singleton<InfosManager>
{
    //---default---
    [HideInInspector] public int m_approbation = 51;
 
    [HideInInspector] public int m_happiness = 50;
    [HideInInspector] public int m_education = 50;
    [HideInInspector] public int m_crimerate = 11;
    [HideInInspector] public int m_poverty = 10;

    [HideInInspector] public int m_floodChance = 10;
    [HideInInspector] public int m_healthCrisis = 10;
    [HideInInspector] public int m_demonstration = 11;

    [HideInInspector] public bool doingPropaganda = false;

    //---max---
    int m_max_approbation = 100;

    int m_max_happiness = 80;
    int m_max_education = 100;
    int m_max_crimerate = 49;
    int m_max_poverty = 25;

    int m_max_floodChance = 100;
    int m_max_healthCrisis = 80;
    int m_max_demonstration = 100;

    //---modifiers---
    int m_approbation_modifier;

    int m_happiness_modifier;
    int m_education_modifier;
    int m_crimerate_modifier;
    int m_poverty_modifier;

    int m_floodChance_modifier;
    int m_healthCrisis_modifier;
    int m_demonstration_modifier;
    
    bool m_evacuated = false;
    bool m_confined = false;
    bool m_canProtest = true;

    public bool evacuated => m_evacuated;
    public bool confined => m_confined;
    public bool canProtest => m_canProtest;

    [SerializeField] TextMeshProUGUI m_approvalText;

    [SerializeField] TextMeshProUGUI m_text_electionIn;
    [SerializeField] Slider m_slider_electionIn;

    [SerializeField] Slider m_slider_happiness = null;
    [SerializeField] Slider m_slider_education = null;
    [SerializeField] Slider m_slider_crimerate = null;
    [SerializeField] Slider m_slider_poverty = null;
    
    [SerializeField] Slider m_slider_floodChance = null;
    [SerializeField] Slider m_slider_healthCrisis = null;
    [SerializeField] Slider m_slider_manifestion = null;

    void Start()
    {
        GameManager.inst.tick += OnTick;

        UpdateSliders(1);
    }

    void OnTick(int cycleNumber)
    {
        UpdateStats();
        CalculateBaseValue();

        UpdateSliders(cycleNumber);
    }

    void UpdateSliders(int cycleNumber)
    {
        m_slider_happiness.value = ((m_happiness) / (float)m_max_happiness);
        m_slider_education.value = ((m_education) / (float)m_max_education);
        m_slider_crimerate.value = ((m_crimerate) / (float)m_max_crimerate);
        m_slider_poverty.value = ((m_poverty) / (float)m_max_poverty);

        m_slider_floodChance.value = ((m_floodChance) / (float)m_max_floodChance);
        m_slider_healthCrisis.value = ((m_healthCrisis) / (float)m_max_healthCrisis);
        m_slider_manifestion.value = ((m_demonstration) / (float)m_max_demonstration);

        int remainingdays = GameManager.inst.electionEvery - (cycleNumber % GameManager.inst.electionEvery);
        m_text_electionIn.text = remainingdays.ToString();
        m_slider_electionIn.value = 1 - remainingdays / (float)GameManager.inst.electionEvery;

        m_approvalText.text = m_approbation.ToString() + "%";
    }

    void UpdateStats()
    {
        Events.EffectManager.inst.effects.TryGetValue(Events.EffectOn.happiness, out m_happiness_modifier);
        Events.EffectManager.inst.effects.TryGetValue(Events.EffectOn.eduction, out m_education_modifier);
        Events.EffectManager.inst.effects.TryGetValue(Events.EffectOn.crime, out m_crimerate_modifier);
        Events.EffectManager.inst.effects.TryGetValue(Events.EffectOn.poverty, out m_poverty_modifier);

        Events.EffectManager.inst.effects.TryGetValue(Events.EffectOn.flood, out m_floodChance_modifier);
        Events.EffectManager.inst.effects.TryGetValue(Events.EffectOn.heath, out m_healthCrisis_modifier);
        Events.EffectManager.inst.effects.TryGetValue(Events.EffectOn.demonstration, out m_demonstration_modifier);

        Events.EffectManager.inst.effects.TryGetValue(Events.EffectOn.approbation, out m_approbation_modifier);
    }

    public void CalculateBaseValue()
    {
        m_poverty = 0; //max = 10 + 15 = 25
        if (FinancesManager.inst.taxesFood > 1)
            m_poverty += Mathf.Abs(FinancesManager.inst.taxesFood);
        if (FinancesManager.inst.taxesGoods > 1)
            m_poverty += Mathf.Abs(FinancesManager.inst.taxesGoods);

        if (FinancesManager.inst.subsSchools <= 0)
            m_poverty += Mathf.Abs(FinancesManager.inst.subsSchools) + 1;
        if (FinancesManager.inst.subsTransport <= 0)
            m_poverty += Mathf.Abs(FinancesManager.inst.subsTransport) + 1;
        if (FinancesManager.inst.subsHeath <= 0)
            m_poverty += Mathf.Abs(FinancesManager.inst.subsHeath) + 1;
        m_poverty += m_poverty_modifier;

        m_crimerate = m_poverty - FinancesManager.inst.subsPolice * 4; //max = 49
        m_crimerate += m_crimerate_modifier;

        m_education = 0 + m_education_modifier;

        int happiness = 10 + (int)((m_education_modifier / (float)m_max_education) * 60) + (FinancesManager.inst.outs - FinancesManager.inst.ins / 2);
        if (FinancesManager.inst.outs >= FinancesManager.inst.ins)
            happiness += 5;
        if (!m_canProtest)
            happiness += -20;
        m_happiness = ((happiness) - (int)((m_poverty / (float) m_max_poverty) * 100)) - (int)((m_crimerate / (float)m_max_crimerate) * 20);
        m_happiness += doingPropaganda ? -5 : 0;
        m_happiness += m_happiness_modifier;

        m_healthCrisis = (m_max_healthCrisis / 2) - FinancesManager.inst.subsHeath; //max 80
        m_healthCrisis += m_healthCrisis_modifier;

        m_demonstration = Mathf.FloorToInt((((m_poverty / (float)m_max_poverty) + (m_happiness / (float)m_max_happiness)) - (FinancesManager.inst.subsPolice / 6f)) * 100);
        if (!m_canProtest)
            m_demonstration += 10;
        m_demonstration += doingPropaganda ? -10 : 0;
        m_demonstration += m_demonstration_modifier;

        m_approbation = (int)((m_happiness / (float)m_max_happiness) * 100) - (int)((m_demonstration / (float)m_max_demonstration) * 50);
        m_demonstration += doingPropaganda ? 15 : 0;
        m_approbation += m_approbation_modifier;
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

    public void EducationDay(int cycleNumber, int educationDayDelay)
    {
        int educationValue = 0;
        if (FinancesManager.inst.subsSchools <= -2)
            educationValue = 6;
        else if (FinancesManager.inst.subsSchools <= 0)
            educationValue = 10;
        else if (FinancesManager.inst.subsSchools <= 2)
            educationValue = 22;
        else if (FinancesManager.inst.subsSchools <= 4)
            educationValue = 32;
        else if (FinancesManager.inst.subsSchools <= 7)
            educationValue = 42;
        else if (FinancesManager.inst.subsSchools <= 8)
            educationValue = 52;
        else if (FinancesManager.inst.subsSchools <= 9)
            educationValue = 58;

        Events.Effect effOne = new Events.Effect(cycleNumber, educationDayDelay,
            new Dictionary<Events.EffectOn, int>() { { Events.EffectOn.eduction, educationValue / 2 } });

        Events.Effect effTwo = new Events.Effect(cycleNumber + educationDayDelay, educationDayDelay,
            new Dictionary<Events.EffectOn, int>() { { Events.EffectOn.eduction, educationValue } });

        Events.EffectManager.inst.AddEffect(effOne);
        Events.EffectManager.inst.AddEffect(effTwo);
    }
}