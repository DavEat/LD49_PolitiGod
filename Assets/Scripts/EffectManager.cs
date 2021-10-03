using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Events
{
    public class EffectManager : Singleton<EffectManager>
    {
        List<Effect> m_events;

        Dictionary<EffectOn, int> m_effects;
        public Dictionary<EffectOn, int> effects => m_effects;

        void Start()
        {
            m_events = new List<Effect>();
            m_effects = new Dictionary<EffectOn, int>();

            GameManager.inst.tick += OnTick;

            //m_events.Add(new Effect(0, 20, new Dictionary<EffectOn, int> { { EffectOn.demonstration, -10 }, { EffectOn.crime, -10 } }));
            //m_events.Add(new Effect(0, 23, new Dictionary<EffectOn, int> { { EffectOn.eduction, 42 } }));
            //m_events.Add(new Effect(23, 23, new Dictionary<EffectOn, int> { { EffectOn.eduction, 21 } }));
        }

        void OnTick(int cycleNumber)
        {
            CalculateEvent(cycleNumber);
        }

        public void AddEffect(Effect e)
        {
            m_events.Add(e);
        }
        void CalculateEvent(int cycleNumber)
        {
            m_effects.Clear();

            foreach (Effect e in m_events.ToList())
            {
                if (e.startTime > cycleNumber) continue;
                if (e.endTime <= cycleNumber && e.endTime > 0)
                {
                    m_events.Remove(e);
                    if (e.result != null)
                        e.result();
                    continue;
                }
                foreach (KeyValuePair<EffectOn, int> kp in e.effect)
                {
                    if (!m_effects.ContainsKey(kp.Key))
                        m_effects.Add(kp.Key, kp.Value);
                    else m_effects[kp.Key] += kp.Value;
                }
            }
        }
    }

    public enum EffectOn
    {
        happiness,
        eduction,
        crime,
        poverty,

        flood,
        heath,
        demonstration,

        approbation
    }

    public class Effect
    {
        public int startTime;
        public int endTime;
        
        /// <summary>During event</summary>
        public Dictionary<EffectOn, int> effect;
        /// <summary>At the end</summary>
        public Action result;

        public Effect(int startTime, int duration, Dictionary<EffectOn, int> effect, Action result = null)
        {
            this.startTime = startTime;
            this.endTime = duration == -1 ? -1 : startTime + duration;
            this.effect = effect;
            this.result = result;
        }
    }
}