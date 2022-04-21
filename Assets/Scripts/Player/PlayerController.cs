using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float turnSpeed = 2f;

    public Vector2 MoveInput { get { return _moveInput; } }

    Vector2 _moveInput;
    Vector2 _mousePos;

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    void OnMove(InputValue moveInput)
    {
        _moveInput = moveInput.Get<Vector2>();
    }

    void HandleMovement()
    {
        Vector3 deltaPos = new Vector3(_moveInput.x, 0f, _moveInput.y) * moveSpeed * Time.deltaTime;
        transform.position += deltaPos;
    }

    void OnAim(InputValue currentMousePos)
    {
        _mousePos = currentMousePos.Get<Vector2>();
    }

    void HandleRotation()
    {
        Ray ray = Camera.main.ScreenPointToRay(_mousePos);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            LookAt(point);
        }
    }

    void LookAt(Vector3 lookPoint)
    {
        Vector3 direction = (lookPoint - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
}
