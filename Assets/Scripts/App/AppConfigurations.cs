using UnityEditor;
using UnityEngine;

namespace App
{
    [CreateAssetMenu(menuName = "App")]
    public class AppConfigurations : ScriptableObject
    {
        public AppEnum App;
        public Sprite Icon;
        public SceneAsset Scene;
        public string PushNoteContent;
        public string Password;
        public bool LockingState;

    }
}