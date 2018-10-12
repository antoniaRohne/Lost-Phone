using UnityEngine;

[CreateAssetMenu(menuName = "PrefabListObject")]
public class PrefabList : ScriptableObject
{

    public AppView AppPrefab;
    public PushNotificationConfig EventPrefab;
    public PasswordPanelView PasswordPanelPrefab;

}
