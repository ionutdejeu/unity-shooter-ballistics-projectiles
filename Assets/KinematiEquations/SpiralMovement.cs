using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMovement : MonoBehaviour
{
    public Transform start;
    public Transform target;
    public LineRenderer visual;
    public int lineSegmentCount = 10;
    public int intialAngle = 30;


    Quaternion rotationAtSpeed;
    
    public float StartingRadius = 10f;
    public float EndRadius = 0f;
    Vector3 movementDirection;

    private void Start()
    {
        movementDirection = (target.position - start.position);        
        visual.positionCount = lineSegmentCount+1;
    }
    private void Update()
    {
        rotationAtSpeed = Quaternion.AngleAxis(intialAngle, movementDirection);
        Visualize();
        
    }
    void Visualize()
    {
        for (int i = 0; i <=lineSegmentCount; i++)
        {
            float t = (i / (float)lineSegmentCount);
            Vector3 pos = Vector3.Lerp(start.position, target.position, t);
            float radLert = StartingRadius-(StartingRadius-EndRadius) * t;
            Vector3 rPovit = rotationAtSpeed * Vector3.Cross(movementDirection, Vector3.up).normalized*radLert;
            Vector3 finalPos = pos + rPovit;
            rotationAtSpeed *= Quaternion.AngleAxis(15,movementDirection);

            Debug.DrawLine(pos, finalPos, Color.red);
            visual.SetPosition(i, pos+rPovit);
        }
    }
 
}
