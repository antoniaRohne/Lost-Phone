using App;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class PasswordPanelView : MonoBehaviour
{
    [SerializeField] private Text _inputtext;
    [SerializeField] private Image _indicator;
    [SerializeField] private Image _unlockStateImage;
    [SerializeField] private Sprite _unlockStateSprite;

    private GameObject _lockingPanel;
    
    public IReadOnlyReactiveProperty<string> Password { get; set; }

    public void CreatePasswordPanel(IAppLockingSystem app)
    {
        Password = _inputtext.ObserveEveryValueChanged(text => text.text).ToReactiveProperty();	
    }

    public void Unlock()
    {
        _indicator.color = Color.green;
        _unlockStateImage.sprite = _unlockStateSprite;
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
