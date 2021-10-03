using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHelper : MonoBehaviour, ISelectHandler
{
    public bool buy = true;
    public bool click0;
    public bool click1;

    public void OnSelect(BaseEventData eventData)
    {
        OnSelect();
    }

    public void OnSelect()
    {
        if(buy)
            SoundManager.inst.PlayClick0();
        else if (click0)
            SoundManager.inst.PlayClick0();
        else if (click1)
            SoundManager.inst.PlayClick0();
    }
}