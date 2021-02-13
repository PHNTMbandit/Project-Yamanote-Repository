using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using PixelCrushers.DialogueSystem;

public class PlayerController : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerSitDownState SitDownState { get; private set; }
    public PlayerSitUpState SitUpState { get; private set; }
    public PlayerPhoneOnState PhoneOnState { get; private set; }
    public PlayerPhoneOffState PhoneOffState { get; private set; }

    [SerializeField] private PlayerData playerData;
    #endregion

    #region Components
    public Animator PlayerAnimator { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public string PlayerCollision { get; private set; }
    #endregion

    #region Check Variables
    public bool IsColliding { get; private set; }
    public bool isSeated;
    #endregion

    #region Other Variables
    public int FacingDirection { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }
    private Vector2 _workspace;
    [SerializeField] private GameObject actionTextBox;
    public TextMeshProUGUI actionText;
    public Collider2D playerCollider;
    public GameObject phone;
    public Animator PhoneAnimator { get; private set; }
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        SitDownState = new PlayerSitDownState(this, StateMachine, playerData, "sitDown");
        SitUpState = new PlayerSitUpState(this, StateMachine, playerData, "sitUp");
        PhoneOnState = new PlayerPhoneOnState(this, StateMachine, playerData, "phoneOn");
        PhoneOffState = new PlayerPhoneOffState(this, StateMachine, playerData, "phoneOff");
    }

    private void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
        PhoneAnimator = phone.GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();

        FacingDirection = 1;

        StateMachine.Initialise(IdleState);
    }

    private void Update()
    {
        CurrentVelocity = RB.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Set Functions
    public void SetVelocityX(float velocity)
    {
        _workspace.Set(velocity, CurrentVelocity.y);
        RB.velocity = _workspace;
        CurrentVelocity = _workspace;
    }

    #endregion

    #region Check Functions
    public void CheckIfShouldFlip(int xInput)
    {
        if(xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        IsColliding = true;
        PlayerCollision = collision.tag;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        IsColliding = false;
        PlayerCollision = "null";
    }
    #endregion

    #region Other Functions
    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
        actionText.transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    #endregion

    #region SFX Functions
    public void PhoneOnSFX()
    {
        FindObjectOfType<AudioManager>().Play("PhoneOn");
    }

    public void PhoneOffSFX()
    {
        FindObjectOfType<AudioManager>().Play("PhoneOff");
    }
    #endregion
}
