using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI LeftText;
    public TextMeshProUGUI RightText;

    public string LeftTextContent;
    public string RightTextContent;

    private AsyncOperation _sceneBeingLoadedAsync;


    // Start is called before the first frame update
    void Start()
    {
        LeftText.text = GameManager.Instance.CurrentLevel.CompleteText;
        RightText.text = string.IsNullOrEmpty(GameManager.Instance.CurrentWord.CompleteResponseText) ? GameManager.Instance.CurrentWord.WordName : GameManager.Instance.CurrentWord.CompleteResponseText;

        var loadingScene = SceneManager.GetSceneByName("LoadingTransition");
        SceneManager.SetActiveScene(loadingScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
