using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {
        get
        {
            return _instance;
        }
    }
    private static GameManager _instance;

    public Scene CurrentScene;
    public LevelInfo CurrentLevel = null;
    public Word CurrentWord = null;

    public string SceneToLoad = null;

    // Start is called before the first frame update

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadLevel(Word word)
    {
        DontDestroyOnLoad(this);
        CurrentWord = word;
        CurrentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("LoadingTransition", LoadSceneMode.Additive);
        SceneToLoad = word.LevelToLoad;
    }

}
