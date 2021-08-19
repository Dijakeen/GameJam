using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [SerializeField] private Text _money;
    [SerializeField] private int _pickUpCoin;
    [SerializeField] private bool _stayInTrigger;

    
    void Start()
    {
        _pickUpCoin = 0;
    }

    
    void Update()
    {
        _money.text = "Монеты: " + _pickUpCoin;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            _pickUpCoin += 1;
            Destroy(other.gameObject);
        }
    }
    /*private void OnTriggerStay(Collider other)
    {
        _stayInTrigger = true;
   
        if (Input.GetKeyDown(KeyCode.E) && _stayInTrigger )
        {
            _pickUpCoin += Random.Range(1, 5);
        }
        /*else
        {
           _stayInTrigger = false;
        }
    }

   /* private void OnCollisionEnter(Collision collision)
    {
        
        if (Input.GetKeyDown(KeyCode.E) && collision.gameObject.CompareTag("Chest"))
        {
            _pickUpCoin += Random.Range(1, 5);
        }
    }*/
}
