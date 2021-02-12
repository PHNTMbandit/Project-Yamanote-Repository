using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;

public class FacingDirectionSaver : MonoBehaviour
{
    public PlayerController player;

    private string ActorName
    {
        get { return OverrideActorName.GetActorName(transform); }
    }

    public void OnRecordPersistentData()
    {
        DialogueLua.SetVariable("FacingDirection", player.FacingDirection);
    }

    public void OnApplyPersistentData()
    {
        StartCoroutine(DelayedApply());
    }

    public IEnumerator DelayedApply()
    {
        yield return null; // Wait 1 frame for other scripts to initialize.
        int myData = DialogueLua.GetVariable("FacingDirection").AsInt;
    }

    public void OnEnable()
    {
        PersistentDataManager.RegisterPersistentData(this.gameObject);
    }

    public void OnDisable()
    {
        // Unsubscribe the GameObject from PersistentDataManager notifications:
        PersistentDataManager.RegisterPersistentData(this.gameObject);
    }
}