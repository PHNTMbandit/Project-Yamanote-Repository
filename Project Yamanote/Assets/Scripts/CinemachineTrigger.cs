using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using PixelCrushers.DialogueSystem;

public class CinemachineTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera newCamera;
    [SerializeField] private CinemachineVirtualCamera playerCamera;
    [SerializeField] private Collider2D trigger;
    [SerializeField] private int newPriority;
    [SerializeField] private int oldPriority;

    void Start()
    {
        trigger = trigger.GetComponent<Collider2D>();
        newCamera = newCamera.GetComponent<CinemachineVirtualCamera>();
        playerCamera = playerCamera.GetComponent<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        newCamera.Priority = newPriority;
        playerCamera.Priority = oldPriority;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerCamera.Priority = newPriority;
        newCamera.Priority = oldPriority;
    }
}
