using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class TouchDragCamera : MonoBehaviour {


    public bool debug = true;
    public float MinMouseDistance = 20f;
    public GameObject mouseStartTarget;
    public GameObject mouseEndTarget;
    public Text text;
    public UICircle arc;

    private Vector3 mouseStart;
    private bool isMoving = false;

    private Quaternion startRotation;

    public GameObject rig;
    // Use this for initialization
    void Start () {
        mouseStartTarget.SetActive(false);
        mouseEndTarget.SetActive(false);
        arc.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    float angleBetweenVectors(Vector3 a, Vector3 b)
    {
        float atanA = Mathf.Atan2(a.y, a.x);
        float atanB = Mathf.Atan2(b.y, b.x);
        float diff = atanA - atanB;
        float angle = diff / (2 * Mathf.PI) * 360;
        return angle;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStart = new Vector3(Input.mousePosition.x - Screen.width/2, Input.mousePosition.y - Screen.height / 2);
            mouseStart.Normalize();
            isMoving = false;

            if (debug)
            {
                mouseStartTarget.SetActive(true);
                mouseStartTarget.transform.position = Input.mousePosition;
            }
        }
        if (isMoving == false && Input.GetMouseButton(0) && Vector3.Distance(mouseStart,Input.mousePosition) > MinMouseDistance)
        {
            isMoving = true;
            startRotation = rig.transform.rotation;
            if (debug)
            {
                mouseEndTarget.SetActive(true);
                arc.gameObject.SetActive(true);
                text.gameObject.SetActive(true);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Released - so stopped");
            isMoving = false;
            if (debug)
            {
                mouseStartTarget.SetActive(false);
                mouseEndTarget.SetActive(false);
                arc.gameObject.SetActive(false);
                text.gameObject.SetActive(false);
            }
        }

        if (isMoving)
        {
            
            mouseEndTarget.transform.position = Input.mousePosition;
            Vector3 mouseCurrent = new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
            mouseCurrent.Normalize();
            float angleInside = angleBetweenVectors(mouseStart, mouseCurrent);    
            rig.transform.rotation = Quaternion.Euler(startRotation.eulerAngles.x, startRotation.eulerAngles.y+ angleInside, startRotation.eulerAngles.z);
            if (debug)
            {
                int fillPercent = (int)Mathf.Abs(angleInside / 360f * 100f);
                arc.fillPercent = fillPercent;
                arc.SetAllDirty();

                text.text = Mathf.Round(angleInside) + "`";

                float arcRotation = angleBetweenVectors(mouseStart, Vector3.left);
                Debug.Log("rotation is:" + arcRotation);

                if (angleInside > 0)//no support for negative fill percent so flip
                {
                    arc.transform.rotation = Quaternion.Euler(0, 0, arcRotation);
                }
                else
                {
                    arc.transform.rotation = Quaternion.Euler(0, 0, arcRotation);
                }
            }
        }
        
    }
}
