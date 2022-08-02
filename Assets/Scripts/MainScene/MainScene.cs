using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : SceneBase
{
    private AudioSource audioSource;
    public GameObject pnlEscape;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (GameManager.Instance)
            audioSource.volume = GameManager.Instance.GameSetting.Volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            pnlEscape.SetActive(!pnlEscape.activeSelf);
    }

    public void OnBtnEscapeClick()
    {
        pnlEscape.SetActive(true);
    }
}
