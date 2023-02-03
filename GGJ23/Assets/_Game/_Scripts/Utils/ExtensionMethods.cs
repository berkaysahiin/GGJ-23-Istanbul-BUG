using UnityEngine;

namespace Game.Utils
{
	public static class ExtensionMethods
	{
		public static Vector3 Modify(this Vector3 original, object x = null, object y = null, object z = null)
		{
			return new Vector3(
				(x == null ? original.x : (float)x),
				(y == null ? original.y : (float)y),
				(z == null ? original.z : (float)z));
		}
	}
}
