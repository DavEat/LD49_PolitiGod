using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectsManager : MonoBehaviour
{
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

        int boostOne = 20;
        int boostTwo = 15;

        int boostOneDur = -1;
        int boostTwoDur = GameManager.inst.electionEvery * 3;

        Events.Effect effPerm = new Events.Effect(GameManager.inst.numberOfCycles, boostOneDur,
            new Dictionary<Events.EffectOn, int>() { { Events.EffectOn.heath, boostOne } });

        Events.Effect effShort = new Events.Effect(GameManager.inst.numberOfCycles, boostTwoDur,
            new Dictionary<Events.EffectOn, int>() { { Events.EffectOn.happiness, boostTwo } });

        Events.EffectManager.inst.AddEffect(effPerm);
        Events.EffectManager.inst.AddEffect(effShort);
    }
    public void Purchase_School()
    {
        int cost = 1000;

        if (!CanPurchase(cost)) return;

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
    }
    public void Purchase_Police()
    {
        int cost = 1000;

        if (!CanPurchase(cost)) return;

        int boostOne = 2;
        int boostTwo = 8;

        int boostOneDur = -1;
        int boostTwoDur = GameManager.inst.electionEvery * 3;

        Events.Effect effPerm = new Events.Effect(GameManager.inst.numberOfCycles, boostOneDur,
            new Dictionary<Events.EffectOn, int>() { { Events.EffectOn.crime, boostOne } });

        Events.Effect effShort = new Events.Effect(GameManager.inst.numberOfCycles, boostTwoDur,
            new Dictionary<Events.EffectOn, int>() { { Events.EffectOn.happiness, boostTwo } });

        Events.EffectManager.inst.AddEffect(effPerm);
        Events.EffectManager.inst.AddEffect(effShort);
    }
    public void Purchase_FireStation()
    {
        int cost = 1000;

        if (!CanPurchase(cost)) return;

        int boostOne = 2;
        int boostTwo = 5;

        int boostOneDur = -1;
        int boostTwoDur = GameManager.inst.electionEvery * 2;

        Events.Effect effPerm = new Events.Effect(GameManager.inst.numberOfCycles, boostOneDur,
            new Dictionary<Events.EffectOn, int>() { { Events.EffectOn.poverty, boostOne } });

        Events.Effect effShort = new Events.Effect(GameManager.inst.numberOfCycles, boostTwoDur,
            new Dictionary<Events.EffectOn, int>() { { Events.EffectOn.happiness, boostTwo } });

        Events.EffectManager.inst.AddEffect(effPerm);
        Events.EffectManager.inst.AddEffect(effShort);
    }
    public void Purchase_Church()
    {
        int cost = 1000;

        if (!CanPurchase(cost)) return;

        FinancesManager.inst.haveChurch = true;
    }
    public void Purchase_Media()
    {
        int cost = 1000;

        if (!CanPurchase(cost)) return;

        
    }
    public void Purchase_PoliticalMeeting()
    {
        int cost = 1000;

        if (!CanPurchase(cost)) return;

        int boostOne = 10;

        int boostOneDur = GameManager.inst.electionEvery / 2;

        Events.Effect effPerm = new Events.Effect(GameManager.inst.numberOfCycles, boostOneDur,
            new Dictionary<Events.EffectOn, int>() { { Events.EffectOn.approbation, boostOne } });

        Events.EffectManager.inst.AddEffect(effPerm);
    }
    public void Purchase_Propaganda()
    {
        int cost = 1000;

        if (!CanPurchase(cost)) return;

        InfosManager.inst.doingPropaganda = true;
    }
    public void Stop_Propaganda()
    {
        int cost = 0;

        if (!CanPurchase(cost)) return;

        InfosManager.inst.doingPropaganda = false;
    }
    public void Purchase_PublicTransport()
    {
        int cost = 1000;

        if (!CanPurchase(cost)) return;

        int boostOne = 15;

        int boostOneDur = GameManager.inst.electionEvery * 3;

        Events.Effect effPerm = new Events.Effect(GameManager.inst.numberOfCycles, boostOneDur,
            new Dictionary<Events.EffectOn, int>() { { Events.EffectOn.happiness, boostOne } });

        Events.EffectManager.inst.AddEffect(effPerm);
    }
}