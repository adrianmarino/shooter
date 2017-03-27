using System;
using UnityEngine;

namespace Shooter
{
	[System.Serializable]
	public class FirstPersonCamera
	{
		//-----------------------------------------------------------------------------
		// Public Methods
		//-----------------------------------------------------------------------------

		public Vector3 Direction ()
		{
			return camera.transform.forward;
		}

		public Vector3 viewportPosition ()
		{
			return camera.ViewportToWorldPoint (settings.Viewport ());
		}

		//-----------------------------------------------------------------------------
		// Attributes
		//-----------------------------------------------------------------------------

		private Camera camera;

		private FirstPersonCameraSettings settings;

		//-----------------------------------------------------------------------------
		// Constructors
		//-----------------------------------------------------------------------------

		public FirstPersonCamera (Camera camera, FirstPersonCameraSettings settings)
		{
			this.camera = camera;
			this.settings = settings;
		}
	}
}
