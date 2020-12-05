using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.ActionGameFramework.Ballistics
{
    public class BallisticProjectile: MonoBehaviour
    {
		 
		public float startSpeed;
		protected Rigidbody m_Rigidbody;
		public event Action fired;

		/// <summary>
		/// Fires this projectile in a designated direction at the launch speed.
		/// </summary>
		/// <param name="startPoint">Start point of the flight.</param>
		/// <param name="fireVector">Vector representing launch direction.</param>
		public virtual void FireInDirection(Vector3 startPoint, Vector3 fireVector)
		{
			transform.position = startPoint;

			Fire(fireVector.normalized * startSpeed);
		}

		/// <summary>
		/// Fires this projectile at a designated starting velocity, overriding any starting speeds.
		/// </summary>
		/// <param name="startPoint">Start point of the flight.</param>
		/// <param name="fireVelocity">Vector3 representing launch velocity.</param>
		public void FireAtVelocity(Vector3 startPoint, Vector3 fireVelocity)
		{
			transform.position = startPoint;

			startSpeed = fireVelocity.magnitude;

			Fire(fireVelocity);
		}

		 
		protected virtual void Awake()
		{
			m_Rigidbody = GetComponent<Rigidbody>();
		}

		protected virtual void Update()
		{
			 
			transform.rotation = Quaternion.LookRotation(m_Rigidbody.velocity);
		}

		protected virtual void Fire(Vector3 firingVector)
		{
			transform.rotation = Quaternion.LookRotation(firingVector);

			m_Rigidbody.velocity = firingVector;

			if (fired != null)
			{
				fired();
			}
		}
 
	}
}
