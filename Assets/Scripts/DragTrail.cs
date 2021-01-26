using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTrail : MonoBehaviour
{
    public GameObject[] arms = new GameObject[2];
    public GameObject trail;
    float x, y, l1 = 2f, l2 = 1.25f;
    float thetaI, thetaII;

    Vector3 worldPos;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                x = hit.point.x / 2.5f;
                y = hit.point.z / 2.5f;
                ComputeIK();
            }

        }
    }

    void ComputeIK()
    {
        Debug.Log("X: " + x + "Y: " + y);
        var argument = Mathf.Sqrt((l1 * l1 + l2 * l2 - 2 * l1 * l2 - x * x - y * y) / (x * x + y * y - l1 * l1 - l2 * l2 - 2 * l1 * l2));
        float theta2 = Mathf.PI + 2 * Mathf.Atan(argument);
        float theta1 = Mathf.Atan2(y, x) - Mathf.Acos((l2 * l2 - l1 * l1 - (x * x + y * y)) / (-2 * l1 * Mathf.Sqrt(x * x + y * y)));

        thetaI = theta1 * 180 / Mathf.PI;
        thetaII = theta2 * 180 / Mathf.PI;

        arms[0].transform.localRotation = Quaternion.Euler(new Vector3(0f, -thetaI, 0f));
        arms[1].transform.localRotation = Quaternion.Euler(new Vector3(0f, thetaII, 0f));
    }
}
