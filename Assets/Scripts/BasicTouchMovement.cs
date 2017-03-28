using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Robot;

public class BasicTouchMovement : MonoBehaviour, ITargetReceivable
{

    private Queue<Vector3> targets;
    private Vector3 currentTarget;
    private bool hasTarget;

    public float Speed = 7;

    public void SetTarget(Vector3 position)
    {
        if (hasTarget)
        {
            targets.Enqueue(position);
        }
        else
        {
            hasTarget = true;
            currentTarget = position;
        }
    }

    void Start()
    {
        currentTarget = this.transform.position;
        hasTarget = false;
        targets = new Queue<Vector3>();
    }

    void Update()
    {
        if (hasTarget && Vector3.Distance(currentTarget, this.transform.position) > 0.5){
            this.transform.LookAt(currentTarget);
            this.transform.position = Vector3.MoveTowards(this.transform.position, currentTarget, Speed * Time.fixedDeltaTime);
        } else
        {
            if (targets.Count > 0)
            {
                currentTarget = targets.Dequeue();
            }
        }
    }
}
