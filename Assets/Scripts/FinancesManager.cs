using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinancesManager : Singleton<FinancesManager>
{
    [SerializeField] int m_balance;
    [SerializeField] string m_balanceUnit = "h";
    [SerializeField] TextMeshProUGUI m_balanceText;

    //ins
    short m_worshipTime;
    short m_taxesFood;
    short m_taxesGoods;
    //outs
    short m_subsSchools;
    short m_subsTransport;
    short m_subsHeath;
    short m_subsPolice;

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

        m_balance += ins - outs;

        if (m_balanceText != null)
            m_balanceText.text = m_balance + m_balanceUnit;
    }
    public void UpdateWorshipTime(Slider value)
    {
        m_worshipTime = (short)value.value;
    }
    public void UpdateTaxesFood(Slider value)
    {
        m_taxesFood = (short)value.value;
    }
    public void UpdateTaxesGoods(Slider value)
    {
        m_taxesGoods = (short)value.value;
    }
    public void UpdatSubsSchools(Slider value)
    {
        m_subsSchools = (short)value.value;
    }
    public void UpdatSubsTransport(Slider value)
    {
        m_subsTransport = (short)value.value;
    }
    public void UpdatSubsHealth(Slider value)
    {
        m_subsHeath = (short)value.value;
    }
    public void UpdatSubsPolice(Slider value)
    {
        m_subsPolice = (short)value.value;
    }
}