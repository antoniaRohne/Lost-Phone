using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MemoCSVReader
{

	private readonly string[] _memoList;
	
	public MemoCSVReader()
	{
		TextAsset _memos = Resources.Load<TextAsset>("CSVFiles/Memos");
		
		_memoList = _memos.text.Split(new char[] {'\n'}).Where(x => x!= "").ToArray();
	}

	public string[] GetMemos()
	{
		return _memoList;
	}
}
