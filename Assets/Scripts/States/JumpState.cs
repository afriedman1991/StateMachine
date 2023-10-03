using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : BaseState
{
    [SerializeField] private float highJump;
    [SerializeField] private float lowJump;
    [SerializeField] private float jumpTime = 0.5f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private LayerMask groundMask;
    [SerializeField, Range(0f, 2f)] float timeScale = 1;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float takeOffSpeed;
    private Vector3 takeOffDirection;
    private bool isJumping = false;
    private bool grounded => Physics.CheckSphere(rb.position, 0.1f, groundMask);
 

    public override void StateUpdate()
    {
        Time.timeScale = timeScale;
        state.MoveCamera(state.CameraInput, speed);
        state.MoveCamera(takeOffDirection, takeOffSpeed);

        // Jump Cancel
        if (Input.GetButtonUp("Jump"))
        {
            Debug.Log($"rb.velocity jump cancel: {rb.velocity}");
            rb.velocity = Vector3.up * Mathf.Min(rb.velocity.y, GetJumpForce(lowJump));
        }

        if (grounded && rb.velocity.y <= 0)
        {
            isJumping = false;
            state.ChangeState<IdleState>();
        }
    }

    public override void StateEnter()
    {
        takeOffDirection = state.CameraInput * speed;
        // Jump Start
        if (grounded)
        {
            isJumping = true;
            rb.velocity = Vector3.up * GetJumpForce(highJump);
            Debug.Log($"rb.velocity = {rb.velocity}");
        }
        Debug.Log("Entered JumpState");
    }

    float g => (2*highJump)/(jumpTime * jumpTime); // takes gravity directly from Unity's physics
    // Get force for impulse to reach desired height, handles both high/low jump to calc force needed
    public float GetJumpForce(float desiredHeight)
    {
        return Mathf.Sqrt(2 * desiredHeight * g);
    }

    public override void StatePhysicsUpdate()
    {
        rb.AddForce(Vector3.down * g);
    }
}
