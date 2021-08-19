using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float _speed;

    private void Update()
    {
        Move();
    }
    void Move()
    {
        if (Input.GetKey(InputManager.IM.forward))

            transform.position += Vector3.forward / 7 * _speed;

        if (Input.GetKey(InputManager.IM.backward))

            transform.position += -Vector3.forward / 7 * _speed;

        if (Input.GetKey(InputManager.IM.left))

            transform.position += Vector3.left / 7 * _speed;

        if (Input.GetKey(InputManager.IM.right))

            transform.position += Vector3.right / 7 * _speed;

        if (Input.GetKeyDown(InputManager.IM.jump))

            transform.position += Vector3.up / 7 * _speed;
    }
}
