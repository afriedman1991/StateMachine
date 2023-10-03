using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector3 velocityToSet;
    private Transform targetPoint;

    public void FixedUpdate()
    {
        if (targetPoint != null)
        {
            var vel = targetPoint.position - transform.position;
            rb.velocity = vel * 10f;
        }
    }

    public Vector3 CalculateVelocity(Vector3 startPoint, Vector3 endPoint, float trajectoryHeight)
    {
        float gravity = Physics.gravity.y;
        float displacementY = endPoint.y - startPoint.y;
        Vector3 displacementXZ = new Vector3(endPoint.x - startPoint.x, 0f, endPoint.z - startPoint.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * trajectoryHeight);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * trajectoryHeight / gravity) + Mathf.Sqrt(2 * (displacementY - trajectoryHeight) / gravity));

        return velocityXZ + velocityY;
    }

    public void SetGrapplePoint(Transform targetPosition)
    {
        targetPoint = targetPosition;
        //velocityToSet = CalculateVelocity(transform.position, targetPoint, 0f);
        //Invoke(nameof(SetVelocity), 0.1f);
    }

    private void SetVelocity()
    {
        rb.velocity = velocityToSet;
    }

    public void DropObject()
    {
        targetPoint = null;
    }
}
