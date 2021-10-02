using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHelper : MonoBehaviour, ISelectHandler, IPointerEnterHandler, IPointerExitHandler
{
    private AudioSource _source;

    public void OnSelect(BaseEventData eventData)
    {
        //OnSelect();
    }

    public void OnSelect()
    {
        if (_source == null)
            _source = GetComponentInParent<AudioSource>();

        _source.pitch = Random.Range(0.7f, 1);
        _source.loop = false;
        _source.Play();
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
        Debug.Log("pointerenter");
    }
    public void PointerExitHandler()
    {
        Debug.Log("pointerexit");
    }
}