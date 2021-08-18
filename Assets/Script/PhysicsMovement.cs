using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private SurfaceSlider _surfaceSlider;
    [SerializeField] private float _speed;

    public void Move(Vector3 direction)
    {
        Vector3 directionAloneSurface = _surfaceSlider.Project(direction.normalized);
        Vector3 offset = directionAloneSurface * (_speed * Time.deltaTime);

        _rigidbody.MovePosition(_rigidbody.position + offset);
    }   
}