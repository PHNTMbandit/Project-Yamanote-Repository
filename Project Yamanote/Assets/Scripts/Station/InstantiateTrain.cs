using UnityEngine;

namespace ProjectYamanote.Assets.Scripts.Station
{
    public class InstantiateTrain : MonoBehaviour
    {
        [SerializeField] private GameObject _tsugaruLine;
        [SerializeField] private Transform _departTransform;
        [SerializeField] private Transform _arrivedTransfrom;
        [SerializeField] private Transform _arrivingTransform;
        [SerializeField] private Station _station;

        private void Start()
        {
            string lastScene = PlayerPrefs.GetString("LastScene", null);
            if (lastScene != null)
            {
                switch (lastScene)
                {
                    case "Tsugaru Line":
                        Instantiate(_tsugaruLine, _arrivedTransfrom);
                        train.StateMachine.ChangeState(train.)
                        break;
                }
            }
        }
    }
}
