using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleState : BaseState
{
    //[SerializeField] GrappleMovement gm;
    [SerializeField] private Animator characterAnimation;
    [SerializeField] private Transform cam;
    [SerializeField] private Transform gunTip;
    [SerializeField] private LayerMask whatIsGrappleable;
    [SerializeField] private LineRenderer lr;
    [SerializeField] private Transform grapplePosition;

    [SerializeField] private float maxGrappleDistance;
    [SerializeField] private float grappleDelayTime;
    [SerializeField] private float projectileSpeed;

    private Vector3 grapplePoint;
    private GrappleMovement gm;

    [SerializeField] private float grapplingCountdown;
    private float grapplingCountdownTimer;
    private bool grappling;

    [SerializeField] float speed;

    public override void StateEnter()
    {
        StartGrapple();
        characterAnimation.Play("Shooting");
    }

    public override void StateUpdate()
    {
        //if (grapplingCountdownTimer > 0)
        //{
        //    grapplingCountdownTimer -= Time.deltaTime;
        //}

        state.MoveCamera(state.CameraInput, speed);
        UpdateGrapplePosition();

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.LogWarning("Fire1 pressed");
            StopGrapple();
            ShootGrappledItem();
        }

        if (Input.GetButtonUp("Fire2"))
        {
            StopGrapple();
        }
    }

    public override void StateLateUpdate()
    {
        if (grappling)
            lr.SetPosition(0, gunTip.position);
    }

    private void StartGrapple()
    {
        grappling = true;

        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxGrappleDistance, whatIsGrappleable))
        {
            gm = hit.collider.gameObject.GetComponentInParent<GrappleMovement>();
            grapplePoint = hit.point;
            Debug.DrawLine(cam.position, hit.point, Color.green);

            if (gm != null)
            {
                ExecuteGrapple(gm);
            }
        }

        lr.enabled = true;
        lr.SetPosition(1, grapplePoint);
    }

    private void ExecuteGrapple(GrappleMovement gm)
    {
        //Vector3 lowestPoint = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);

        //float grapplePointRelativeYPos = grapplePoint.y - lowestPoint.y;
        //float highestPointOnArc = grapplePointRelativeYPos;

        gm.SetGrapplePoint(grapplePosition);
    }

    private void StopGrapple()
    {
        grappling = false;

        grapplingCountdownTimer = grapplingCountdown;

        lr.enabled = false;

        gm?.DropObject();

        state.ChangeState<IdleState>();
    }

    private void ShootGrappledItem()
    {
        Debug.LogWarning("Shooting grappled item");
        gm.gameObject.GetComponent<Rigidbody>().velocity = gunTip.forward * projectileSpeed;
    }

    private void UpdateGrapplePosition()
    {
        float distanceInFrontOfCamera = 5f; // or any desired distance
        grapplePosition.position = cam.position + cam.forward * distanceInFrontOfCamera;
    }
}
