using UnityEngine;

namespace ProjectYamanote.Station
{
    public class InstantiateTrain : MonoBehaviour
    {
        [SerializeField] private GameObject _ouLine;
        [SerializeField] private StationController _station;

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
                        _ouLine.transform.position = new Vector3(-20.34f, -0.03298116f, 0f);
                        _station.StateMachine.ChangeState(_station.IdleState);
                        break;
                }
            }
        }
    }
}