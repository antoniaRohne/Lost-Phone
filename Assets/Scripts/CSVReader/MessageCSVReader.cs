using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MessageCSVReader
{
    private Dictionary<string, string[]> MessagesDictionary;
    
     public MessageCSVReader()
     {
         MessagesDictionary = new Dictionary<string, string[]>();
        TextAsset _messages = Resources.Load<TextAsset>("CSVFiles/Messages");
		
        string[] _messagePersonList = _messages.text.Split(new char[] {'\n'});

        for (var i = 0; i < _messagePersonList.Length-1; i++)
        {
            string[] messages = _messagePersonList[i].Split(new char[] {','});
            MessagesDictionary.Add(messages[0], messages);
        }
     }

    public Dictionary<string,string[]> GetUpdatedContacts()
    {
        return MessagesDictionary;
    }
}
