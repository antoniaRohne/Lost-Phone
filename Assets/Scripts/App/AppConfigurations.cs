using UnityEditor;
using UnityEngine;

namespace App
{
    [CreateAssetMenu(menuName = "App")]
    public class AppConfigurations : ScriptableObject, IAppLockingSystem, IAppSceneLoading
    {
        [SerializeField] private AppEnum _app;
        [SerializeField] private Sprite _icon;
        [SerializeField] private SceneAsset _scene;
        [SerializeField] private bool _lockingState;
        [SerializeField] private string _password;
        [SerializeField] private string _pushNoteContent;


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