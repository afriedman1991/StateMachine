using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [SerializeField] private BaseState startingState;
    public Animator characterAnimation;
    public Vector3 PlayerInput => new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    public Camera cam;
    public Vector3 CameraInput => cam.transform.TransformDirection(PlayerInput);
    public Rigidbody rb;

    private void Awake()
    {
        var states = GetComponentsInChildren<BaseState>();

        for (int i = 0; i < states.Length; i++)
        {
            states[i].InitializeStateMachine(this);
        }

        ChangeState(startingState);
    }

    public void MoveCamera(Vector3 direction, float speed)
    {
        direction = Vector3.ProjectOnPlane(direction, transform.up);
        direction = direction.normalized * speed;

        Move(direction);
    }

    public void Move(Vector3 direction)
    {
        Debug.DrawRay(transform.position, direction, Color.red, 0f);
        // Move player, takes in a movement Vector3 input
        //transform.Translate(direction * Time.deltaTime, Space.World);
        rb.MovePosition(rb.position + direction * Time.deltaTime);
        rb.MoveRotation(Quaternion.LookRotation(direction, Vector3.up));
    }

    public void LookInDirection(Vector3 direction)
    {
        rb.MoveRotation(Quaternion.LookRotation(direction, Vector3.up));
    }
}