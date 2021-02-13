using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    public void Walk()
    {
        audioManager.Play("Walk");
    }
}
