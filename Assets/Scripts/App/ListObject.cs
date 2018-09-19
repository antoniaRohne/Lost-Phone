using UnityEngine;

namespace App
{
	[CreateAssetMenu(menuName = "ListObject")]
	public class ListObject<T> : ScriptableObject
	{
		public T[] List;

		public T[] GetList()
		{
			return List;
		}
	}
}