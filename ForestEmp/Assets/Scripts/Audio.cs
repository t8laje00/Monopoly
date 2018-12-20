using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio : MonoBehaviour {


    public AudioMixer MasterMixer;
    public AudioMixerGroup Master;

    public Slider MasterSlider;
    public Slider MusicSlider;
    public Slider SfxSlider;

    // Use this for initialization
    void Start ()
     {

        MasterSlider.value = -10.0f;
        MusicSlider.value = -10.0f;
        SfxSlider.value = -10.0f;
    }



    public void SetVolumeMaster(float MasterVolumelevel)
    {
        MasterMixer.SetFloat("MasterVolume", MasterVolumelevel);
    }

    public void SetVolumeMusic(float MusicVolumelevel)
    {
        MasterMixer.SetFloat("MusicVolume", MusicVolumelevel);
    }


    public void SetVolumeSFX(float SfxVolumelevel)
    {
        MasterMixer.SetFloat("SfxVolume", SfxVolumelevel);
    }


    // Update is called once per frame
    void Update () {
		
	}




}
