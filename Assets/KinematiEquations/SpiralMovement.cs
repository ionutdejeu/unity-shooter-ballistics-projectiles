using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMovement : MonoBehaviour
{
    public Transform start;
    public Transform target;
    public LineRenderer visual;
    public int lineSegmentCount = 10;


    float flightTime = 5f;
    Vector3 speed;

    private float RotateSpeed = 5f;
    private float Radius = 0.1f;

    private void Start()
    {
        visual.positionCount = lineSegmentCount + 1;
        speed = CalculateVelocity(target.position, start.position, flightTime);
    }
    private void Update()
    {
        Visualize(speed, target.position);
         

        //var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        //transform.position = _centre + offset;
    }
    //added final position argument to draw the last line node to the actual target
    void Visualize(Vector3 speed, Vector3 targetPos)
    {
        for (int i = 0; i < lineSegmentCount; i++)
        {
            Vector3 pos = CalculatePositionInTime(speed, (i / (float)lineSegmentCount) * flightTime);
            visual.SetPosition(i, pos);
        }

        visual.SetPosition(lineSegmentCount, targetPos);
    }
    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        Vector3 dir = target - origin;
        
        return dir;
    }
    Vector3 CalculatePositionInTime(Vector3 speed,float t)
    {
        //var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        return new Vector3(Mathf.Sin(t), -Mathf.Sin(t), 0)+speed;

    }
}
