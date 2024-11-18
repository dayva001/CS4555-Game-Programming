using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Controller: MonoBehaviour
{
    public float movementForce = 10f;
    public float counterMovementForce = 0.1f;   
    public Transform groundCheck;
    private bool onGround;
    public LayerMask groundMask;
    //force that pulls the player down faster when they're descending from a jump
    public float downForce = 10f;
    public bool canAirstrafe = true;
    private bool isRolling = false;
    private bool upForce = false;
    public float jumpforce = 20f;
    public float rollForce = 10f;
    private Vector3 movementDirection;
    private Vector3 counterMovement;
    private Vector3 lookDirection;
    //determines how fast a player jumps up
    public float extraGravity = 10f;
    public Rigidbody rigidBody;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    private Animator animator;
    private float dragSave;
    private float jumpTime=Mathf.Infinity;
    private int rollCount =0;

    public GameObject stepRayUpper;
    public GameObject stepRayLower;
    public float stepHeight = 0.3f;
    public float stepSmooth = 0.2f;

    // In Update() the script checks if the player is down from the PlayerHealth script.
    public bool isDown;
    // Tells if player has downed movement. Used in the Move() function.
    public bool hasDownedMovement = false;
    // Fraction of movement speed while downed.
    public float downedMovementFraction = 0.3f;


    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        dragSave=rigidBody.drag;
        Collider collider = GetComponent<Collider>();
        //setting the friction of the player to 0 so they dont stick to walls when jumping on them
        PhysicMaterial material = collider.material;
        material.dynamicFriction = 0;
        stepRayUpper.transform.position = new Vector3(stepRayUpper.transform.position.x, stepHeight, stepRayUpper.transform.position.z);
    }
    // Update is called once per frame
    private void Update()
    {
        // Checks if player is down from PlayerHealth script.
        isDown = gameObject.GetComponent<PlayerHealth>().CheckIfDown();
        //checks if the player is on the ground
        onGround = Physics.CheckSphere(groundCheck.position, 0.2f, groundMask);
        //calculates the counter movement force
        counterMovement = new Vector3(-rigidBody.velocity.x * counterMovementForce, 0, -rigidBody.velocity.z * counterMovementForce);
        //jumping
        StepClimb();
        //adds extra gravity to player when jumping
        if(jumpTime + 0.2f < Time.time)
        {
            if(onGround)
            {
                animator.SetTrigger("Landed");
                jumpTime = Mathf.Infinity;
            }

        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(onGround && !isDown)
        {
            upForce = true;
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        //sets movement so that it can be updated in fixed update
        float xMovement = context.ReadValue<Vector2>().x;
        float zMovement = context.ReadValue<Vector2>().y;
        movementDirection = new Vector3(xMovement, 0, zMovement);
        //setting the look direction
        lookDirection = new Vector3(xMovement, 0, zMovement).normalized;
    }
    
    private void FixedUpdate()
    {
        if(!canAirstrafe && !onGround)
        {
            return;
        }
        //moving
        Move();
        DownardForceCheck();
        //setting rotaiton
        SetRotation();
        //setting animations
        SetAnimations();
        if(upForce)
        {
            HandleJump();
            upForce = false;
        }
    }

    private void HandleJump()
    {
        rigidBody.AddForce(transform.up * jumpforce, ForceMode.Impulse);
        animator.SetTrigger("Jumping");
        if(!onGround)
        {
            rigidBody.AddForce(transform.up * -extraGravity);
            rigidBody.drag = 0;
        }
        rigidBody.drag = dragSave;
        jumpTime = Time.time;
    }

    private void SetAnimations()
    {
        if(movementDirection == Vector3.zero || rigidBody.velocity.magnitude < 0.1f)
        {
            animator.SetFloat("Speed", 0);
        }
        else
        {
            animator.SetFloat("Speed", 1);
        }
    }

    private void SetRotation()
    {
        if(lookDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(lookDirection.x, lookDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }

    private void Move()
    {
        // The logic of these two if blocks is analogous to RDT 3.0 protocol. Handles the cycle of players going down and being revived.
        if (isDown && !hasDownedMovement)
        {
            // When player goes down, apply downed movement force.
            movementForce = movementForce * downedMovementFraction;
            hasDownedMovement = true;
        }
        if (!isDown && hasDownedMovement)
        {
            // When player is revived, they are no longer down but movementForce and hasDownedMovement won't be corrected until this if block.
            movementForce = movementForce * (1 / downedMovementFraction);
            hasDownedMovement = false;
        }
        rigidBody.AddForce(movementDirection.normalized * movementForce + counterMovement);
    }

    private void DownardForceCheck()
    {
        if (rigidBody.velocity.y < 0)
        {
            rigidBody.AddForce(Vector3.down * downForce);
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if( onGround && !isRolling && rollCount < 2 && !isDown)
        {
            rollCount++;
            if(rigidBody.velocity.magnitude > 0.1f)
            {
                print("rolling, rollcount: " + rollCount);
                rigidBody.AddForce(transform.forward * rollForce, ForceMode.Impulse);
                StartCoroutine(RollCooldown(0.2f));
                StartCoroutine(DecreaseRollCount(1.0f));
            }
            else
            {
                print("rolling, rollcount: " + rollCount);
                rigidBody.AddForce(-transform.forward * rollForce, ForceMode.Impulse);
                StartCoroutine(RollCooldown(0.2f));
                StartCoroutine(DecreaseRollCount(1.0f));
            }
        }
        else if(rollCount >=2 && !isRolling)
        {
            StartCoroutine(RollCooldown(1.5f));
            rollCount=0;
        }
    }
    private System.Collections.IEnumerator RollCooldown(float time)
    {
        isRolling = true;
        yield return new WaitForSeconds(time);
        isRolling = false;        
    }
    private System.Collections.IEnumerator DecreaseRollCount(float time)
    {
        yield return new WaitForSeconds(time);
        if(rollCount > 0)
        {
            rollCount--;   
        } 
    }

    private void StepClimb()
    {
        RaycastHit hitLower;
        if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(Vector3.forward), out hitLower, 0.25f))
        {
            RaycastHit hitUpper;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(Vector3.forward), out hitUpper, 0.4f))
            {
                Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y + stepHeight, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPosition, stepSmooth);
            }
        }
    }
}