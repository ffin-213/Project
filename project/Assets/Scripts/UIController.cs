using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;



public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider, _masterSlider;

    public void ToggleMusic()
    {
        ManagerAudio.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        ManagerAudio.Instance.ToggleSFX();
    }
    public void ToggleMaster()
    {
        ManagerAudio.Instance.ToggleMaster();
    }

    public void MusicVolume()
    {
        ManagerAudio.Instance.MusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        ManagerAudio.Instance.SFXVolume(_sfxSlider.value);
    }

    public void MasterVolume()
    {
        ManagerAudio.Instance.MasterVolume(_masterSlider.value);
    }
}
