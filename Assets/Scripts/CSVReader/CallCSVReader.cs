using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CallCSVReader:ICSVReader<Call>
{
    private List<Call> _callList;
    
     public CallCSVReader()
     {
         _callList = new List<Call>();
        TextAsset _calls = Resources.Load<TextAsset>("CSVFiles/Calls");
		
        string[] _callPersonList = _calls.text.Split(new char[] {'\n'});

        for (var i = 0; i < _callPersonList.Length; i++)
        {
            Call call = new Call();
            string[] _call = _callPersonList[i].Split(new char[] {','});
            call.Caller = _call[0];
            call.CallTime =  _call[1];
            call.AmountOfCalls = Convert.ToInt32(_call[2]);
            Debug.Log(call);
            _callList.Add(call);
        }
     }

    public List<Call> GetList()
    {
        return _callList;
    }
}
