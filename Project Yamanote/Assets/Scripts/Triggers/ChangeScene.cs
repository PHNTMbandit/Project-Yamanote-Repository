using PixelCrushers;
using UnityEngine;

namespace ProjectYamanote.Triggers
{
    public class ChangeScene : MonoBehaviour
    {
        public string scene;
        public string spawn;

        public void Exit()
        {
            string currentScene = SaveSystem.GetCurrentSceneName();
            PlayerPrefs.SetString("LastScene", currentScene);
            PlayerPrefs.Save();

            SaveSystem.LoadScene(scene + "@" + spawn);
        }
    }
}