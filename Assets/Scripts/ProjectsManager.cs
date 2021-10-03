using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectsManager : MonoBehaviour
{
    [SerializeField] GameObject m_hospital;
    [SerializeField] GameObject m_school;
    [SerializeField] GameObject m_police;
    [SerializeField] GameObject m_fire;
    [SerializeField] GameObject m_church;
    [SerializeField] GameObject m_transport;

    [SerializeField] Button m_button_hospital;
    [SerializeField] Button m_button_school;
    [SerializeField] Button m_button_police;
    [SerializeField] Button m_button_fire;
    [SerializeField] Button m_button_church;
    [SerializeField] Button m_button_transport;

    [SerializeField] Button m_button_meeting;

    void Start()
    {
        GameManager.inst.tick += OnTick;
    }

    void OnTick(int cycleNumber)
    {

    }

    bool CanPurchase(int cost)
    {
        return FinancesManager.inst.balance >= cost;
    }
    public void Purchase_Hospital()
    {
        int cost = 1000;

        if (!CanPurchase(cost)) return;
        FinancesManager.inst.BuyStuff(cost);

        int boostOne = -20;
        int boostTwo = 15;

        int boostOneDur = -1;
        int boostTwoDur = GameManager.inst.electionEvery * 3;

        Events.Effect effPerm = new Events.Effect(GameManager.inst.numberOfCycles, boostOneDur,
            new Dictionary<Events.EffectOn, int>() { { Events.EffectOn.heath, boostOne } });

        Events.Effect effShort = new Events.Effect(GameManager.inst.numberOfCycles, boostTwoDur,
            new Dictionary<Events.EffectOn, int>() { { Events.EffectOn.happiness, boostTwo } });

        Events.EffectManager.inst.AddEffect(effPerm);
        Events.EffectManager.inst.AddEffect(effShort);

        if (m_button_hospital) m_button_hospital.interactable = false;
        m_hospital?.SetActive(true);
    }
    public void Purchase_School()
    {
        int cost = 1000;

        if (!CanPurchase(cost)) return;
        FinancesManager.inst.BuyStuff(cost);

        int boostOne = 10;
        int boostTwo = 5;

        int boostOneDur = -1;
        int boostTwoDur = GameManager.inst.electionEvery * 3;

        Events.Effect effPerm = new Events.Effect(GameManager.inst.numberOfCycles, boostOneDur,
            new Dictionary<Events.EffectOn, int>() { { Events.EffectOn.eduction, boostOne } });

        Events.Effect effShort = new Events.Effect(GameManager.inst.numberOfCycles, boostTwoDur,
            new Dictionary<Events.EffectOn, int>() { { Events.EffectOn.happiness, boostTwo } });

        Events.EffectManager.inst.AddEffect(effPerm);
        Events.EffectManager.inst.AddEffect(effShort);

        if (m_button_school) m_button_school.interactable = false;
        m_school?.SetActive(true);
    }
    public void Purchase_Police()
    {
        int cost = 1000;

        if (!CanPurchase(cost)) return;
        FinancesManager.inst.BuyStuff(cost);

        int boostOne = -2;
        int boostTwo = 8;

        int boostOneDur = -1;
        int boostTwoDur = GameManager.inst.electionEvery * 3;

        Events.Effect effPerm = new Events.Effect(GameManager.inst.numberOfCycles, boostOneDur,
            new Dictionary<Events.EffectOn, int>() { { Events.EffectOn.crime, boostOne } });

        Events.Effect effShort = new Events.Effect(GameManager.inst.numberOfCycles, boostTwoDur,
            new Dictionary<Events.EffectOn, int>() { { Events.EffectOn.happiness, boostTwo } });

        Events.EffectManager.inst.AddEffect(effPerm);
        Events.EffectManager.inst.AddEffect(effShort);

        if (m_button_police) m_button_police.interactable = false;
        m_police?.SetActive(true);
    }
    public void Purchase_FireStation()
    {
        int cost = 1000;

        if (!CanPurchase(cost)) return;
        FinancesManager.inst.BuyStuff(cost);

        int boostOne = -2;
        int boostTwo = 5;

        int boostOneDur = -1;
        int boostTwoDur = GameManager.inst.electionEvery * 2;

        Events.Effect effPerm = new Events.Effect(GameManager.inst.numberOfCycles, boostOneDur,
            new Dictionary<Events.EffectOn, int>() { { Events.EffectOn.poverty, boostOne } });

        Events.Effect effShort = new Events.Effect(GameManager.inst.numberOfCycles, boostTwoDur,
            new Dictionary<Events.EffectOn, int>() { { Events.EffectOn.happiness, boostTwo } });

        Events.EffectManager.inst.AddEffect(effPerm);
        Events.EffectManager.inst.AddEffect(effShort);

        if (m_button_fire) m_button_fire.interactable = false;
        m_fire?.SetActive(true);
    }
    public void Purchase_Church()
    {
        int cost = 1000;

        if (!CanPurchase(cost)) return;
        FinancesManager.inst.BuyStuff(cost);

        FinancesManager.inst.haveChurch = true;

        if (m_button_church) m_button_church.interactable = false;
        m_church?.SetActive(true);
    }
    public void Purchase_Media()
    {
        int cost = 1000;

        if (!CanPurchase(cost)) return;
        FinancesManager.inst.BuyStuff(cost);


    }
    public void Purchase_PoliticalMeeting()
    {
        int cost = 300;

        if (!CanPurchase(cost)) return;
        FinancesManager.inst.BuyStuff(cost);

        int boostOne = 10;

        int boostOneDur = GameManager.inst.electionEvery / 2;

        Events.Effect effPerm = new Events.Effect(GameManager.inst.numberOfCycles, boostOneDur,
            new Dictionary<Events.EffectOn, int>() { { Events.EffectOn.approbation, boostOne } },
            new System.Action(() => { if (m_button_meeting) m_button_meeting.interactable = true; }));

        Events.EffectManager.inst.AddEffect(effPerm);

        if (m_button_meeting) m_button_meeting.interactable = false;
    }
    public void Purchase_Propaganda()
    {
        int cost = 200;

        if (!CanPurchase(cost)) return;
        FinancesManager.inst.BuyStuff(cost);

        InfosManager.inst.doingPropaganda = true;
    }
    public void Stop_Propaganda()
    {
        //int cost = 0;
        //
        //if (!CanPurchase(cost)) return;
        //FinancesManager.inst.BuyStuff(cost);

        InfosManager.inst.doingPropaganda = false;
    }
    public void Purchase_PublicTransport()
    {
        int cost = 1000;

        if (!CanPurchase(cost)) return;
        FinancesManager.inst.BuyStuff(cost);

        int boostOne = 15;

        int boostOneDur = GameManager.inst.electionEvery * 3;

        Events.Effect effPerm = new Events.Effect(GameManager.inst.numberOfCycles, boostOneDur,
            new Dictionary<Events.EffectOn, int>() { { Events.EffectOn.happiness, boostOne } });

        Events.EffectManager.inst.AddEffect(effPerm);

        if (m_button_transport) m_button_transport.interactable = false;
        m_transport?.SetActive(true);
    }
}