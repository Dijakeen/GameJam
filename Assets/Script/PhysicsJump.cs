using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsJump : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _jumpForce;
    [SerializeField] bool isGrounded;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        JumpInput();
    }
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }


    private void JumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _rigidbody.AddForce(new Vector3(0, _jumpForce, 0));
            isGrounded = false;
        }
    }
}