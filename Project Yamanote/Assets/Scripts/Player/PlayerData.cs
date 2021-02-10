using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newPlayerData", menuName ="Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 1.7f;

    [Header("Energy and Health")]
    public float energyBarSpendRate = 0.1f;
    public float hungerBarSpendRate = 0.5f;
}