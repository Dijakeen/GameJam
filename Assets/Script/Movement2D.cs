using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Vector2 _moveVector;
    [SerializeField] private float _speed;
    private SpriteRenderer spriteRenderer;
    private Animator _animator;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

    }
    private void Update()
    {
        Walk();
        AnimatorPlayer();
        _animator.SetBool("Idle", true);
    }
    private void Walk()
    {
        _moveVector.x = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(_moveVector.x * _speed, _rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.flipX = true;
                
            }
            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (spriteRenderer == true)
            {
                spriteRenderer.flipX = false;
                
            }
            

        }

    }
    private void AnimatorPlayer()
    { 
        _animator.SetBool("Idle", true);
        
        
        if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetBool("IsRun", true);
        }
        else
        {
            _animator.SetBool("IsRun", false);
        }
    }

}
