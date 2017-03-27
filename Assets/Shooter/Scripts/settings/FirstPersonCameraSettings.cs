using UnityEngine;

namespace Shooter
{
	[System.Serializable]
	public class FirstPersonCameraSettings
	{
		//-----------------------------------------------------------------------------
		// Public Methods
		//-----------------------------------------------------------------------------

		public Vector3 Viewport()
		{
			return new Vector3(ViewportX, ViewportY, 0);
		}

		//-----------------------------------------------------------------------------
		// Properties
		//-----------------------------------------------------------------------------

		public float ViewportX
		{
			get { return viewportX; }
			set { value = viewportX; }
		}

		public float ViewportY
		{
			get { return viewportY; }
			set { value = viewportY; }
		}

		//-----------------------------------------------------------------------------
		// Attributes
		//-----------------------------------------------------------------------------

		[SerializeField]
		private float viewportX, viewportY;

		//-----------------------------------------------------------------------------
		// Constructors
		//-----------------------------------------------------------------------------

		public FirstPersonCameraSettings()
		{
			viewportX = viewportY = 0;
		}
	}
}
