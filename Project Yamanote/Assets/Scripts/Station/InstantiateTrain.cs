using UnityEngine;

namespace ProjectYamanote.Station
{
    public class InstantiateTrain : MonoBehaviour
    {
        [SerializeField] private GameObject _ouLine;
        [SerializeField] private Transform _arrivalPosition;
        [SerializeField] private Transform _instantiatePosition;
        [SerializeField] private Transform _despawnPosition;
        [SerializeField] private Station _station;

        private Animator _tsugaruLineAnimator;

        private void Start()
        {
            string lastScene = PlayerPrefs.GetString("LastScene", null);
            if (lastScene != null)
            {
                switch (lastScene)
                {
                    case "Ou Line":
                        print("exited Ou line");
                        _ouLine.transform.position = _arrivalPosition.position;
                        _station.StateMachine.ChangeState(_station.IdleState);
                        break;
                }
            }
        }
    }
}