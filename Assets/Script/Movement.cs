using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _physicsMovement;

    private void Update()
    {
        float horizontal = Input.GetAxis("Vertical");
        float vertical = -Input.GetAxis("Horizontal");

        _physicsMovement.Move(new Vector3(-vertical, 0, horizontal));
    }


}
