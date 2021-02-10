using UnityEngine;

namespace PixelCrushers.UISSupport
{
    using Opsive.UltimateInventorySystem.SaveSystem;
    using Opsive.UltimateInventorySystem.UI.Monitors;

    /// <summary>
    /// Incorporates Opsive Ultimate Inventory System's Save System Manager into
    /// the Pixel Crushers Save System.
    /// </summary>
    [AddComponentMenu("Pixel Crushers/Common/Save System/Opsive/UIS Saver")]
    public class UISSaver : Saver
    {
        public int saveSlot = 0;

        public override string RecordData()
        {
            SaveSystemManager.Save(saveSlot);
            return SaveSystem.Serialize(SaveSystemManager.GetCurrentSaveData());
        }

        public override void ApplyData(string s)
        {
            if (string.IsNullOrEmpty(s)) return;
            var data = SaveSystem.Deserialize<SaveData>(s);
            if (data == null) return;
            var inventoryMonitor = FindObjectOfType<InventoryMonitor>();
            var originalMonitorValue = (inventoryMonitor != null) ? inventoryMonitor.enabled : false;
            if (inventoryMonitor != null) inventoryMonitor.enabled = false;
            SaveSystemManager.SetCurrentSaveData(data);
            SaveSystemManager.Load(saveSlot);
            if (inventoryMonitor != null) inventoryMonitor.enabled = originalMonitorValue;
        }

        public override void OnRestartGame()
        {
            SaveSystemManager.DeleteSave(saveSlot);
        }
    }
}
