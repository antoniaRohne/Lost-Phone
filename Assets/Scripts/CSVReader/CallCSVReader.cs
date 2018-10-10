using System;
using System.Collections.Generic;
using UnityEngine;

public class CallCSVReader:ICSVReader<Call>
{
    private readonly List<Call> _callList;
    
     public CallCSVReader()
     {
         _callList = new List<Call>();
        TextAsset calls = Resources.Load<TextAsset>("CSVFiles/Calls");
		
        string[] callPersonList = calls.text.Split(new char[] {'\n'});

        for (var i = 0; i < callPersonList.Length; i++)
        {
            Call call = new Call();
            string[] callInfo = callPersonList[i].Split(new char[] {','});
            call.Caller = callInfo[0];
            call.CallTime =  callInfo[1];
            call.AmountOfCalls = Convert.ToInt32(callInfo[2]);
            Debug.Log(callInfo);
            _callList.Add(call);
        }
     }

    public List<Call> GetList()
    {
        return _callList;
    }
}
