using UnityEditor;
using UnityEngine;

namespace App
{
    [CreateAssetMenu(menuName = "App")]
    public class AppConfigurations : ScriptableObject, IAppLockingSystem, IAppSceneLoading
    {
        public AppEnum _app;
        public Sprite _icon;
        public SceneAsset _scene;
        public bool _lockingState;
        public string _password;
        public string _pushNoteContent;
       
       
        public SceneAsset Scene
        {
            get { return _scene; }
        }
       
        public string PushNoteContent
        {
            get { return _pushNoteContent; }
        }

        public AppEnum Name
        {
            get { return _app; }
        }

        public string Password
        {
            get { return _password; }
        }
        public Sprite Icon
        {
            get { return _icon; }
        }
        
        public bool LockingState
        {
            get { return _lockingState;}
            set { _lockingState = value; }}
    }

    //Interface -> in andere dateien
    //properties passend zu usecases

    public interface IAppLockingSystem
    {
        AppEnum Name { get; }
        string Password { get; }
        bool LockingState { get; set; }
    }

    public interface IAppSceneLoading
    {
        AppEnum Name { get; }
        SceneAsset Scene { get; }
    }

}