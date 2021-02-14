using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("year", "month", "day", "hour", "minute", "second", "dateTime", "uiClock", "DNC", "energyBar", "hungerBar", "playerData", "phoneTime", "phoneDate", "actionBarTime", "actionBarDate")]
	public class ES3UserType_GameClock : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_GameClock() : base(typeof(GameClock)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (GameClock)obj;
			
			writer.WriteProperty("year", GameClock.year, ES3Type_int.Instance);
			writer.WriteProperty("month", GameClock.month, ES3Type_int.Instance);
			writer.WriteProperty("day", GameClock.day, ES3Type_int.Instance);
			writer.WriteProperty("hour", GameClock.hour, ES3Type_int.Instance);
			writer.WriteProperty("minute", GameClock.minute, ES3Type_int.Instance);
			writer.WriteProperty("second", GameClock.second, ES3Type_int.Instance);
			writer.WriteProperty("dateTime", GameClock.dateTime, ES3Type_DateTime.Instance);
			writer.WritePropertyByRef("uiClock", instance.uiClock);
			writer.WritePropertyByRef("DNC", instance.DNC);
			writer.WritePropertyByRef("energyBar", instance.energyBar);
			writer.WritePropertyByRef("hungerBar", instance.hungerBar);
			writer.WritePropertyByRef("playerData", instance.playerData);
			writer.WritePropertyByRef("phoneTime", instance.phoneTime);
			writer.WritePropertyByRef("phoneDate", instance.phoneDate);
			writer.WritePropertyByRef("actionBarTime", instance.actionBarTime);
			writer.WritePropertyByRef("actionBarDate", instance.actionBarDate);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (GameClock)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "year":
						GameClock.year = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "month":
						GameClock.month = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "day":
						GameClock.day = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "hour":
						GameClock.hour = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "minute":
						GameClock.minute = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "second":
						GameClock.second = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "dateTime":
						GameClock.dateTime = reader.Read<System.DateTime>(ES3Type_DateTime.Instance);
						break;
					case "uiClock":
						instance.uiClock = reader.Read<UI_Clock>();
						break;
					case "DNC":
						instance.DNC = reader.Read<DayNightCycle>();
						break;
					case "energyBar":
						instance.energyBar = reader.Read<EnergyBar>();
						break;
					case "hungerBar":
						instance.hungerBar = reader.Read<HungerBar>();
						break;
					case "playerData":
						instance.playerData = reader.Read<PlayerData>();
						break;
					case "phoneTime":
						instance.phoneTime = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "phoneDate":
						instance.phoneDate = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "actionBarTime":
						instance.actionBarTime = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "actionBarDate":
						instance.actionBarDate = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_GameClockArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_GameClockArray() : base(typeof(GameClock[]), ES3UserType_GameClock.Instance)
		{
			Instance = this;
		}
	}
}