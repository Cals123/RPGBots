using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] float _turnSpeed = 1000f;
    [SerializeField] float _moveSpeed = 5f;
    Rigidbody _rigidBody;
    Animator _animator;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {

        var MouseMovement = Input.GetAxis("Mouse X");
        transform.Rotate(0, MouseMovement * Time.deltaTime * _turnSpeed, 0);

    }

    void FixedUpdate()
    {

        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Vertical *= 2;

        }

        var velocity = new Vector3(Horizontal, 0, Vertical);
        velocity *= _moveSpeed * Time.fixedDeltaTime;

        Vector3 offset = transform.rotation * velocity;
        GetComponent<Rigidbody>().MovePosition(transform.position + offset);

        _animator.SetFloat("Vertical", Vertical, 0.1f, Time.deltaTime);
        _animator.SetFloat("Horizontal", Horizontal, 0.1f, Time.deltaTime);
    }
}
