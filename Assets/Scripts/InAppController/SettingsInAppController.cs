using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        StartCoroutine(DestroyObject(banner));
    }
    
    IEnumerator DestroyObject(GameObject obj)
    {
        yield return new WaitForSeconds(_timeOfBanner);
        Destroy(obj);
    }

}
