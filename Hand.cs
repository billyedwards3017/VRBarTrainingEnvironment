using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    //Animation Variables
    Animator animator;

    SkinnedMeshRenderer mesh;
    //private float IndexTarget;
    //private float MiddleTarget;
    //private float RingTarget;
    //private float PinkyTarget;
    //private float ThumbTarget;

    //private float IndexCurrent;
    //private float MiddleCurrent;
    //private float RingCurrent;
    //private float PinkyCurrent;
    //private float ThumbCurrent;
    [SerializeField] public float Anispeed;


    private float GripTarget;
    private float TriggerTarget;

    private float GripCurrent;
    private float TriggerCurrent;


    //PhysicsMoves

    [SerializeField] private GameObject followObject;
    [SerializeField] private float followSpeed = 30f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;

    private Transform _followTarget;
    private Rigidbody _body;



    // Start is called before the first frame update
    void Start()
    {
        //stores the animation component of the hand in a variable
        animator = GetComponent<Animator>();
        mesh = GetComponentInChildren<SkinnedMeshRenderer>();

        //collects teh component informatino of the physics side of the hand
        _followTarget = followObject.transform;
        _body = GetComponent<Rigidbody>();
        _body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _body.interpolation = RigidbodyInterpolation.Interpolate;
        _body.mass = 20f;

        //Sets where the hands are to start with
        _body.position = _followTarget.position;
        _body.rotation = _followTarget.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Hand Animations
        AnimateHand();

        //Hand Physics
        PhysicsMove();
    }

    private void PhysicsMove()
    {

        //This will move the hand to where the controller is based off of the physics of the hand
        var positionWithOffset = _followTarget.position + positionOffset;

        //the velocity of the hand is set with this
        var distance = Vector3.Distance(positionWithOffset, transform.position);
        _body.velocity = (positionWithOffset - transform.position).normalized * (followSpeed * distance);



        //Rotation
        var rotationWithOffset = _followTarget.rotation * Quaternion.Euler(rotationOffset);

        //this controls the physics of the rotation of the hand, setting the velocity of its turn
        var q = rotationWithOffset * Quaternion.Inverse(_body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        _body.angularVelocity = angle * Mathf.Deg2Rad * rotateSpeed * axis;

    }

    //these collect teh value of the grip and triggers of the controller
    internal void SetGrip(float readValue)
    {
        GripTarget = readValue;
    }

    internal void SetTrigger(float readValue)
    {
        TriggerTarget = readValue;
    }









    //internal void SetIndex(float readValue)
    //{
    //    IndexTarget = readValue;
    //}

    //internal void SetMiddle(float readValue)
    //{
    //    MiddleTarget = readValue;
    //}

    //internal void SetRing(float readValue)
    //{
    //    RingTarget = readValue;
    //}

    //internal void SetPinky(float readValue)
    //{
    //    PinkyTarget = readValue;
    //}

    //internal void SetThumb(float readValue)
    //{
    //    ThumbTarget = readValue;
    //}

    void AnimateHand()
    {


        if (TriggerCurrent != TriggerTarget)
        {
            TriggerCurrent = Mathf.MoveTowards(TriggerCurrent, TriggerTarget, Time.deltaTime * Anispeed);
            animator.SetFloat("trigger", TriggerCurrent);
        }

        if (GripCurrent != GripTarget)
        {
            GripCurrent = Mathf.MoveTowards(GripCurrent, GripTarget, Time.deltaTime * Anispeed);
            animator.SetFloat("grip", GripCurrent);
        }







        //if (IndexCurrent != IndexTarget)
        //{
        //    IndexCurrent = Mathf.MoveTowards(IndexCurrent, IndexTarget, Time.deltaTime * speed);
        //    animator.SetFloat("Index Grip", IndexCurrent);
        //}

        //if (MiddleCurrent != MiddleTarget)
        //{
        //    MiddleCurrent = Mathf.MoveTowards(MiddleCurrent, MiddleTarget, Time.deltaTime * speed);
        //    animator.SetFloat("Middle Grip", MiddleCurrent);
        //}

        //if (RingCurrent != RingTarget)
        //{
        //    RingCurrent = Mathf.MoveTowards(RingCurrent, RingTarget, Time.deltaTime * speed);
        //    animator.SetFloat("Ring Grip", RingCurrent);
        //}

        //if (PinkyCurrent != PinkyTarget)
        //{
        //    PinkyCurrent = Mathf.MoveTowards(PinkyCurrent, PinkyTarget, Time.deltaTime * speed);
        //    animator.SetFloat("Pinky Grip", PinkyCurrent);
        //}

        //if (ThumbCurrent != ThumbTarget)
        //{
        //    ThumbCurrent = Mathf.MoveTowards(ThumbCurrent, ThumbTarget, Time.deltaTime * speed);
        //    animator.SetFloat("Thumb Grip", ThumbCurrent);
        //}

    }

    public void ToggleVisibility()
    {
        mesh.enabled = !mesh.enabled;

        if (_body.detectCollisions == false)
        {
            StartCoroutine(waiter());
        }
        else
        {
            _body.detectCollisions = !_body.detectCollisions;
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(1);

        _body.detectCollisions = !_body.detectCollisions;
    }
}
