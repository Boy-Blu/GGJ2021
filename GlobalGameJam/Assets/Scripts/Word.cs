using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Word : MonoBehaviour
{
    public string WordName
    {
        get
        {
            if (!string.IsNullOrEmpty(WordOverwrite))
            {
                return WordOverwrite;
            }
            return gameObject.name;
        }
    }

    public string WordOverwrite;

    public TextMeshPro Text;

    [TextArea]
    public string CompleteResponseText;

    public string LevelToLoad;

    void Awake()
    {
        Text.text = WordName;
        PlayerController.OnPickupWord += DestroySelf;    
    }   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroySelf()
    {
        this.gameObject.SetActive(false);
    }
}
