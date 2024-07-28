using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

    private bool looksLeft;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float _inputX = Input.GetAxisRaw("Horizontal");
        float _inputY = Input.GetAxisRaw("Vertical");

        _animator.SetFloat("Move", Math.Abs(_inputX) + Math.Abs(_inputY));

        if (_inputX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (_inputX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        Vector2 _velocity = new Vector2(_inputX, _inputY) * _speed;

        _rigidbody.velocity = _velocity;
    }
}
