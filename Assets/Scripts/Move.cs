using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float rotSpeed = 60;
    public float slideDelta = 0;
    private Vector3 startPoint, endPoint;
    public bool isRotating = true;
    public bool isMoving = true;

    private void Start()
    {
        startPoint = transform.position;
        endPoint = transform.position + new Vector3(20, 0, 0);
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.Lerp(startPoint, endPoint, Mathf.Lerp(0, 1, slideDelta));
            slideDelta += 1 * Time.deltaTime;

            if (slideDelta > 1)
            {
                slideDelta = 0;
                Vector3 temp = startPoint;
                startPoint = endPoint;
                endPoint = temp;
            }
        }
        if (isRotating)
        {
            transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
        }
        
    }
}
