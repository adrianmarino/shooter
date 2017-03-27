using UnityEngine;

namespace Shooter
{
	[System.Serializable]
	public class WeaponShotSettings
	{
		//-----------------------------------------------------------------------------
		// Properties
		//-----------------------------------------------------------------------------

		public float Range
		{
			get { return range; }
			set { range = value; }
		}

		public int Damage
		{
			get { return damage; }
			set { damage = value; }
		}

		public float Rate
		{
			get { return rate; }
			set { rate = value; }
		}

		public float ImpactForce
		{
			get { return impactForce; }
			set { impactForce = value; }
		}

		public float Duration
		{
			get { return duration; }
			set { duration = value; }
		}

		public float NextTime
		{
			get { return nextTime; }
			set { nextTime = value; }
		}

		//-----------------------------------------------------------------------------
		// Attributes
		//-----------------------------------------------------------------------------

		[SerializeField]
		private float range;

		[SerializeField]
		private int damage;

		[SerializeField]
		private float rate;

		[SerializeField]
		private float impactForce;

		[SerializeField]
		private float duration;

		[SerializeField]
		private float nextTime;

		//-----------------------------------------------------------------------------
		// Constructors
		//-----------------------------------------------------------------------------

		public WeaponShotSettings()
		{
			range = 500f;
			damage = 1;
			rate = 0.25f;
			impactForce = 200f;
			duration = 0.7f;
			nextTime = 0.25f;
		}
	}
}
