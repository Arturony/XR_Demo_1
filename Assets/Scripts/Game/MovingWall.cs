using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{

    public int speed = 10;

    private Vector3 target;

    private Vector3 start;

    private float timeElapsed;

    private float lerpDuration;

    private float distance;

    [SerializeField]
    private AnimationCurve curve;

    public static Action setKinematic;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != Vector3.zero && timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(start, target, curve.Evaluate(timeElapsed / lerpDuration));
            timeElapsed += Time.fixedDeltaTime;
        }
    }

    public void MoveToPoint(Transform target)
    {
        start = transform.position;

        this.target = new Vector3(target.position.x, start.y, target.position.z);
        distance = Vector3.Distance(start, this.target);
        lerpDuration = distance / speed;
        timeElapsed = 0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision!");
            setKinematic?.Invoke();
        }
    }
}
