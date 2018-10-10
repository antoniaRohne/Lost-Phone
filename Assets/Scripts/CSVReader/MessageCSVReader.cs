using System.Collections.Generic;
using UnityEngine;

public class MessageCSVReader
{
    private readonly Dictionary<string, string[]> _messagesDictionary;
    
     public MessageCSVReader()
     {
        _messagesDictionary = new Dictionary<string, string[]>();
        TextAsset messages = Resources.Load<TextAsset>("CSVFiles/Messages");
		
        string[] messagePersonList = messages.text.Split(new char[] {'\n'});

        for (var i = 0; i < messagePersonList.Length-1; i++)
        {
            string[] messagesInfo = messagePersonList[i].Split(new char[] {','});
            _messagesDictionary.Add(messagesInfo[0], messagesInfo);
        }
     }

    public Dictionary<string,string[]> GetUpdatedContacts()
    {
        return _messagesDictionary;
    }

}
