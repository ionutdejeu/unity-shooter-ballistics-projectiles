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


    float flightTime = 5f;
    Vector3 speed;

    Quaternion rotationAtSpeed;
    
    public float StartingRadius = 10f;
    public float EndRadius = 0f;
    Vector3 movementDirection;
    Quaternion movementDirectionRotation;

    private void Start()
    {
        movementDirection = (target.position - start.position);
        movementDirectionRotation = Quaternion.LookRotation(movementDirection);
        
        visual.positionCount = lineSegmentCount+1;
    }
    private void Update()
    {
        rotationAtSpeed = Quaternion.AngleAxis(intialAngle, movementDirection);
        Visualize(speed, target.position);
         

        //var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        //transform.position = _centre + offset;
    }
    //added final position argument to draw the last line node to the actual target
    void Visualize(Vector3 speed, Vector3 targetPos)
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

        //visual.SetPosition(lineSegmentCount, targetPos);
    }

    public Vector3 RotatePointAroundPivotWithRadius(Vector3 dir, Vector3 position, Quaternion rot)
    {
        return position + (rot * dir); 
    }

 
}
