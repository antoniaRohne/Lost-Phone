using App;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InternetInAppController : MonoBehaviour
{


    [SerializeField] private AppConfigurations _settings;

    public void Exit()
    {
        SceneManager.UnloadSceneAsync(this.gameObject.scene);
        AppController.Instance.BackToMainMenu();
    }
    
    public void GoToSettings()
    {
        SceneManager.UnloadSceneAsync(this.gameObject.scene);
        AppController.Instance.LoadScene(_settings, _settings);
    }

}
