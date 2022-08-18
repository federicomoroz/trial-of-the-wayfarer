using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    [Header("Signal")]
    [SerializeField] private Signal fadeIn, fadeOut, transitionBegin, transitionEnd;

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        StartCoroutine(StartSceneCo());
    }



    public void SwitchToSceneHandler(string newScene)
    {
        StartCoroutine(SwitchToScene(newScene));
    }
    private IEnumerator SwitchToScene(string newScene)
    {
        fadeOut?.Raise();
        transitionBegin?.Raise();
        yield return new WaitForSeconds(1f);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(newScene);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }     

    }

    private IEnumerator StartSceneCo()
    {
        yield return new WaitForSeconds(1f);
        transitionEnd?.Raise();
    }
}
