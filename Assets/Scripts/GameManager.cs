using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public delegate void Tick(int cycleNumber);
    public Tick tick;

    [SerializeField] float m_dayTime = 1f;
    float m_time = -1;
    int m_numberOfCycles = 0;

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
        tick(m_numberOfCycles);
    }
}