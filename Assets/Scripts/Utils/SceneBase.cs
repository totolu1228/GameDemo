﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadSceneAsync(string scene)
    {
        SceneLoader.TargetScene = scene;
        SceneManager.LoadScene("LoadScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
