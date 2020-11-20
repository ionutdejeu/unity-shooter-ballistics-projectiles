using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.KinematiEquations
{
    /// <summary>
    /// https://pastebin.com/Tgk28m7Q
    /// https://www.youtube.com/watch?v=6mJMmF5sLxk&ab_channel=RomiFauzi
    /// Good example 
    /// The flaw of this is that the form of the parabola does not adjust, it's rather fixed and stiff
    /// </summary>
    public class ParabolicMovementBySpeed: MonoBehaviour
    {
        public LineRenderer visual;
        public int lineSegmentCount = 10;

        public float gravity = 16f;
        public Transform startPosition;
        public Transform targetPosition;
        private Vector3 velocity; 
        public float flightTime = 1f;

        private void Start()
        {
            visual.positionCount = lineSegmentCount+1;

        }

        private void Update()
        {
            velocity = CalculateVelocity(targetPosition.position, startPosition.position, flightTime);
            Visualize(velocity, targetPosition.position);
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
            Vector3 dirxz = dir;
            dirxz.y = 0f;

            float sY = dir.y;
            float sXz = dirxz.magnitude;

            float Vxz = sXz / time;
            float Vy = (sY / time) + (.5f * gravity * time);

            Vector3 result = dirxz.normalized;
            result *= Vxz;
            result.y= Vy;

            return result;
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
