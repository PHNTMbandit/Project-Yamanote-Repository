using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("<StateMachine>k__BackingField", "isArrived", "isDeparted", "_parallaxBackground", "departTransform", "arrivedTransfrom", "arrivingTransform", "trainData", "trainStation", "StateMachine")]
	public class ES3UserType_Train : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Train() : base(typeof(Train)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (Train)obj;
			
			writer.WritePrivateField("<StateMachine>k__BackingField", instance);
			writer.WriteProperty("isArrived", instance.isArrived, ES3Type_bool.Instance);
			writer.WriteProperty("isDeparted", instance.isDeparted, ES3Type_bool.Instance);
			writer.WritePrivateField("_parallaxBackground", instance);
			writer.WritePropertyByRef("departTransform", instance.departTransform);
			writer.WritePropertyByRef("arrivedTransfrom", instance.arrivedTransfrom);
			writer.WritePropertyByRef("arrivingTransform", instance.arrivingTransform);
			writer.WritePropertyByRef("trainData", instance.trainData);
			writer.WritePropertyByRef("trainStation", instance.trainStation);
			writer.WritePrivateProperty("StateMachine", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (Train)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "<StateMachine>k__BackingField":
					reader.SetPrivateField("<StateMachine>k__BackingField", reader.Read<TrainStateMachine>(), instance);
					break;
					case "isArrived":
						instance.isArrived = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "isDeparted":
						instance.isDeparted = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "_parallaxBackground":
					reader.SetPrivateField("_parallaxBackground", reader.Read<UnityEngine.GameObject[]>(), instance);
					break;
					case "departTransform":
						instance.departTransform = reader.Read<UnityEngine.Transform>(ES3UserType_Transform.Instance);
						break;
					case "arrivedTransfrom":
						instance.arrivedTransfrom = reader.Read<UnityEngine.Transform>(ES3UserType_Transform.Instance);
						break;
					case "arrivingTransform":
						instance.arrivingTransform = reader.Read<UnityEngine.Transform>(ES3UserType_Transform.Instance);
						break;
					case "trainData":
						instance.trainData = reader.Read<TrainData>();
						break;
					case "trainStation":
						instance.trainStation = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "StateMachine":
					reader.SetPrivateProperty("StateMachine", reader.Read<TrainStateMachine>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_TrainArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TrainArray() : base(typeof(Train[]), ES3UserType_Train.Instance)
		{
			Instance = this;
		}
	}
}