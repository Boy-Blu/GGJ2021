using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrigger : MonoBehaviour
{
    public Transform SpawnPos;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = SpawnPos.transform.position;
    }
}
