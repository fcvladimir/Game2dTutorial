using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerController : KinematicObject
    {
        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float maxSpeed = 7;
        /// <summary>
        /// Initial jump velocity at the start of a jump.
        /// </summary>
        public float jumpTakeOffSpeed = 7;

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        /*internal new*/
        public Collider2D collider2d;
        /*internal new*/
        public AudioSource audioSource;
        public PlayerHealth health;
        public bool controlEnabled = true;

        private readonly float koef = 7.3f;
        private bool jump;
        private Vector2 move;
        private SpriteRenderer spriteRenderer;
        internal Animator animator;
        private readonly PlatformerModel model = GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;

        public ButtonStateTracker jumpButtonTracker;
        public ButtonStateTracker leftButtonTracker;
        public ButtonStateTracker rightButtonTracker;
        public ParticleSystem dust;

        private void Awake()
        {
            health = GetComponent<PlayerHealth>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();

            transform.position = model.spawnPoint.position;
        }

        protected override void Update()
        {
            if (controlEnabled)
            {
                if (Application.platform == RuntimePlatform.Android)
                {
                    UpdatePosition();
                }
                else
                {
                    move.x = Input.GetAxis("Horizontal");
                    if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
                        StartJump();
                    else if (Input.GetButtonUp("Jump"))
                    {
                        StopJump();
                    }
                }
            }
            else
            {
                move.x = 0;
            }
            UpdateJumpState();
            base.Update();
        }

        private void UpdatePosition()
        {
            if (!controlEnabled) return;
            if (jumpButtonTracker != null && jumpButtonTracker.IsPressed)
            {
                StartJump();
            }
            else
            {
                StopJump(); // stop jumping
            }

            if (rightButtonTracker != null && rightButtonTracker.IsPressed)
            {
                move.x = +0.1f * koef;
            }
            else if (leftButtonTracker != null && leftButtonTracker.IsPressed)
            {
                move.x = -0.1f * koef;
            }
            else
            {
                move.x = 0; // stop moving
            }
        }

        private void UpdateJumpState()
        {
            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;
                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        Schedule<PlayerJumped>().player = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    CreateDust();
                    break;
            }
        }

        protected override void ComputeVelocity()
        {
            if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y *= model.jumpDeceleration;
                }
            }

            if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }

        private void StartJump()
        {
            jumpState = JumpState.PrepareToJump;
        }

        private void StopJump()
        {
            stopJump = true;
            Schedule<PlayerStopJump>().player = this;
        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }

        private void Log(string msg)
        {
            Debug.Log("DEBUG: " + msg);
        }

        private void CreateDust()
        {
            dust.transform.position = transform.position;
            dust.Play();
        }

        public void UpdateColor()
        {
            Color spriteRendererColor;
            if (GamePreferences.SelectedHero == 0)
            {
                spriteRendererColor = new Color(0f, 0.4990942f, 1f, 1f);
            }
            else
            {
                spriteRendererColor = new Color(0f, 0.63869f, 1f, 1f);
            }
            spriteRenderer.color = spriteRendererColor;
        }

        public void UpdateSpawnPoint(Vector3 position)
        {
            model.spawnPoint.position = position;
        }
    }
}