using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.KinematiEquations
{
    public class ParabolicMovement:MonoBehaviour
    {
        
        public float ANIMATION_DURATION = 2.0f;
        public float FRAMES_PER_SECOND = 30.0f;
        public GameObject one;
        public GameObject two;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnDrawGizmos()
        {
            if (one != null && two != null)
            {
                Gizmos.color = Color.yellow;
                Vector3[] points = parabolicMovement(one.transform.position, two.transform.position);
                foreach (Vector3 point in points)
                {
                    Gizmos.DrawSphere(point, .1f);
                }
            }
        }

        public Vector3[] parabolicMovement(Vector3 startingPos, Vector3 arrivingPos)
        {
            int framesNum = (int)(ANIMATION_DURATION * FRAMES_PER_SECOND);
            Vector3[] frames = new Vector3[framesNum];

            //PROJECTING ON Z AXIS
            Vector3 stP = new Vector3(0, startingPos.y, startingPos.z);
            Vector3 arP = new Vector3(0, arrivingPos.y, arrivingPos.z);

            Vector3 diff = new Vector3();

            Vector3 height = new Vector3(0, 1, 0);
            diff = ((arP - stP) / 2) + height;
            Vector3 vertex = stP + diff;

            float x1 = startingPos.z;
            float y1 = startingPos.y;
            float x2 = arrivingPos.z;
            float y2 = arrivingPos.y;
            float x3 = vertex.z;
            float y3 = vertex.y;

            float denom = (x1 - x2) * (x1 - x3) * (x2 - x3);

            var z_dist = (arrivingPos.z - startingPos.z) / framesNum;
            var x_dist = (arrivingPos.x - startingPos.x) / framesNum;

            float A = (x3 * (y2 - y1) + x2 * (y1 - y3) + x1 * (y3 - y2)) / denom;
            float B = (float)(System.Math.Pow(x3, 2) * (y1 - y2) + System.Math.Pow(x2, 2) * (y3 - y1) + System.Math.Pow(x1, 2) * (y2 - y3)) / denom;
            float C = (x2 * x3 * (x2 - x3) * y1 + x3 * x1 * (x3 - x1) * y2 + x1 * x2 * (x1 - x2) * y3) / denom;

            float newX = startingPos.z;
            float newZ = startingPos.x;

            for (int i = 0; i < framesNum; i++)
            {
                newX += z_dist;
                newZ += x_dist;
                float yToBeFound = A * (newX * newX) + B * newX + C;
                frames[i] = new Vector3(newZ, yToBeFound, newX);
            }
            return frames;
        }
        
    }
}
