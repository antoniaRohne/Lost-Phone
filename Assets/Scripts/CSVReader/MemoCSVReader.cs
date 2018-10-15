using System.Linq;
using UnityEngine;

namespace CSVReader
{
	public class MemoCSVReader :CSVReader<string>
	{	
		public MemoCSVReader():base(){}

		protected override void GetContent()
		{
			TextAsset memos = Resources.Load<TextAsset>("CSVFiles/Memos");
		
			string[] _memoList = memos.text.Split(new char[] {'\n'}).Where(x => x!= "").ToArray();
			foreach (string s in _memoList)
			{
				Data.Add(s);
			}
		}
	}
}
