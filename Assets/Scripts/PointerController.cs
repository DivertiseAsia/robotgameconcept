using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Robot;

public class PointerController : MonoBehaviour
{

    public BasicTouchMovement receiver;
    public ITargetReceivable Receiver;

    public float MaxReleaseWait = 5f;
    public float MaxMouseDistance = 20f;

    private float timeStart;
    private Vector3 mouseStart;

    public static LayerMask terrainLayer = 1 << 8;

    public bool FreezeTransform = false;

    // Use this for initialization
    void Start()
    {
        Receiver = receiver;
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, terrainLayer))
        {
            if (!FreezeTransform)
            {
                this.transform.position = hit.point;
            }

            if (Input.GetMouseButtonDown(0))
            {
                timeStart = Time.time;
                mouseStart = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (isStillConsideredClick())
                {
                    Receiver.SetTarget(hit.point, this);
                }

            }
        }
        else
        {

        }

    }

    private bool isStillConsideredClick()
    {
        return Time.time - timeStart <= MaxReleaseWait && Vector3.Distance(mouseStart, Input.mousePosition) <= MaxMouseDistance;
    }
}
