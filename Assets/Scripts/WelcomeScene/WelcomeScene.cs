using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeScene : SceneBase
{
    private AudioSource audioSource;

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

    }
}
