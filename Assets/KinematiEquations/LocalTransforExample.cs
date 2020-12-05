using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalTransforExample : MonoBehaviour
{
    private float x;
    private float z;
    private bool rotateX;
    private float rotationSpeed;

    void Start()
    {
        x = 0.0f;
        z = 0.0f;
        rotateX = true;
        rotationSpeed = 75.0f;
    }

    void FixedUpdate()
    {
        if (rotateX == true)
        {
            x += Time.deltaTime * rotationSpeed;

            if (x > 360.0f)
            {
                x = 0.0f;
                rotateX = false;
            }
        }
        else
        {
            z += Time.deltaTime * rotationSpeed;

            if (z > 360.0f)
            {
                z = 0.0f;
                rotateX = true;
            }
        }

        transform.rotation = Quaternion.Euler(x, 0, z);
    }
}
