using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Robot;

public class PointerController : MonoBehaviour {

    public BasicTouchMovement receiver;
    public ITargetReceivable Receiver;

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
            Receiver.SetTarget(hit.point);
        }
    }
}
