using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _enemyHealth;
    [SerializeField] private GameObject _enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hero"))
        {
            _enemyHealth -= 1;
            if (_enemyHealth == 0)
            {
                Destroy(_enemy);
            }
        }
    }
}
