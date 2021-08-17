using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _moveVector;
    [SerializeField] private float _speedMove;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();

    }

    
    void Update()
    {
        CharacterMove();
    }
    private void CharacterMove()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = Input.GetAxis("Horizontal") * _speedMove;
        _moveVector.z = Input.GetAxis("Vertical") * _speedMove;

        _characterController.Move(_moveVector * Time.deltaTime);
    }

}
