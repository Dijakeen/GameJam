using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDummy : MonoBehaviour
{
    public GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == Player.gameObject.tag)
        {
            Player.GetComponent<HpManager>().GetHp(1);
        }
    }
}
