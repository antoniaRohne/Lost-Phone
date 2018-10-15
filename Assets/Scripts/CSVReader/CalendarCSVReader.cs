using System;
using UnityEngine;

namespace CSVReader
{
	public class CalendarCSVReader : CSVReader<CalendarEntry>
	{
		public CalendarCSVReader() : base(){}

		protected override void GetContent()
		{
			TextAsset calendarEntries = Resources.Load<TextAsset>("CSVFiles/Calendar");
		
			string[] calendarEntriesList = calendarEntries.text.Split(new char[] {'\n'});

			for (var i = 0; i < calendarEntriesList.Length; i++)
			{
				CalendarEntry entry = new CalendarEntry();
				string[] entryInfo = calendarEntriesList[i].Split(new char[] {','});
				entry.Day = Int32.Parse(entryInfo[0]);
				entry.Event =  entryInfo[1];
				entry.Time = entryInfo[2];
				Data.Add(entry);
			}
		}
	}
}
