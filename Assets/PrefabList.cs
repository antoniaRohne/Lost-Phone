using UnityEngine;

[CreateAssetMenu(menuName = "PrefabListObject")]
public class PrefabList : ScriptableObject
{
    public GameObject[] List;

    public GameObject[] GetList()
    {
        return List;
    }
}
