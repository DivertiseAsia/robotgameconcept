using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Robot;

public class PointerController : MonoBehaviour {
    
    public BasicTouchMovement receiver;
    public ITargetReceivable Receiver;

    public float MaxReleaseWait = 5f;
    public float MaxMouseDistance = 20f;

    private float timeStart;
    private Vector3 mouseStart;

    private int layerMask = 1 << 8;
    // Use this for initialization
    void Start () {
        Receiver = receiver;
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, layerMask))
        {
            this.transform.position = hit.point;
        }

        if (Input.GetMouseButtonDown(0))
        {
            timeStart = Time.time;
            mouseStart = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0)) { 
            if (Time.time - timeStart <= MaxReleaseWait && Vector3.Distance(mouseStart,Input.mousePosition) <= MaxMouseDistance)
            {
                Receiver.SetTarget(hit.point);
            }
            
        }
    }
}
