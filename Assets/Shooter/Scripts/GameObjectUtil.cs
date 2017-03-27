using UnityEngine;
using System;
using System.Collections.Generic;

namespace Shooter
{
	public class GameObjectUtils
	{
		public static List<GameObject> findBytag (string tag)
		{
			return new List<GameObject> (GameObject.FindGameObjectsWithTag (tag));
		}

		public static Func<GameObject, bool> isActive ()
		{
			return (it) => it.activeSelf;
		}
	}
}

