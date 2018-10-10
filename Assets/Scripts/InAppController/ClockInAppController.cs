using UnityEngine;
using UnityEngine.SceneManagement;

public class ClockInAppController : MonoBehaviour {

	public void Exit()
	{
		SceneManager.UnloadSceneAsync(this.gameObject.scene);
		AppController.Instance.BackToMainMenu();
	}
}
