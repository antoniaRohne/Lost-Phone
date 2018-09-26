using UnityEngine;

[CreateAssetMenu(menuName = "PrefabListObject")]
public class PrefabList : ScriptableObject
{
    public GameObject[] List;
    //Serialize Field mit Typen statt List

    public GameObject[] GetList()
    {
        return List;
    }
}
