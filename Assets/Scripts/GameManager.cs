using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public delegate void Tick(int cycleNumber);
    public Tick tick;

    [SerializeField] float m_dayTime = 1f;
    [SerializeField] int m_electionEvery = 90;
    int m_educationDay;
    public int electionEvery => m_electionEvery;
    float m_time = -1;
    int m_numberOfCycles = 1;
    public int numberOfCycles => m_numberOfCycles;

    [SerializeField] int m_afterNElection = 5;
    int m_electionsWon;

    bool m_paused = false;

    bool m_have_banckrupt = false;
    bool m_have_loseElection = false;
    bool m_lost = false;
    bool m_reload = false;

    void Start()
    {
        m_educationDay = m_electionEvery / 4;
    }

    void FixedUpdate()
    {
        if (m_lost)
        {
            if (!m_reload)
            {
                m_reload = true;
                Events.EventManager.inst.End();
            }
            else if (m_reload)
            {
                SceneManager.LoadScene(0);
            }
            return;
        }

        if (m_time < Time.time)
        {
            m_time = Time.time + m_dayTime;
            OnTick();
        }
    }

    void OnTick()
    {
        m_numberOfCycles++;

        if (m_numberOfCycles % m_educationDay == 0)
        {
            Debug.Log("eduction day");
            InfosManager.inst.EducationDay(m_numberOfCycles, m_educationDay);
        }
        if (m_numberOfCycles % m_electionEvery == 0)
        {
            Debug.Log("election day");
            m_electionsWon++;
            if (m_electionsWon == m_afterNElection)
            {
                Events.EventManager.inst.WinElectionFinal();
            }
            else
            {
                Election();
            }
        }

        tick(m_numberOfCycles);

        Banckrupt();
        Crowd();
    }

    public void SetPaused(bool pause)
    {
        m_paused = pause;
        Time.timeScale = m_paused ? 0 : 1;
    }

    void Banckrupt()
    {
        if (FinancesManager.inst.balance < -100)
        {
            if (!m_have_banckrupt)
            {
                m_have_banckrupt = true;
                Events.EventManager.inst.LoseMoneyFirst();
            }
            else
            {
                m_lost = true;
                Events.EventManager.inst.LoseMoney();
            }
        }
    }
    void Election()
    {
        if (InfosManager.inst.m_approbation < 50)
        {
            if (!m_have_loseElection)
            {
                m_have_loseElection = true;
                Events.EventManager.inst.LoseElectionFirst();
            }
            else
            {
                m_lost = true;
                Events.EventManager.inst.LoseElection();
            }
        }
        else
        {
            Events.EventManager.inst.WinElection();
        }
    }
    void Crowd()
    {
        if (InfosManager.inst.m_demonstration > 110 && InfosManager.inst.m_approbation < 30)
        {
            m_lost = true;
            Events.EventManager.inst.LoseCrowd();
        }
    }
}