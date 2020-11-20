using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.KinematiEquations
{
    public class BezierCurveProjectileMovement:MonoBehaviour
    {
        public LineRenderer visual;
        public int numberOfDrawingPoints = 100;
        [SerializeField]
        public Vector2 A = new Vector2(0,0);
        private Vector3 A3d;

        [SerializeField]
        public Vector2 B = new Vector2(0, 0);
        private Vector3 B3d;

        [SerializeField]
        public Vector2 C = new Vector2(0, 0);
        private Vector3 C3d;

        [SerializeField]
        public Vector2 D = new Vector2(0, 0);
        private Vector3 D3d;


        public Transform startPosition;
        public Transform targetPosition;

        private Vector3 direction;
        private void Start()
        {
            visual.positionCount = numberOfDrawingPoints + 1;
            float interval = 1f / numberOfDrawingPoints;
            float t = interval;
            direction = startPosition.position - targetPosition.position;
            Quaternion q = Quaternion.FromToRotation(Vector3.up, direction);
            
            A3d = q * new Vector3(A.x, A.y, 0f)+ startPosition.position;
            B3d = q * new Vector3(B.x,B.y,0f) + startPosition.position;
            C3d = q * new Vector3(C.x, C.y, 0f) + startPosition.position;
            D3d = targetPosition.position;

        }


        private void Update()
        {
            direction = startPosition.position - targetPosition.position;
            Quaternion q = Quaternion.FromToRotation(Vector3.up, direction);

            A3d = startPosition.position;
            B3d = q * new Vector3(B.x, B.y, 0f) + startPosition.position;
            C3d = q * new Vector3(C.x, C.y, 0f) + startPosition.position;
            D3d = targetPosition.position;
            Visualize(targetPosition.position);
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(A3d, 1f);
            Gizmos.DrawSphere(B3d, 1f);
            Gizmos.DrawSphere(C3d, 1f);
            Gizmos.DrawSphere(D3d, 1f);

        }

        //added final position argument to draw the last line node to the actual target
        void Visualize(Vector3 targetPos)
        {
            for (int i = 0; i < numberOfDrawingPoints; i++)
            {
                Vector3 pos = Bezier3D.BezierPathCalculation(A3d, B3d, C3d, D3d, (i / (float)numberOfDrawingPoints));
                visual.SetPosition(i, pos);
            }

            visual.SetPosition(numberOfDrawingPoints, targetPos);
        }

    }

    public class Bezier3D
    {
        public List<Vector3> points;
        public Bezier3D(List<Vector3> points)
        {
            this.points = points;
        }

        public static Vector3 BezierPathCalculation(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            float tt = t * t;
            float ttt = t * tt;
            float u = 1.0f - t;
            float uu = u * u;
            float uuu = u * uu;

            Vector3 B = new Vector3();
            B = uuu * p0;
            B += 3.0f * uu * t * p1;
            B += 3.0f * u * tt * p2;
            B += ttt * p3;

            return B;
        }
    }
}
