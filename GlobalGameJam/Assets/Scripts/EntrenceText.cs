using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntrenceText : MonoBehaviour
{

    public GameObject text;
    void OnTriggerEnter(Collider other){
        text.SetActive(true);
    }

    void OnTriggerExit(Collider other){
        text.SetActive(false);
    }
}
