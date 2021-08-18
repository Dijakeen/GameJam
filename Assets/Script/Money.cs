using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [SerializeField] private Text _money;
    [SerializeField] private int _pickUpCoin;
    
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
}
