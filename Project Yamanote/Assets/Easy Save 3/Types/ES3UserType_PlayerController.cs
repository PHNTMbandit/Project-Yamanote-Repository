using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("playerData", "isSeated", "<FacingDirection>k__BackingField", "actionTextBox", "actionText", "playerCollider", "phone", "StateMachine", "FacingDirection")]
	public class ES3UserType_PlayerController : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_PlayerController() : base(typeof(PlayerController)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (PlayerController)obj;
			
			writer.WritePrivateFieldByRef("playerData", instance);
			writer.WriteProperty("isSeated", instance.isSeated, ES3Type_bool.Instance);
			writer.WritePrivateField("<FacingDirection>k__BackingField", instance);
			writer.WritePrivateFieldByRef("actionTextBox", instance);
			writer.WritePropertyByRef("actionText", instance.actionText);
			writer.WritePropertyByRef("playerCollider", instance.playerCollider);
			writer.WritePropertyByRef("phone", instance.phone);
			writer.WritePrivateProperty("StateMachine", instance);
			writer.WritePrivateProperty("FacingDirection", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (PlayerController)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "playerData":
					reader.SetPrivateField("playerData", reader.Read<PlayerData>(), instance);
					break;
					case "isSeated":
						instance.isSeated = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "<FacingDirection>k__BackingField":
					reader.SetPrivateField("<FacingDirection>k__BackingField", reader.Read<System.Int32>(), instance);
					break;
					case "actionTextBox":
					reader.SetPrivateField("actionTextBox", reader.Read<UnityEngine.GameObject>(), instance);
					break;
					case "actionText":
						instance.actionText = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "playerCollider":
						instance.playerCollider = reader.Read<UnityEngine.Collider2D>();
						break;
					case "phone":
						instance.phone = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "StateMachine":
					reader.SetPrivateProperty("StateMachine", reader.Read<PlayerStateMachine>(), instance);
					break;
					case "FacingDirection":
					reader.SetPrivateProperty("FacingDirection", reader.Read<System.Int32>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_PlayerControllerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_PlayerControllerArray() : base(typeof(PlayerController[]), ES3UserType_PlayerController.Instance)
		{
			Instance = this;
		}
	}
}