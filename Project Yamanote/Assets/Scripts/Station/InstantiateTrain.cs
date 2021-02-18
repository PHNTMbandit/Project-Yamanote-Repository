using System.Collections;
using UnityEngine;

namespace ProjectYamanote.Station
{
    public class InstantiateTrain : MonoBehaviour
    {
        [SerializeField] private GameObject _tsugaruLine;
        [SerializeField] private GameObject _ouLine;
        [SerializeField] private Transform _arrivalPosition;
        [SerializeField] private Transform _instantiatePosition;
        [SerializeField] private Transform _despawnPosition;
        [SerializeField] private Station _station;

        private Animator _tsugaruLineAnimator;

        private void Start()
        {
            _tsugaruLineAnimator = GetComponent<Animator>();

            string lastScene = PlayerPrefs.GetString("LastScene", null);
            if (lastScene != null)
            {
                switch (lastScene)
                {
                    case "Tsugaru Line":
                        print("exited tsugaru line");
                        _tsugaruLine.transform.position = _arrivalPosition.position;
                        break;
                }
            }
        }
    }
}
