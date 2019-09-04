using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource clickFX;
    public AudioSource upgradeFX;

    public void PlayUpgradeFX()
    {
        clickFX.Play();
    }
    public void PlayClickFX()
    {
        clickFX.Play();
    }
}
