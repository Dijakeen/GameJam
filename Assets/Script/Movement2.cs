using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Vector3 movement;
    [SerializeField] private Rigidbody2D _rb;

    void Start()
    {
        
    }

    
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal") * _movementSpeed * Time.deltaTime;
       // movement.z = Input.GetAxis("Vertical") * _movementSpeed * Time.deltaTime;

    }
    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position * movement * _movementSpeed * Time.fixedDeltaTime);
    }
}
