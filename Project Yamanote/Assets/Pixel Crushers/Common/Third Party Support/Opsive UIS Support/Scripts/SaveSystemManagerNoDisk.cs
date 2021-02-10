using System.Collections.Generic;
using UnityEngine;

namespace Opsive.UltimateInventorySystem.SaveSystem
{
    /// <summary>
    /// When using the Pixel Crushers Save System, use this instead of SaveSystemManager.
    /// This version doesn't save to disk since the Pixel Crushers Save System will save
    /// to disk or whichever SavedGameDataStorer you've specified.
    /// </summary>
    public class SaveSystemManagerNoDisk : SaveSystemManager
    {
        /// <summary>
        /// Since we get the saves from the Pixel Crushers Save System, just create
        /// stubs for the save data.
        /// </summary>
        protected override void GetSavesFromDisk(ref Dictionary<int, SaveData> saves)
        {
            for (int i = 0; i < m_MaxSaves; i++)
            {
                saves.Add(i, new SaveData());
            }
        }

        /// <summary>
        /// Don't actually write to disk (since the Pixel Crushers Save System will
        /// write to its data storer location instead), but update the additional
        /// information that SaveToDiskInternal also sets.
        /// </summary>
        /// <param name="saveIndex"></param>
        protected override void SaveToDiskInternal(int saveIndex)
        {
            m_SaveData.SetDateTime(System.DateTime.Now);
            m_Saves[saveIndex] = new SaveData(m_SaveData);
        }

        /// <summary>
        /// Assume that m_SaveData has been set by the UISSaver using SetCurrentSaveData.
        /// Just apply the current m_SaveData.
        /// </summary>
        protected override void LoadInternal(int saveIndex)
        {
            if (m_SaveData == null)
            { 
                Debug.LogError($"Cannot load save at index {saveIndex}.");
                return;
            }

            OrderSaversByPriority(false);
            for (int i = 0; i < m_Savers.Count; i++)
            {
                m_Savers[i].Load();
            }
        }
    }
}
