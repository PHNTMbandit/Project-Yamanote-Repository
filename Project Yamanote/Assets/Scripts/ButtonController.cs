using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI _text;
    private bool toggle = false;
    [SerializeField] private GameObject toggleGameObject;
    [SerializeField] private AudioManager audioManager;

    // Turn off at awake
    private void Start()
    {
        _text.enabled = false;
    }

    // Show text
    public void OnPointerEnter(PointerEventData eventData)
    {
        _text.enabled = true;
    }

    // Hide text
    public void OnPointerExit(PointerEventData eventData)
    {
        _text.enabled = false;
    }

    public void ClickButton()
    {
        audioManager.Play("ClickButton");
    }

    public void Toggle()
    {
        if (!toggle)
        {
            toggleGameObject.SetActive(true);
            toggle = true;

        }
        else
        {
            toggleGameObject.SetActive(false);
            toggle = false;
        }
    }
}
