using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.ActionGameFramework.Launcher
{
	/// <summary>
	/// A class that allows the TowerConfiguration to delegate
	/// different firing logic this component
	/// </summary>
	public interface ILauncher
	{
		/// <summary>
		/// The method for crafting the firing logic for the tower
		/// </summary>
		/// <param name="enemy">
		/// The enemy that the tower is targeting
		/// </param>
		/// <param name="attack">
		/// The projectile component used to attack the enemy
		/// </param>
		/// <param name="firingPoint"></param>
		void Launch(GameObject enemy, GameObject attack, Transform firingPoint);

		/// <summary>
		/// The method for crafting the firing logic for the tower
		/// </summary>
		/// <param name="enemy">
		/// The enemy that the tower is targeting
		/// </param>
		/// <param name="attack">
		/// The projectile component used to attack the enemy
		/// </param>
		/// <param name="firingPoints">
		/// A list of firing points to fire from
		/// </param>
		void Launch(GameObject enemy, GameObject attack, Transform[] firingPoints);

		/// <summary>
		/// The method for crafting firing logic at multiple enemies
		/// </summary>
		/// <param name="enemies">
		/// The collection of enemies to attack
		/// </param>
		/// <param name="attack">
		/// The projectile component used to attack the enemy
		/// </param>
		/// <param name="firingPoints"></param>
		void Launch(List<GameObject> enemies, GameObject attack, Transform[] firingPoints);
	}
}
