using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource mainTheme;
    public AudioSource clickFX;
    public AudioSource upgradeFX;
    public AudioSource exhaustedFX;
    public AudioSource sacrificeFX;
    public AudioSource eventFX;
    public AudioSource extractionFX;
    public AudioSource additionFX;
    public AudioSource gameOverFX;
    public AudioSource newItem;

    public void Update()
    {
        if(Time.timeScale != 1)
            mainTheme.volume = Mathf.Lerp(mainTheme.volume, 0.2f, Time.fixedDeltaTime*2);
        else
            mainTheme.volume = Mathf.Lerp(mainTheme.volume, 0.5f, Time.deltaTime*2);
    }
    public void PlayUpgradeFX()
    {
        upgradeFX.Play();
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
        sacrificeFX.Play();
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
