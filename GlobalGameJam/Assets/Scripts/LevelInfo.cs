using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    [TextArea]
    public string CompleteText;
    public string LevelToLoad;

    private void Start()
    {
        GameManager.Instance.CurrentLevel = this;
    }

}
