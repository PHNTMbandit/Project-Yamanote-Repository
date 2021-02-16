using UnityEngine;

namespace ProjectYamanote.Player
{
    [CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("Move State")]
        public float movementVelocity = 1.7f;

        [Header("Energy and Hunger")]
        public float energyBarSpendRate = 0.1f;
        public float hungerBarSpendRate = 0.5f;
    }
}
