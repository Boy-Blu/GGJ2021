using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextAnimationController : MonoBehaviour
{
    public Animator _animator;
    private string _sceneToLoad;
    public void FinishedAnimating()
    {
        Debug.Log("Finished animation");
        SceneManager.UnloadSceneAsync(GameManager.Instance.CurrentScene);
        SceneManager.LoadScene(GameManager.Instance.SceneToLoad, LoadSceneMode.Additive);
        _animator.SetTrigger("FadeOut");
    }
}
