using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinancesManager : Singleton<FinancesManager>
{
    [SerializeField] int m_balance;
    public int balance => m_balance;
    [SerializeField] string m_balanceUnit = "h";
    [SerializeField] TextMeshProUGUI m_balanceText;
    [SerializeField] Transform m_balanceArrow;

    //ins
    short m_worshipTime;
    short m_taxesFood;
    short m_taxesGoods;
    //outs
    short m_subsSchools;
    short m_subsTransport;
    short m_subsHeath;
    short m_subsPolice;

    [HideInInspector] public bool haveChurch = false;

    //ins
    public short worshipTime => m_worshipTime;
    public short taxesFood => m_taxesFood;
    public short taxesGoods => m_taxesGoods;
    //outs
    public short subsSchools => m_subsSchools;
    public short subsTransport => m_subsTransport;
    public short subsHeath => m_subsHeath;
    public short subsPolice => m_subsPolice;

    public int ins => m_worshipTime + m_taxesFood + m_taxesGoods;
    public int outs => m_subsSchools + m_subsTransport + m_subsHeath + m_subsPolice;

    void Start()
    {
        GameManager.inst.tick += UpdateBalance;
    }

    private void UpdateBalance(int cycleNumber)
    {
        int ins = m_worshipTime + m_taxesFood + m_taxesGoods;
        int outs = m_subsSchools + m_subsTransport + m_subsHeath + m_subsPolice;

        if (InfosManager.inst.evacuated) ins = 0;
        if (InfosManager.inst.confined) ins = Mathf.FloorToInt(ins * .5f);

        int newCash = ins - outs;
        newCash += haveChurch ? 3 : 0;

        m_balance += newCash;

        if (m_balanceText != null)
            m_balanceText.text = m_balance + m_balanceUnit;

        if (m_balanceArrow != null)
        {
            if (newCash == 0)
                m_balanceArrow.eulerAngles = Vector3.forward * -90;
            else if (newCash < 0)
                m_balanceArrow.eulerAngles = Vector3.forward * 180;
            else if (newCash > 0)
                m_balanceArrow.eulerAngles = Vector3.zero;
        }
    }
    public void UpdateWorshipTime(Slider value)
    {
        int v = m_worshipTime - (short)value.value;
        ChangeValueAddEffect(v, v * 2);

        m_worshipTime = (short)value.value;
    }
    public void UpdateTaxesFood(Slider value)
    {
        int v = m_taxesFood - (short)value.value;
        ChangeValueAddEffect(v, v * 2);

        m_taxesFood = (short)value.value;
    }
    public void UpdateTaxesGoods(Slider value)
    {
        int v = m_taxesGoods - (short)value.value;
        ChangeValueAddEffect(v, v * 2);

        m_taxesGoods = (short)value.value;
    }
    public void UpdatSubsSchools(Slider value)
    {
        int v = (short)value.value - m_subsSchools;
        ChangeValueAddEffect(v, v * 2);

        m_subsSchools = (short)value.value;
    }
    public void UpdatSubsTransport(Slider value)
    {
        int v = (short)value.value - m_subsTransport;
        ChangeValueAddEffect(v, v * 2);

        m_subsTransport = (short)value.value;
    }
    public void UpdatSubsHealth(Slider value)
    {
        int v = (short)value.value - m_subsHeath;
        ChangeValueAddEffect(v, v * 2);

        m_subsHeath = (short)value.value;
    }
    public void UpdatSubsPolice(Slider value)
    {
        int v = (short)value.value - m_subsPolice;
        ChangeValueAddEffect(v, v * 2);

        m_subsPolice = (short)value.value;
    }

    public void ChangeValueAddEffect(int happy, int approb, int delay = 20)
    {
        Events.Effect effTwo = new Events.Effect(GameManager.inst.numberOfCycles, delay,
            new Dictionary<Events.EffectOn, int>() { { Events.EffectOn.happiness, happy }, { Events.EffectOn.approbation, approb } });
    }

    public void BuyStuff(int cost)
    {
        m_balance -= cost;
    }
    public void FreeeMoeny(int amount)
    {
        m_balance += amount;
    }
}