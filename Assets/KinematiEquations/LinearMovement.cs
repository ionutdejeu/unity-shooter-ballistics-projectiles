using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.KinematiEquations
{
    /// <summary>
    /// Simple script with linear interpolation between 2 coordinates
    /// </summary>
    public class LinearMovement:MonoBehaviour
    {
        private Vector3 initialPosition = Vector3.zero;
        public Transform target;
        public float speed;
        
        [Range(0,100)]
        public float progress;

        void Start()
        {
            initialPosition = transform.position;    
        }
        private void Update()
        {
            Vector3 pos = Vector3.Lerp(initialPosition, target.position, progress / 100);
            transform.position = pos;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(initialPosition, 1);
            Gizmos.DrawSphere(transform.position, 1);
            Gizmos.DrawWireSphere(target.position, 1);
        }
    }
}
