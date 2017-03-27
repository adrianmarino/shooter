using System;
using UnityEngine;

namespace Shooter
{
	public class ShootableBox : MonoBehaviour
	{
		//-----------------------------------------------------------------------------
		// Public Methods
		//-----------------------------------------------------------------------------

		public void Damage (int damageAmount)
		{
			currentHealth -= damageAmount;
			if (currentHealth <= 0)
				Destroy (gameObject);
			Debug.Log ("Hit box!");
		}

		//-----------------------------------------------------------------------------
		// Properties
		//-----------------------------------------------------------------------------

		public int MaxHealth {
			get { return maxHealth; }
			set { maxHealth = value; }
		}

		//-----------------------------------------------------------------------------
		// Attributes
		//-----------------------------------------------------------------------------

		private int currentHealth;

		[SerializeField]
		private int maxHealth;

		//-----------------------------------------------------------------------------
		// Constructors
		//-----------------------------------------------------------------------------

		public ShootableBox ()
		{
			maxHealth = 5;
			currentHealth = maxHealth;
		}
	}
}
