using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingScene : SceneBase
{
    public Toggle toggleFullscreen;

    // Start is called before the first frame update
    void Start()
    {
        toggleFullscreen.isOn = Screen.fullScreen;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBtnApplyClick()
    {
        if (toggleFullscreen.isOn)
        {
            Resolution[] resolutions = Screen.resolutions;
            Screen.SetResolution(resolutions[resolutions.Length - 1].width, resolutions[resolutions.Length - 1].height, true);
        }
        else
        {
            Screen.SetResolution(1024, 576, false);
        }
    }
}
