using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        m_educationDay = m_electionEvery / 4;
    }

    void FixedUpdate()
    {
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
        }

        tick(m_numberOfCycles);
    }
}