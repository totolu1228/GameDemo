using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

using VLCore.Utils;

public class GameManager : Singleton<GameManager>
{
    public GameSetting GameSetting = new GameSetting();

    // Start is called before the first frame update
    void Start()
    {
        string settingPath = Application.dataPath + "/Setting.cfg";
        try
        {
            if (File.Exists(settingPath))
                GameSetting = XmlSerializer.Deserialize<GameSetting>(settingPath);
        }
        catch
        {
            GameSetting = new GameSetting();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
