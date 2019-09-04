﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource clickFX;
    public AudioSource upgradeFX;
    public AudioSource exhaustedFX;
    public AudioSource sacrificeFX;
    public AudioSource eventFX;
    public AudioSource extractionFX;
    public AudioSource additionFX;
    public AudioSource gameOverFX;
    public AudioSource newItem;

    public void PlayUpgradeFX()
    {
        clickFX.Play();
    }
    public void PlayEventFX()
    {
        eventFX.Play();
    }
    public void PlayClickFX()
    {
        clickFX.Play();
    }
    public void PlayExaustedFX()
    {
        exhaustedFX.Play();
    }
    public void PlaySacrificeFX()
    {
        exhaustedFX.Play();
    }
    public void PlayAdditionFX()
    {
        additionFX.Play();
    }
    public void PlayExtractionFX()
    {
        extractionFX.Play();
    }
    public void PlayGameOverFX()
    {
        gameOverFX.Play();
    }
    public void PlayNewItemFX()
    {
        newItem.Play();
    }
    public void SetGlobalVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
