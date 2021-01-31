using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingCanvasAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    public void FinishedFadeOut()
    {
        var newScene = SceneManager.GetSceneByName(GameManager.Instance.SceneToLoad);
        SceneManager.SetActiveScene(newScene);
        var loadingScene = SceneManager.GetSceneByName("LoadingTransition");
        SceneManager.UnloadSceneAsync(loadingScene);
    }
}
