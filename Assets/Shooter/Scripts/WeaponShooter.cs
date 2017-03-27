using UnityEngine;
using System.Collections;

namespace Shooter
{
	public class WeaponShooter : MonoBehaviour
	{
		//-----------------------------------------------------------------------------
		// Engine Events
		//-----------------------------------------------------------------------------

		void Start ()
		{
			shotAudio = GetComponent<AudioSource> ();
			shotTrack = GetComponent<LineRenderer> ();
			camera = new FirstPersonCamera (GetComponentInParent<Camera> (), CameraSettings);
		}

		void Update ()
		{
			if (Input.GetButtonDown ("Fire1") && currentFireTime > shot.NextTime) {
				Shoot ();
				currentFireTime = 0;
			} else
				currentFireTime += Time.deltaTime;
		}

		//-----------------------------------------------------------------------------
		// Private Methods
		//-----------------------------------------------------------------------------

		private void Shoot ()
		{
			StartCoroutine (ShotEffect ());
			Vector3 rayOrigin = camera.viewportPosition ();
			Vector3 rayDirection = camera.Direction ();

			shotTrack.SetPosition (0, WeaponCanonEnd.position);
	
			RaycastHit hit;
			if (Physics.Raycast (rayOrigin, rayDirection, out hit, Shot.Range)) {
				shotTrack.SetPosition (1, hit.point);
				Debug.Log ("Hit Box!");

				ShootableBox box = hit.collider.GetComponent<ShootableBox> ();
				if (box != null)
					box.Damage (Shot.Damage);

				if (hit.rigidbody != null)
					hit.rigidbody.AddForce (-hit.normal * Shot.ImpactForce);
			} else
				shotTrack.SetPosition (1, rayOrigin + (rayDirection * Shot.Range));
		}

		private IEnumerator ShotEffect ()
		{
			shotAudio.Play ();
			shotTrack.enabled = true;
			yield return new WaitForSeconds (Shot.Duration);
			shotTrack.enabled = false;
		}

		//-----------------------------------------------------------------------------
		// Properties
		//-----------------------------------------------------------------------------

		public Transform WeaponCanonEnd {
			get { return weaponCanonEnd; }
			set { weaponCanonEnd = value; }
		}

		public WeaponShotSettings Shot {
			get { return shot; }
			set { shot = value; }
		}

		public FirstPersonCameraSettings CameraSettings {
			get { return cameraSettings; }
			set { cameraSettings = value; }
		}

		//-----------------------------------------------------------------------------
		// Attributes
		//-----------------------------------------------------------------------------

		[SerializeField]
		private WeaponShotSettings shot;

		[SerializeField]
		private Transform weaponCanonEnd;

		[SerializeField]
		private FirstPersonCameraSettings cameraSettings;

		[SerializeField]
		private FirstPersonCamera camera;

		private AudioSource shotAudio;

		private LineRenderer shotTrack;

		private float currentFireTime;

		//-----------------------------------------------------------------------------
		// Constructors
		//-----------------------------------------------------------------------------

		public WeaponShooter ()
		{
			currentFireTime = 0;
			shot = new WeaponShotSettings ();
			cameraSettings = new FirstPersonCameraSettings ();
		}
	}
}