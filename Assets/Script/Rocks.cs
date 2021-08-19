using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocks : MonoBehaviour
{
    [SerializeField] private Text _amountRock;
    [SerializeField] private int _pickUpRock;



    void Start()
    {
        _pickUpRock = 0;
    }


    void FixedUpdate()
    {
        _amountRock.text = "Камушки: " + _pickUpRock;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            _pickUpRock += 1;
            Destroy(other.gameObject);
        }
    }
    
}

