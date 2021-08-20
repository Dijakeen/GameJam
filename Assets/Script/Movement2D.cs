using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Movement2D : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private float _speed, _jumpForce;
    private SpriteRenderer spriteRenderer;
    private Animator _animator;
    [SerializeField] Transform groundCheker;
    [SerializeField] float groundRadius;
    [SerializeField] bool isGrounded;
    float velX, velY;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

    }
    private void Update()
    {
        Walk();
        Jump();
        GroundCheck();
        AnimatorPlayer();
    }
    private void Walk()
    {
        velX = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(velX * _speed, _rb.velocity.y);
        if (velX > 0)
        {
           spriteRenderer.flipX = false;   
        }
        if (velX < 0)
        {
            spriteRenderer.flipX = true;
        }

    }

    void Jump()
    {
        if (isGrounded && Input.GetButton("Jump"))
        {
            Debug.Log("JUMP!");
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _animator.SetTrigger("Jumped");
        }
    }

    void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheker.position, groundRadius, Ground);
    }

    private void AnimatorPlayer()
    {
        _animator.SetBool("IsGround", isGrounded);
        _animator.SetFloat("SpeedH", Mathf.Abs(velX));
    }

}