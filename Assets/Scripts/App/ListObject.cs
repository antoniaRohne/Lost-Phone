using App;
using UnityEngine;

[CreateAssetMenu(menuName = "ListObject")]
public class ListObject : ScriptableObject
	{
		public AppConfigurations[] List;

		public AppConfigurations[] GetList()
		{
			return List;
		}
	}
