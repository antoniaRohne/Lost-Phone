using System;
using System.Collections.Generic;
using UnityEngine;

public class MemoCSVReader
{

	private readonly string[] _memoList;
	
	public MemoCSVReader()
	{
		TextAsset _memos = Resources.Load<TextAsset>("CSVFiles/Memos");
		
		_memoList = _memos.text.Split(new char[] {'\n'});
	}

	public string[] GetMemos()
	{
		return _memoList;
	}
}
