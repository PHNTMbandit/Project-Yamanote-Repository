using UnityEngine;

namespace ProjectYamanote.Assets.Scripts.Station
{
    public class InstantiateTrain : MonoBehaviour
    {
        private void Start()
        {
            string lastScene = PlayerPrefs.GetString("LastScene", null);
            if (lastScene != null)
            {
                if (lastScene == "Tsugaru Line")
                {
                    print("Eureka");
                }
            }
        }
    }
}
