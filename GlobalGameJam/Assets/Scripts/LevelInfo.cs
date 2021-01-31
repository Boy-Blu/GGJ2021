using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    [TextArea]
    public string CompleteText;

    private void Start()
    {
        GameManager.Instance.CurrentLevel = this;
    }

}
