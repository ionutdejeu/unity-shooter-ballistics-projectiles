﻿using Assets.ActionGameFramework.Ballistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.ActionGameFramework.Launcher
{
	/// <summary>
	/// Implementation of the tower launcher for Ballistic Projectiles
	/// </summary>
	public class BallisticLauncher : Launcher
	{
		/// <summary>
		/// The particle system used for providing launch feedback
		/// </summary>
		public ParticleSystem fireParticleSystem;

		/// <summary>
		/// Launches a single projectile at a single enemy from a single firing point
		/// </summary>
		/// <param name="enemy">
		/// The enemy to target
		/// </param>
		/// <param name="projectile">
		/// The projectile to attack
		/// </param>
		/// <param name="firingPoint">
		/// The point to fire from
		/// </param>
		public override void Launch(GameObject enemy, GameObject projectile, Transform firingPoint)
		{
			Vector3 startPosition = firingPoint.position;
			var ballisticProjectile = projectile.GetComponent<BallisticProjectile>();
			if (ballisticProjectile == null)
			{
				Debug.LogError("No ballistic projectile attached to projectile");
				DestroyImmediate(projectile);
				return;
			}
			Vector3 targetPoint = Vector3.zero;
			 
			PlayParticles(fireParticleSystem, startPosition, targetPoint);
		}
	}
}
