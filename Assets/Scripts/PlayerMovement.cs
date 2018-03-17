using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rigid;

    //Horizontal
    public float maxSpeed = 20f;
    public float acceleration = 35f;
    public AnimationCurve animCurve;
    [HideInInspector]
    public int directionFacing = 1;//1 is right, -1 is left

    //Vertical
    public float jumpPower = 3f;
    public float jumpTime = .5f;
    public float jumpHeight = 2.5f;
    public float maxFallSpeed = 5f;
    public AnimationCurve gravCurve;
    public float variableJumpCutoffSpeed = 1f;

    //Buffers
    public float groundedSlope = .75f;
    public float maxGroundedBuffer = .2f;
    float groundedBuffer = 0f;
    public float maxJumpBuffer = .2f;
    float jumpBuffer = 0;


    //Double Jump Variables
    public bool unLockedJump = false;//bool if double jump abality unlocked
    private bool hasDoubleJump = true;//used to control if dj is used
    public float dJumpModifier = 0.9f;//float that modifies the height of dj compared to jump

    //teleport
    public float teleportDistance = 5f;
    public float teleportDelay = 1.5f;
    float nextTeleportAvailable = 0;

    //shooting
    Shoot playerShoot;
    public float shootDelay = .5f;
    float nextshotAvailable = 0;


    // Use this for initialization
    void Awake()
    {
        rigid = this.GetComponent<Rigidbody>();
        playerShoot = this.GetComponent<Shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpBuffer = maxJumpBuffer;
        }

        if (nextshotAvailable <= 0 && Input.GetButtonDown("Fire1"))//M1
        {
            nextshotAvailable = shootDelay;
            playerShoot.DoShoot();
        }

        if (nextTeleportAvailable <= 0 && Input.GetButtonDown("Fire3"))//left shift
        {
            nextTeleportAvailable = teleportDelay;
            Vector3 teleport = this.transform.position;
            teleport.x += (directionFacing * teleportDistance);
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, directionFacing * Vector3.right, out hit, teleportDistance))
            {
                float hitAt = this.transform.position.x + (directionFacing * hit.distance);
                if (directionFacing == -1)
                {
                    if (teleport.x <= hitAt && teleport.x >= hitAt + (directionFacing * hit.collider.bounds.size.x))//land in a wall i think
                    {
                        nextTeleportAvailable = 0;
                    }
                    else
                    {
                        this.transform.position = teleport;
                    }
                }
                else
                {
                    if (teleport.x >= hitAt && teleport.x <= hitAt + (directionFacing * hit.collider.bounds.size.x))//land in a wall i think
                    {
                        nextTeleportAvailable = 0;
                    }
                    else
                    {
                        this.transform.position = teleport;
                    }
                }
                
                
            }
            else
            {
                this.transform.position = teleport;
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 velocity = rigid.velocity;

        //Horizontal Movement
        float xInput = Input.GetAxis("Horizontal");
        if (xInput > 0)
        {
            directionFacing = 1;
        }
        else if (xInput < 0)
        {
            directionFacing = -1;
        }
        /*
        float targetSpeed = xInput * maxSpeed;
        float xDiff = targetSpeed - velocity.x;
        float thisAcceleration = acceleration * animCurve.Evaluate(Mathf.Abs(xDiff / maxSpeed));
        float xStep = Mathf.Sign(xDiff) *
            Mathf.Min(Mathf.Abs(xDiff), thisAcceleration * Time.deltaTime);
        */
        velocity.x = xInput * maxSpeed;

        //Gravity	
        //float jumpPower = 2 * jumpHeight / jumpTime;
        //float gravity = -5 * jumpHeight / (jumpTime * jumpTime);
        float gravity = -10 * gravCurve.Evaluate(velocity.y / jumpPower);
        if (!Input.GetButton("Jump") && velocity.y > variableJumpCutoffSpeed)
        {
            gravity *= 5;
        }
        velocity.y += gravity * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, -maxFallSpeed);

        // Jump
        if (jumpBuffer > 0 && groundedBuffer > 0)
        {
            velocity.y = jumpPower;
            jumpBuffer = 0;
            groundedBuffer = 0;
        }

        //double jump
        else if (jumpBuffer > 0 && hasDoubleJump && unLockedJump)
        {
            velocity.y = dJumpModifier * jumpPower;
            jumpBuffer = 0;
            hasDoubleJump = false;
        }

        rigid.velocity = velocity;

        nextshotAvailable -= Time.deltaTime;
        nextTeleportAvailable -= Time.deltaTime;
        jumpBuffer -= Time.deltaTime;
        groundedBuffer -= Time.deltaTime;       
    }

    void OnCollisionStay(Collision collision)
    {
        if (Vector3.Dot(collision.contacts[0].normal, Vector3.up) > groundedSlope && rigid.velocity.y <= 0)
        {
            groundedBuffer = maxGroundedBuffer;
            hasDoubleJump = true;
        }
    }
}
