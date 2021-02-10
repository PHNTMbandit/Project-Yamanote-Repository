using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [Header("Declarables")]
    [SerializeField]
    private GameObject inventorySystem;
    [SerializeField]
    private GameObject HUD;
    [SerializeField]
    private GameObject dialogueSystem;

    public void Inventory()
    {
        HUD.SetActive(false);
        dialogueSystem.SetActive(false);
        inventorySystem.SetActive(true);
    }
}
