using ProjectYamanote.Audio;
using UnityEngine;

namespace ProjectYamanote.Player
{
    public class PlayerSFX : MonoBehaviour
    {
        [SerializeField] private AudioManager audioManager;

        public void Walk()
        {
            audioManager.Play("Walk");
        }
    }
}