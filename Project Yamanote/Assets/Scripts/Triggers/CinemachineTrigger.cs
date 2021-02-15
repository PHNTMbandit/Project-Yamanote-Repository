using UnityEngine;
using Cinemachine;

namespace ProjectYamanote.Triggers
{
    public class CinemachineTrigger : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _newCamera;
        [SerializeField] private CinemachineVirtualCamera _playerCamera;
        [SerializeField] private Collider2D trigger;
        [SerializeField] private int newPriority;
        [SerializeField] private int oldPriority;

        void Start()
        {
            trigger = trigger.GetComponent<Collider2D>();
            _newCamera = _newCamera.GetComponent<CinemachineVirtualCamera>();
            _playerCamera = _playerCamera.GetComponent<CinemachineVirtualCamera>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _newCamera.Priority = newPriority;
            _playerCamera.Priority = oldPriority;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _playerCamera.Priority = newPriority;
            _newCamera.Priority = oldPriority;
        }
    }
}