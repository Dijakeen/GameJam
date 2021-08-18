using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDestroy : MonoBehaviour
{
    private KeyForDoor _keyForDoor;
    [SerializeField] private GameObject _doorToDestroy;

    void Start()
    {
        _keyForDoor = GetComponent<KeyForDoor>(); 
    }

    

    private void OnTriggerEnter(Collider other)
    {
       
    }
}
