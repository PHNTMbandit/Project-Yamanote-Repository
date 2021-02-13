using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("<StateMachine>k__BackingField", "<Animator>k__BackingField", "isArrived", "isDeparting", "_stationData", "_arrivalPosition", "_instantiatePosition", "_despawnPosition", "_train", "StateMachine", "Animator", "enabled", "name")]
	public class ES3UserType_Station : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Station() : base(typeof(Station)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (Station)obj;
			
			writer.WritePrivateField("<StateMachine>k__BackingField", instance);
			writer.WritePrivateFieldByRef("<Animator>k__BackingField", instance);
			writer.WriteProperty("isArrived", instance.isArrived, ES3Type_bool.Instance);
			writer.WriteProperty("isDeparting", instance.isDeparting, ES3Type_bool.Instance);
			writer.WritePrivateFieldByRef("_stationData", instance);
			writer.WritePrivateFieldByRef("_arrivalPosition", instance);
			writer.WritePrivateFieldByRef("_instantiatePosition", instance);
			writer.WritePrivateFieldByRef("_despawnPosition", instance);
			writer.WritePrivateFieldByRef("_train", instance);
			writer.WritePrivateProperty("StateMachine", instance);
			writer.WritePrivatePropertyByRef("Animator", instance);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (Station)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "<StateMachine>k__BackingField":
					reader.SetPrivateField("<StateMachine>k__BackingField", reader.Read<StationStateMachine>(), instance);
					break;
					case "<Animator>k__BackingField":
					reader.SetPrivateField("<Animator>k__BackingField", reader.Read<UnityEngine.Animator>(), instance);
					break;
					case "isArrived":
						instance.isArrived = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "isDeparting":
						instance.isDeparting = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "_stationData":
					reader.SetPrivateField("_stationData", reader.Read<StationData>(), instance);
					break;
					case "_arrivalPosition":
					reader.SetPrivateField("_arrivalPosition", reader.Read<UnityEngine.Transform>(), instance);
					break;
					case "_instantiatePosition":
					reader.SetPrivateField("_instantiatePosition", reader.Read<UnityEngine.Transform>(), instance);
					break;
					case "_despawnPosition":
					reader.SetPrivateField("_despawnPosition", reader.Read<UnityEngine.Transform>(), instance);
					break;
					case "_train":
					reader.SetPrivateField("_train", reader.Read<UnityEngine.GameObject>(), instance);
					break;
					case "StateMachine":
					reader.SetPrivateProperty("StateMachine", reader.Read<StationStateMachine>(), instance);
					break;
					case "Animator":
					reader.SetPrivateProperty("Animator", reader.Read<UnityEngine.Animator>(), instance);
					break;
					case "enabled":
						instance.enabled = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_StationArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_StationArray() : base(typeof(Station[]), ES3UserType_Station.Instance)
		{
			Instance = this;
		}
	}
}