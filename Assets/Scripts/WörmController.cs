using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class WörmController : MonoBehaviour
{
    public float Speed = 3.0f;
    public float RotateSpeed = 0.05f;
    public float TurnSmoothVelocity;
    public float GravityConstant = -9.81f;
    public float JumpHeight = 3f;
    public Transform Cam;

    CharacterController Controller;
    Vector3 Direction;
    Vector3 MoveDirection;
    Vector3 Velocity;

    public Transform GroundCheck;
    public float GroundDistance;
    public LayerMask GroundMask;
    public bool IsGrounded;

    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }
    //Todo find out what the problem is with IsGrounded
    void Update()
    {
        IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);
        
        float _horizontal = Input.GetAxisRaw("Horizontal");
        float _vertical = Input.GetAxisRaw("Vertical");

        Direction = new Vector3(_horizontal, 0f, _vertical).normalized;
        if (Direction.magnitude >= 0.1f)
        {
            float _targetAngle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            float _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref TurnSmoothVelocity, RotateSpeed);
            transform.rotation = Quaternion.Euler(0f, _angle, 0f);

            MoveDirection = Quaternion.Euler(0f, _targetAngle, 0f) * Vector3.forward;
            Controller.Move(MoveDirection.normalized * Speed * Time.deltaTime);
        }
        Gravity();
        if(Input.GetButtonDown("Jump") && IsGrounded){ Jump(); }

        Controller.Move(Velocity * Time.deltaTime);
    }

    void Gravity()
    {
        if (IsGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }
        Velocity.y += GravityConstant * Time.deltaTime;
    }
    void Jump()
    {
        Velocity.y = Mathf.Sqrt(JumpHeight * -2 * GravityConstant);
    }
}
