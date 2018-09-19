using System.Net.Mime;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PushNotificationConfig : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _content;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _title;

    public string Content
    {
        get { return _content.text; }
        set { _content.text = value; }
    }
    
    public string Title
    {
        get { return _title.text; }
        set { _title.text = value; }
    }
    
    public Sprite Icon
    {
        get { return _icon.sprite; }
        set { _icon.sprite = value; }
    }
    
}