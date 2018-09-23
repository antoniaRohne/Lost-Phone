using UnityEngine;
using UnityEngine.UI;

public class ContactPanelView: MonoBehaviour
{
    [SerializeField]
    private Text _surname;
    [SerializeField]
    private Text _name;
    [SerializeField]
    private Text _age;
    [SerializeField]
    private Text _email;
    [SerializeField]
    private Text _sex;
    [SerializeField]
    private Image _image;
	
    public string Surname
    {
        get { return _surname.text; }
        set { _surname.text = value; }
    }
    public string Name
    {
        get { return _name.text; }
        set { _name.text = value; }
    }
    public string Age
    {
        get { return _age.text; }
        set { _age.text = value; }
    }
    public string EMail
    {
        get { return _email.text; }
        set { _email.text = value; }
    }
    public string Sex
    {
        get { return _sex.text; }
        set { _sex.text = value; }
    }
    public Image Image
    {
        get { return _image; }
        set { _image = value; }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Destroy(this.gameObject);
        }
    }
	
}
