using UnityEngine;

namespace CSVReader
{
    public class MessageCSVReader: CSVReader<string[]>
    {    
        public MessageCSVReader(): base(){}

        protected override void GetContent()
        {
            TextAsset messages = Resources.Load<TextAsset>("CSVFiles/Messages");
		
            string[] messagePersonList = messages.text.Split(new char[] {'\n'});

            for (var i = 0; i < messagePersonList.Length-1; i++)
            {
                string[] messagesInfo = messagePersonList[i].Split(new char[] {','});
                Data.Add(messagesInfo);
            }
        }
    }
}
