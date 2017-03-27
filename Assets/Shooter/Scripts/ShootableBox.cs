using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;

namespace Shooter
{
	using util = GameObjectUtils;

	public class ShootableBox : MonoBehaviour
	{
		void Start ()
		{
			currentDamage = maxDamage;
		}

		//-----------------------------------------------------------------------------
		// Public Methods
		//-----------------------------------------------------------------------------

		public void Damage (int damageAmount)
		{
			currentDamage -= damageAmount;
			if (currentDamage <= 0) {
				intancesCount++;
				if (intancesCount == 0)
					StartCoroutine (RestartSceneAfter (2));	
				ExploitIt ();
			}
		}

		//-----------------------------------------------------------------------------
		// Private Methods
		//-----------------------------------------------------------------------------

		private void ExploitIt ()
		{
			Instantiate (explosion, transform.position, transform.rotation);
			this.gameObject.SetActive (false);
		}

		private static IEnumerator RestartSceneAfter (int delay)
		{
			yield return new WaitForSeconds (delay);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}

		//-----------------------------------------------------------------------------
		// Properties
		//-----------------------------------------------------------------------------

		public int MaxDamage {
			get { return maxDamage; }
			set { maxDamage = value; }
		}

		public GameObject Explosion {
			get { return explosion; }
			set { explosion = value; }
		}

		//-----------------------------------------------------------------------------
		// Attributes
		//-----------------------------------------------------------------------------

		private int currentDamage;

		private static long intancesCount = 0;

		[SerializeField]
		private int maxDamage;

		[SerializeField]
		private GameObject explosion;

		//-----------------------------------------------------------------------------
		// Constructors
		//-----------------------------------------------------------------------------

		public ShootableBox ()
		{
			maxDamage = 2;
			intancesCount++;
		}
	}
}
