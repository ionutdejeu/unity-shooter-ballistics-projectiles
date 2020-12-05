using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.KinematiEquations
{
    public class ParabolicMovementByHeight : MonoBehaviour
    {
        public LineRenderer visual;
        public int lineSegmentCount = 10;

        public float gravity = 16f;
        public Transform startPosition;
        public Transform targetPosition;

        public float flightTime = 10f;


        public float maxHeight = 2f;

        void visualize(Vector3 speed, Vector3 targetPos)
        {
            for (int i = 0; i < lineSegmentCount; i++)
            {
                Vector3 pos = CalculatePositionInTime(speed, (i / (float)lineSegmentCount) * flightTime);
                visual.SetPosition(i, pos);
            }

            visual.SetPosition(lineSegmentCount, targetPos);
        }

        Vector3 CalculatePositionInTime(Vector3 vo, float t)
        {
            Vector3 Vxz = vo;
            Vxz.y = 0f;

            Vector3 result = startPosition.position + vo * t;
            float sY = -.5f * gravity * (t * t) + vo.y * t + startPosition.position.y;

            result.y = sY;
            return result;
        }


    }

}
