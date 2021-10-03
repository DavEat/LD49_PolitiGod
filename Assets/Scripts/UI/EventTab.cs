using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Events
{
    public class EventTab : Singleton<EventTab>
    {
        [SerializeField] TextMeshProUGUI m_title;
        [SerializeField] TextMeshProUGUI m_content;

        [SerializeField] GameObject m_acknowledge;
        [SerializeField] GameObject m_conceed;
        [SerializeField] GameObject m_ignore;

        [SerializeField] Effect m_acknowledge_effect;
        [SerializeField] Effect m_conceed_effect;
        [SerializeField] Effect m_ignore_effect;

        void Start()
        {
            //gameObject.SetActive(false);
        }

        void ShowEvent(string title, string content)
        {
            GameManager.inst.SetPaused(true);

            m_title.text = title;
            m_content.text = content;

            gameObject.SetActive(true);
        }
        public void ShowEvent(string title, string content, Effect acknowledge = null)
        {
            ShowEvent(title, content);

            m_acknowledge_effect = acknowledge;

            m_acknowledge.SetActive(true);
            m_conceed.SetActive(false);
            m_ignore.SetActive(false);            
        }
        public void ShowEvent(string title, string content, Effect conceed, Effect ignore)
        {
            ShowEvent(title, content);

            m_conceed_effect = conceed;
            m_ignore_effect = ignore;

            m_acknowledge.SetActive(false);
            m_conceed.SetActive(true);
            m_ignore.SetActive(true);
        }

        public void Conceed()
        {
            EffectManager.inst.AddEffect(m_conceed_effect);
            gameObject.SetActive(false);
            GameManager.inst.SetPaused(false);
        }
        public void Ignore()
        {
            EffectManager.inst.AddEffect(m_ignore_effect);
            gameObject.SetActive(false);
            GameManager.inst.SetPaused(false);
        }
        public void Acknowledge()
        {
            if (m_acknowledge_effect != null)
                EffectManager.inst.AddEffect(m_acknowledge_effect);
            gameObject.SetActive(false);
            GameManager.inst.SetPaused(false);
        }
    }
}