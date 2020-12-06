using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotRotatorTest : MonoBehaviour
{
    [SerializeField] Transform _pivotPosition;//parented to this transform
    [SerializeField] Transform _finalPosition;//I want to move this transform to here
    Quaternion rotation = Quaternion.Euler(0f, 1f, 0f);
    // Use this for initialization
    void Start()
    {
        //set the final position after rotating around the pivot and offset the pivot local position
        transform.position = RotatePointAroundPivot(_finalPosition.position, _pivotPosition.position, _finalPosition.rotation);
        //finally set the rotation to target rotation
        transform.rotation = _finalPosition.rotation;
    }

    private void Update()
    {
        //set the final position after rotating around the pivot and offset the pivot local position
        transform.position = RotatePointAroundPivot(transform.position, _pivotPosition.position, rotation);
       
    }

    public Vector3 RotatePointAroundPivot(Vector3 _finalPosition, Vector3 _pivotPosition, Quaternion _finalRotation)
    {
        return _pivotPosition + (_finalRotation * (_finalPosition - _pivotPosition)); // returns new position of the point;
    }

    public Vector3 RotatePointAroundPivotWithRadius(Vector3 dir, Vector3 position, Quaternion rot)
    {
        return position + (rot * dir);
    }
}
