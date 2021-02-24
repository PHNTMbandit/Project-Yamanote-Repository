using UnityEngine;

namespace ProjectYamanote.Triggers
{
    public class ResetStation : MonoBehaviour
    {
        [SerializeField] private Station.Station _station;

        private void Start()
        {
            string lastScene = PlayerPrefs.GetString("LastScene", null);
            if (lastScene != null)
            {
                if (lastScene == "Shin-Aomori Station_Exterior")
                {
                    _station.StateMachine.ChangeState(_station.DespawnState);
                    print("entered station");
                }
            }
        }
    }
}
