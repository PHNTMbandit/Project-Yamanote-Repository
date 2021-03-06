﻿using ProjectYamanote.Audio;
using TMPro;
using UnityEngine;

namespace ProjectYamanote.Player
{
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

        #endregion State Variables

        #region Components

        public Animator PlayerAnimator { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        public Rigidbody2D RB { get; private set; }
        public string PlayerCollision { get; private set; }
        public int FacingDirection { get; set; }
        public Vector2 CurrentVelocity { get; private set; }

        #endregion Components

        #region Check Variables

        public bool IsColliding { get; private set; }
        public bool IsFlipped;
        public bool isSeated;

        #endregion Check Variables

        #region Other Variables

        public GameObject actionTextBox;
        public GameObject menu;
        public TextMeshProUGUI actionText;
        public PlayerData playerData;
        public AudioManager audioManager;
        public Collider2D playerCollider;

        private Vector2 _workspace;
        public Animator PhoneAnimator { get; private set; }

        #endregion Other Variables

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
            PhoneAnimator = menu.GetComponent<Animator>();
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

        #endregion Unity Callback Functions

        #region Set Functions

        public void SetVelocityX(float velocity)
        {
            _workspace.Set(velocity, CurrentVelocity.y);
            RB.velocity = _workspace;
            CurrentVelocity = _workspace;
        }

        #endregion Set Functions

        #region Check Functions

        public void CheckIfShouldFlip(int xInput)
        {
            if (xInput != 0 && xInput != FacingDirection)
            {
                Flip();
                IsFlipped = true;
            }
            if (xInput == 1 && xInput == 1)
            {
                IsFlipped = false;
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

        #endregion Check Functions

        #region Other Functions

        private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

        private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

        public void Flip()
        {
            FacingDirection *= -1;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }

        #endregion Other Functions

        #region SFX Functions

        public void PhoneOnSFX()
        {
            audioManager.Play("PhoneOn");
        }

        public void PhoneOffSFX()
        {
            audioManager.Play("PhoneOff");
        }

        #endregion SFX Functions
    }
}