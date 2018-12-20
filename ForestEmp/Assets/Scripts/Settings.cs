using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Settings : MonoBehaviour {

    
    private Resolution[] Resolutions;
    public Dropdown ResoDropdown;
    public Dropdown QualityDropdown;
    public bool Fullscreen;
    public Toggle FullscreenToggle;
    public Resolution resolution;

    void Start ()
    {


        
        Resolutions = Screen.resolutions;

        ResoDropdown.ClearOptions();

        List<string> resolutionoptions = new List<string>();
      
        int currentresolutionindex = 0;

                                      
        for (int i =0; i < Resolutions.Length; i++)
        {
            string resolutionoption = Resolutions[i].width + "x" + Resolutions[i].height;
            resolutionoptions.Add(resolutionoption);

            if(Resolutions[i].width==Screen.currentResolution.width && Resolutions[i].height==Screen.currentResolution.height)
            {
                currentresolutionindex = i;
            }

        }


        ResoDropdown.AddOptions(resolutionoptions);
        ResoDropdown.value = currentresolutionindex;
        ResoDropdown.RefreshShownValue();


        QualityDropdown.value = QualitySettings.GetQualityLevel();


        if (Screen.fullScreen == true)
        {
            FullscreenToggle.isOn = true;
        }

    }


    public void SetResolution(int resolutionindex)
    {
        resolution = Resolutions[resolutionindex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void FullscreenActive(bool value)
    {
        if (value == true)
        {
            Screen.fullScreen = true;
        }
        if (value == false)
        {
            Screen.fullScreen = false;
        }
    }

    public void SetQuality(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
    }


    void Update ()
    {
		
	}
}
