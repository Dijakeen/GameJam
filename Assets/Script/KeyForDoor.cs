using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyForDoor : MonoBehaviour
{
    public bool _doYouHaveKey = false;
    

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            _doYouHaveKey = true;
            Destroy(other.gameObject);
            
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Door" && _doYouHaveKey == true)
        {
            Destroy(collision.gameObject);
            _doYouHaveKey = false;
        }
    }

}
