using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] AudioSource m_source;

    [SerializeField] AudioClip click0;
    [SerializeField] AudioClip click1;
    [SerializeField] AudioClip elected0;
    [SerializeField] AudioClip loseElect0;
    [SerializeField] AudioClip event0;
    [SerializeField] AudioClip buy0;

    void PlaySound(AudioClip clip)
    {
        if (m_source == null || clip == null) return;

        m_source.pitch = Random.Range(0.7f, 1);
        m_source.loop = false;
        m_source.PlayOneShot(clip);
    }

    public void PlayClick0()
    {
        PlaySound(click0);
    }
    public void PlayClick1()
    {
        PlaySound(click1);
    }
    public void PlayElected0()
    {
        PlaySound(elected0);
    }
    public void PlayLoseElected0()
    {
        PlaySound(loseElect0);
    }
    public void PlayEvent0()
    {
        PlaySound(event0);
    }
    public void PlayBuy0()
    {
        PlaySound(buy0);
    }
}
