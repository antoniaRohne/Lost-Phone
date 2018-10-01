using App;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class PasswordPanelView : MonoBehaviour
{
    [SerializeField] private Text _inputtext;
    [SerializeField] private Image _indicator;
    [SerializeField] private Image _unlockStateImage;
    [SerializeField] private GameObject passwordPanelPrefab;
    [SerializeField] private Sprite _unlockStateSprite;

    private GameObject lockingPanel;
    
    public IReadOnlyReactiveProperty<string> password { get; set; }

    public void CreatePasswordPanel(IAppLockingSystem app)
    {
        password = _inputtext.ObserveEveryValueChanged(text => text.text).ToReactiveProperty();	
    }

    public void Unlock()
    {
        _indicator.color = Color.green;
        _unlockStateImage.sprite = _unlockStateSprite;
    }

    public void Destroy()
    {
        Destroy(lockingPanel);
    }
}
