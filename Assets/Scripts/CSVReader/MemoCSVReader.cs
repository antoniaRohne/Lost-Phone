using System.Linq;
using UnityEngine;

public class MemoCSVReader
{

	private readonly string[] _memoList;
	
	public MemoCSVReader()
	{
		TextAsset memos = Resources.Load<TextAsset>("CSVFiles/Memos");
		
		_memoList = memos.text.Split(new char[] {'\n'}).Where(x => x!= "").ToArray();
	}

	public string[] GetMemos()
	{
		return _memoList;
	}
}
