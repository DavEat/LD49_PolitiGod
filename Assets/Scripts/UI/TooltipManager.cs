using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TooltipManager : Singleton<TooltipManager>
{
    float m_time = -1;
    [SerializeField] float m_delayBeforeShow = .3f;
    [SerializeField] Vector2 m_offset;

    bool m_show = false;

    [SerializeField] GameObject m_tooltipChild;
    [SerializeField] TextMeshProUGUI m_text;

    Transform m_transform;
    void Start()
    {
        m_transform = GetComponent<Transform>();
    }

    void Update()
    {
        if (m_show && m_time < Time.time)
        {
            m_tooltipChild.SetActive(true);
        }
    }

    public void Show(string text, Vector2 position)
    {
        m_show = true;
        m_time = Time.time + m_delayBeforeShow;
        m_text.text = text;
        m_transform.position = position + m_offset;
    }
    public void Hide()
    {
        m_show = false;
        m_tooltipChild.SetActive(false);
    }
}