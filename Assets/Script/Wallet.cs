using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] public Text _money;
    [SerializeField] public int _pickUpCoin;

    void Awake()
    {
        _money.text = _pickUpCoin.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            _pickUpCoin += 1;
            _money.text = _pickUpCoin.ToString();
            Destroy(other.gameObject);
        }
    }
}
