using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using VLCore.Utils;

public class SettingScene : SceneBase
{
    private Resolution[] resolutions;
    private AudioSource audioSource;
    public Dropdown optionResolution;
    public Toggle toggleFullscreen;
    public Slider audioSlider;
    public Text txtAudio;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        toggleFullscreen.isOn = Screen.fullScreen;
        optionResolution.ClearOptions();
        resolutions = Screen.resolutions;
        foreach (Resolution resolution in resolutions)
            optionResolution.options.Add(new Dropdown.OptionData($"{resolution.width}x{resolution.height} {resolution.refreshRate}Hz"));
        optionResolution.value = resolutions.Length - 1;
        optionResolution.captionText.text = $"{Screen.width}x{Screen.height} {Screen.currentResolution.refreshRate}Hz";
        if (GameManager.Instance)
        {
            audioSource.volume = GameManager.Instance.GameSetting.Volume;
            audioSlider.value = audioSource.volume;
        }
    }

    // Update is called once per frame
    void Update()
    {
        optionResolution.enabled = !toggleFullscreen.isOn;
    }

    public void OnAudioSliderChanged()
    {
        audioSource.volume = audioSlider.value;
        txtAudio.text = ((int)(audioSlider.value * 100)).ToString();
    }

    public void OnBtnApplyClick()
    {
        if (toggleFullscreen.isOn)
            Screen.SetResolution(resolutions[resolutions.Length - 1].width, resolutions[resolutions.Length - 1].height, true);
        else
        {
            string[] spFullResolution = optionResolution.captionText.text.Split(' ');
            string[] spResolution = spFullResolution[0].Split('x');
            Screen.SetResolution(int.Parse(spResolution[0]), int.Parse(spResolution[1]), false);
        }
        if (GameManager.Instance)
        {
            GameManager.Instance.GameSetting.Volume = audioSlider.value;
            string settingPath = Application.dataPath + "/Setting.cfg";
            XmlSerializer.Serialize(settingPath, GameManager.Instance.GameSetting);
        }
    }
}
