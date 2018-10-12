using UnityEngine;
using UnityEngine.UI;

public class MessageView : MonoBehaviour
{

	[SerializeField] public Text MessageText;
	[SerializeField] private HorizontalLayoutGroup _messageContent;

	public void setAlignmentToRight()
	{
		_messageContent.childAlignment = TextAnchor.UpperRight;
		MessageText.alignment = TextAnchor.UpperRight;
	}
	
}
