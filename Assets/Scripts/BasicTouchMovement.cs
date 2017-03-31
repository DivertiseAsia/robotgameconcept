using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Robot;
using UnityStandardAssets.Characters.ThirdPerson;

public class BasicTouchMovement : MonoBehaviour, ITargetReceivable
{

    private Queue<Vector3> targets;
    private Vector3 currentTarget;
    private bool hasTarget;

    private PointerController pointer;

    public float Speed = 7;

    public void SetTarget(Vector3 position, PointerController controller)
    {
        pointer = controller;
        pointer.FreezeTransform = true;
        if (hasTarget)
        {
            //targets.Enqueue(position);
            currentTarget = position;
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
            //this.transform.LookAt(currentTarget);
            pointer.transform.position = currentTarget;
            //;
            Vector3 move = currentTarget - this.transform.position;
            this.GetComponentInParent<ThirdPersonCharacter>().Move(move, false, false);
        } else
        {
            if (targets.Count > 0)
            {
                currentTarget = targets.Dequeue();
            } else
            {
                if (hasTarget)
                {
                    pointer.FreezeTransform = false;
                    hasTarget = false;
                }
            }
        }
    }
}
