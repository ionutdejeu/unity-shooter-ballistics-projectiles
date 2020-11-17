using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.ActionGameFramework.Ballistics
{

	/// <summary>
	/// Ballistic arc calculation priorities/preferences.
	/// </summary>
	public enum BallisticArcHeight
	{
		/// <summary>
		/// High "underarm" arc
		/// </summary>
		UseHigh,

		/// <summary>
		/// Low "overarm" arc
		/// </summary>
		UseLow,

		/// <summary>
		/// Use high arc if valid, fall back to low if possible.
		/// </summary>
		PreferHigh,

		/// <summary>
		/// Use low arc if valid, fall back to high if possible.
		/// </summary>
		PreferLow
	}
}
