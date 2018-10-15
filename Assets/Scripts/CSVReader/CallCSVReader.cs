using System;
using UnityEngine;

namespace CSVReader
{
    public class CallCSVReader: CSVReader<Call>
    {  
        public  CallCSVReader() : base(){}

        protected override void GetContent()
        {
            TextAsset calls = Resources.Load<TextAsset>("CSVFiles/Calls");
		
            string[] callPersonList = calls.text.Split(new char[] {'\n'});

            for (var i = 0; i < callPersonList.Length; i++)
            {
                Call call = new Call();
                string[] callInfo = callPersonList[i].Split(new char[] {','});
                call.Caller = callInfo[0];
                call.CallTime =  callInfo[1];
                call.AmountOfCalls = Convert.ToInt32(callInfo[2]);
                Data.Add(call);
            }
        }
    }
}
