using System;
using System.Collections;
using System.Diagnostics.SymbolStore;
using Attempt_2.Animation;
using Attempt_2.Objects.Doors;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace Attempt_2
{
    public class PlayerMovement2 : MonoBehaviour
    {
       
        
        /** PLAYER STATS **/
        
        public float currentMovementSpeed;
        
        public int currentJumpCount;
        
        public bool isGrounded;
        public bool hasHammer;

        private bool equipHammer;
        private bool canJump = true;
        
        public float jumpHeight = 2.0F;

        public float attackDamage = 30;
        
        /** INPUTS AND DIRECTIONS **/
        public float moveVertical;
        public float moveHorizontal;
        
        private Vector3 input3D;
        private Vector3 direction;

        private bool pressedJump;
        private bool isJumping;
        private bool pressedDraw;
        private bool pressedAttack;
        
        /** SYSTEM AND CONSTANTS **/ 
        
        public float maxMovementSpeed;
        public int maxJumpCount;

        public Rigidbody playerRigidBody;
        public Animator playerAnimator;

        private bool maxJumpCountReached;
        
        public float gravity = 25.0F;
        private float maxVelocityChange = 10.0F;
        private float groundCheckDistance = .2f;

        public float attackTimer;
        public float attackTimerGoal;
        public int currentAttackCount;
        public int queuedHits;
        
        [SerializeField] private LayerMask groundMask;
        public LayerMask enemyLayers;
        
        /** CAMERA **/

        public Transform cam;
        
        private float smoothTurnVelocity;
        private float smoothTurnTime = .1F;
       
        /** ANIMATION **/
        private Animator anim;
        
        [SerializeField] private AnimatorOverrideController[] overrideControllers;
        [SerializeField] private AnimationOverrider overrider;
        
        private static readonly int MovementSpeed = Animator.StringToHash("movement_speed");
        private static readonly int Grounded = Animator.StringToHash("grounded");
        private static readonly int VelocityY = Animator.StringToHash("velocityY");
        private static readonly int PressingJump = Animator.StringToHash("pressed jump");
        private static readonly int PressedJumpTrg = Animator.StringToHash("pressed jump trg");
        private static readonly int PressedUnsheathTrg = Animator.StringToHash("pressed unsheath trg");
        private static readonly int JumpCount = Animator.StringToHash("jump count");
        private static readonly int MaxJumpCountReached = Animator.StringToHash("max jump count reached");
        private static readonly int AttackCount = Animator.StringToHash("attack count");

        /** DEBUG **/
        public float Debug_current_speed;
        
        // Start is called before the first frame update
        private void Start()
        {
            playerRigidBody = GetComponent<Rigidbody>();
            playerAnimator = GetComponent<Animator>();
        }
        
        // Update is called once per frame
        private void Update()
        {
            DebugSpeed();
            
            //Debug.Log(pressedAttack);
            
            isGrounded = Physics.CheckSphere(transform.position,groundCheckDistance, groundMask);

            Inputs();
            PlayerAttack();
            PlayerDraw();
            PlayerJump();
            Animation();
        }
        private void Inputs()
        {
            pressedJump = Input.GetButtonDown("Jump");
            pressedDraw = Input.GetButtonDown("Fire1");
            pressedAttack = Input.GetButtonDown("Fire3");
            
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical   = Input.GetAxis("Vertical");
            
            input3D = new Vector3(moveHorizontal, 0, moveVertical);
        }
        private void FixedUpdate()
        {
            if (isGrounded)
            {
                //pressedJump = false;
                currentMovementSpeed = maxMovementSpeed;
            }

            PlayerMove();
            CameraMove();

            playerRigidBody.AddForce(new Vector3 (0, -gravity * playerRigidBody.mass, 0));
            // We apply gravity manually for more tuning control
            //playerRigidBody.AddForce(Vector3(0, -gravity * playerRigidBody.mass, 0));
        }

        private void PlayerAttack()
        {
            
            if (pressedAttack && currentAttackCount < 3)
            {
                currentAttackCount++;
            }

            /***
             * KNOWN ISSUE
             * the player's attack count wont reset if the player;
             * A: times an attack *after* the hit function has been called.
             * B: presses the button when falling.
             *
             * I have added catches for these events, though they're not exactly
             * good, but they work.
             */
            
            if (currentAttackCount == currentAttackCount)
            {
                attackTimer += Time.deltaTime;
            }

            if (equipHammer)
            {
                attackTimerGoal = 2F;
            }
            else
            {
                attackTimerGoal = 1.6F;
            }
            
            if (attackTimer >= attackTimerGoal)
            {
                currentAttackCount = 0;
            }
            
            if (currentAttackCount <= queuedHits || pressedJump)
            {
                currentAttackCount = 0;
                queuedHits = 0;
                attackTimer = 0;
            }
        }

        private void Hit()
        {
            queuedHits++;
            
            var hitEnemies = Physics.OverlapSphere(transform.position + 
                                                   transform.forward + new Vector3(0,1.5F,0), 1, enemyLayers);
            //Debug.Log(hitEnemies);
            foreach (Collider objectHit in hitEnemies)
            {
                if (objectHit.CompareTag("Enemy"))
                {
                    objectHit.GetComponent<EnemyController>().enemyHealth -= attackDamage;
                    objectHit.GetComponent<EnemyController>().takeDamage = true;

                }
                else if (objectHit.CompareTag("Button"))
                {
                    objectHit.GetComponent<SwitchScript>().pressed = 
                        !objectHit.GetComponent<SwitchScript>().pressed;
                    //Debug.Log("it works! Has hit: " + objectHit.name);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position + 
                                  transform.forward + new Vector3(0,1.5F,0), 1);
        }

        private void PlayerDraw()
        {
            if (hasHammer && pressedDraw)
            {
                equipHammer = !equipHammer;
            }
        }
        private void PlayerMove()
        {
            // Calculate how fast we should be moving
            direction *= currentMovementSpeed;
            // Apply a force that attempts to reach our target velocity
            var velocity = playerRigidBody.velocity;
            var velocityChange = (direction - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            playerRigidBody.AddForce(velocityChange, ForceMode.VelocityChange);
            
        }
        private void PlayerJump()
        { 
            canJump = currentJumpCount < maxJumpCount;
            
            if (isGrounded)
            {
                direction.y = -2f;
               
                if (playerRigidBody.velocity.y < -2f)
                {
                    //canJump = true;
                    currentJumpCount = 0;
                    isJumping = false;
                }
            }

            // if the player falls off something, that will count as one of their jumps
            if (!isGrounded && !isJumping && maxJumpCount > 1)
            {
                currentJumpCount = maxJumpCount - 1;
            }
            else if (!isGrounded && !isJumping && maxJumpCount == 1)
            {
                currentJumpCount = maxJumpCount;
            }

            maxJumpCountReached = currentJumpCount == maxJumpCount;

            if (canJump && pressedJump)
            {
                //Debug.Log(currentJumpCount);
                isJumping = true;
                currentJumpCount++;
                //canJump = false;
                playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, CalculateJumpVerticalSpeed(),
                    playerRigidBody.velocity.z);
                //Debug.Log(currentJumpCount);
                //playerAnimator.SetTrigger(PressedJumpTrg);
            }
            
        }
        private float CalculateJumpVerticalSpeed ()
        {
            // From the jump height and gravity we deduce the upwards speed 
            // for the character to reach at the apex.
            return Mathf.Sqrt(2 * jumpHeight * gravity);
        }
        
        private void CameraMove()
        {
            Vector3 camForward = cam.forward;
            Vector3 camRight = cam.right;

            camForward.y = 0f;
            camRight.y = 0f;

            camForward = camForward.normalized;
            camRight = camRight.normalized;

            direction = (camForward * input3D.z + camRight * input3D.x);
            Vector2 input2D = new Vector2(moveHorizontal, moveVertical);
            if (input2D != Vector2.Zero)
            {
                float targetRotation = Mathf.Atan2(input2D.X, input2D.Y) * Mathf.Rad2Deg + cam.eulerAngles.y;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation,
                    ref smoothTurnVelocity, smoothTurnTime);
            }
        }
        
        private void Animation()
        {
            var animateHorizontal = moveHorizontal;
            var animateVertical   = moveVertical;

            if (animateHorizontal < 0)
            {
                animateHorizontal *= -1;
            }
            if (animateVertical < 0)
            {
                animateVertical *= -1;
            }
            var currentSpeed = animateHorizontal + animateVertical;

            if (isGrounded && !pressedJump)
            {
                playerAnimator.SetTrigger(PressedJumpTrg);
            }

            if (!isGrounded)
            {
                playerAnimator.ResetTrigger(PressedJumpTrg);
            }

            if (pressedDraw)
            {
                Debug.Log("Pressed Draw");
                playerAnimator.SetTrigger(PressedUnsheathTrg);
                StartCoroutine(Unsheath());
            }
            
            playerAnimator.SetBool(MaxJumpCountReached, maxJumpCountReached);
            playerAnimator.SetInteger(JumpCount, currentJumpCount);
            playerAnimator.SetFloat(MovementSpeed, currentSpeed);
            playerAnimator.SetBool (PressingJump, pressedJump);
            playerAnimator.SetBool (Grounded,isGrounded);
            playerAnimator.SetFloat(VelocityY, playerRigidBody.velocity.y);
            playerAnimator.SetInteger(AttackCount, currentAttackCount);
        }
        private void Set(int value)
        {
            //Debug.Log("current overrider: " + value);
            overrider.SetAniamtions(overrideControllers[value]);
            anim = GetComponent<Animator>();
        }
        IEnumerator Unsheath()
        {
            yield return new WaitForSeconds(.3f);
            GameObject.FindWithTag("Equipped").GetComponent<Renderer>().enabled = equipHammer;
            playerAnimator.ResetTrigger(PressedUnsheathTrg);
            Set(equipHammer ? 1 : 0);
            //Debug.Log("Finished Draw");
        }
        
        private void DebugSpeed()
        {
            Debug_current_speed = (playerRigidBody.velocity).magnitude;
        }
    }
}
