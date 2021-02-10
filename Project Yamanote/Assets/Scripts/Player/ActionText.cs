using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;
using TMPro;

public class ActionText : MonoBehaviour
{   
    [SerializeField] private GameObject actionTextBox;
    [SerializeField] private TextMeshProUGUI actionText;
    [SerializeField] private PlayerController playerController;

    void Awake()
    {
        actionText.enabled = false;
        actionTextBox.SetActive(false);
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(playerController.isSeated == false)
        {
            switch (collision.tag)
            {
                case "Seat":
                    actionText.enabled = true;
                    actionText.text = "Sit";
                    break;
                case "NPC":
                    actionText.enabled = true;
                    actionText.text = "Talk";
                    break;
                case "Door":
                    actionText.enabled = true;
                    actionText.text = "Enter";
                    break;
                default:
                    actionText.enabled = false;
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Removes text when colliding with nothing
        actionText.enabled = false;
    }

    public void OnConversationStart()
    {
        actionText.enabled = false;
    }

    public void OnConversationExit()
    {
        actionText.enabled = true;
    }
}