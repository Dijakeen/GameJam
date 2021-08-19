using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInTrigger : MonoBehaviour
{
    public UnityEvent triggeret = new UnityEvent();
    public string playerTag;
    public bool triggered;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == playerTag)
        {
            triggeret.Invoke();
        }
    }
}
