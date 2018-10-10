using System;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsInAppController : MonoBehaviour
{

    [SerializeField] private GameObject _bannerPrefab;
    [SerializeField] private float _timeOfBanner;
    [SerializeField] private GameObject _parent;

    public void Exit()
    {
        SceneManager.UnloadSceneAsync(this.gameObject.scene);
        AppController.Instance.BackToMainMenu();
    }

    public void showNoInternetBanner()
    {
        GameObject banner = Instantiate(_bannerPrefab, _parent.transform);
        Observable.Timer(TimeSpan.FromSeconds(_timeOfBanner)).Subscribe(x => DestroyObject(banner));
    }
    
    private void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }

}
