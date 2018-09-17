using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "App")]
public class AppConfigurations : ScriptableObject
{
    public AppEnum App;
    public Sprite Icon;
    public SceneAsset Scene;
}