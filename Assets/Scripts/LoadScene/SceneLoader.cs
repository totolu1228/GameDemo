using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public static string TargetScene;

    public float currentProgress;
    public Image progressBar;

    // Start is called before the first frame update
    void Start()
    {
        progressBar.fillAmount = 0;
        if (!string.IsNullOrEmpty(TargetScene))
            StartCoroutine(LoadScene());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator LoadScene()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(TargetScene);
        asyncOperation.allowSceneActivation = false;
        while (asyncOperation.progress < 0.9f)
        {
            currentProgress = asyncOperation.progress;
            yield return LoadProgress();
        }
        currentProgress = 1f;
        yield return LoadProgress();
        asyncOperation.allowSceneActivation = true;
    }

    private IEnumerator LoadProgress()
    {
        progressBar.fillAmount = currentProgress;
        yield return new WaitForSeconds(1);
    }
}
