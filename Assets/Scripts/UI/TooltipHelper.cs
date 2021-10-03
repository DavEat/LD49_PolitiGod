using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipHelper : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [TextArea]
    [SerializeField] string m_details = "default details";

    Transform m_transform;

    void Start()
    {
        m_transform = GetComponent<Transform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PointerEnterHandler();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        PointerExitHandler();
    }
    public void PointerEnterHandler()
    {
        TooltipManager.inst.Show(m_details, m_transform.position);
    }
    public void PointerExitHandler()
    {
        TooltipManager.inst.Hide();
    }
}