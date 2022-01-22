using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float minJumpVelocity;
    public float maxJumpVelocity;
    public float jumpAcceleration;
    public float attackDamage;
<<<<<<< Updated upstream
    public float attackSpeed;   // second
    public float health;
    public bool isJumping;
    public bool isMoving;
    public bool isGounding;
    bool stopJumping;
    [SerializeField] float jumpVelocity;


    public Animator animator;
    public AudioSource audioSource;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 5.0f;
        minJumpVelocity = 3.0f;
        maxJumpVelocity = 5.0f;
        jumpAcceleration = 15.0f;
        attackDamage = 3.0f;
        attackSpeed = 15.0f;
=======
    public float attackTime;
    public float attackColdTime;
    public float rollingColdTime;
    public float health;

    public bool isJumping;
    public bool isMoving;
    public bool isGounding;
    public bool isRolling;

    bool stopJumping;
    float rollingSpeed;
    [SerializeField] float rollingTime;
    [SerializeField] float jumpVelocity;


    public AudioSource audioSource;
    Animator animator;
    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 4.0f;
        minJumpVelocity = 6.0f;
        maxJumpVelocity = 7.0f;
        jumpAcceleration = 15.0f;
        attackDamage = 3.0f;
        attackColdTime = 1.0f;
        rollingColdTime = 1.0f;
>>>>>>> Stashed changes


        isGounding = isMoving = isJumping = stopJumping = false;
        animator = GetComponent<Animator>();
<<<<<<< Updated upstream
        rigidbody = GetComponent<Rigidbody>();
=======
        rigidbody = GetComponent<Rigidbody2D>();
>>>>>>> Stashed changes
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        bool moveRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        bool moveLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);

        if (isMoving = (moveRight ^ moveLeft))
        {
            if(moveRight)
            {
                transform.Translate(movementSpeed*Time.deltaTime, 0, 0);
            }
            else if(moveLeft)
            {
                transform.Translate(-movementSpeed*Time.deltaTime, 0, 0);
            }
            GetComponent<SpriteRenderer>().flipX = moveLeft;
        }

        if (Input.GetKey(KeyCode.Space) && isGounding)
        { // Jump
            jumpVelocity = minJumpVelocity;
            isJumping = true;
            isGounding = false;
        }
        if (Input.GetKey(KeyCode.J))
        { // Attack
        }



        if(isJumping)
        {  // Jumping Process
            if(!stopJumping){
                stopJumping = (jumpVelocity >= maxJumpVelocity || !Input.GetKey(KeyCode.Space) || rigidbody.velocity.y <= 0.0f);
                rigidbody.velocity = new Vector3(0, jumpVelocity += jumpAcceleration*Time.deltaTime, 0);
            }
            else if(rigidbody.velocity.y == 0.0f)
                isJumping = stopJumping = false;
=======
        rollingTime += Time.deltaTime;
        attackTime += Time.deltaTime;

        if(isRolling){
            transform.Translate(rollingSpeed*Time.deltaTime, 0, 0);

            if(rollingTime > 0.3f)
                isRolling = false;
        }
        else{
            bool moveRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
            bool moveLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);

            if (isMoving = (moveRight ^ moveLeft)){
                transform.Translate(moveLeft ? -movementSpeed*Time.deltaTime : movementSpeed*Time.deltaTime, 0, 0);
                GetComponent<SpriteRenderer>().flipX = moveLeft;
            }

            if (Input.GetKey(KeyCode.S) && isMoving && !isJumping && rollingTime > rollingColdTime)
                Roll(moveLeft);
            
            else if (Input.GetKey(KeyCode.Space) && isGounding)
                Jump();
            
            else if (Input.GetKey(KeyCode.J) && attackTime > attackColdTime)
                Attack();


            if(isJumping)
            {  // Jumping Process
                if(!stopJumping)
                {
                    rigidbody.velocity = new Vector2(0, jumpVelocity += jumpAcceleration*Time.deltaTime);
                    stopJumping = (jumpVelocity >= maxJumpVelocity || !Input.GetKey(KeyCode.Space));
                }
                else if(isGounding)
                    isJumping = stopJumping = false;
            }
>>>>>>> Stashed changes
        }

        animator.SetBool("isRun", isMoving);
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isFallDown", rigidbody.velocity.y <= 0.0f);
    }

<<<<<<< Updated upstream
    void OnCollisionStay(Collision other){
        if (!isGounding && rigidbody.velocity == new Vector3(0.0f, 0.0f ,0.0f))
=======
    void OnCollisionStay2D(Collision2D other)
    {
        if (!isGounding && rigidbody.velocity == new Vector2(0.0f, 0.0f))
>>>>>>> Stashed changes
        {   // Gounded
            isGounding = true;
        }
    }

<<<<<<< Updated upstream
    void OnCollisionExit(Collision other){
        isGounding = (rigidbody.velocity == new Vector3(0.0f, 0.0f ,0.0f));
    }
}
=======
    void OnCollisionExit2D(Collision2D other)
    {
        isGounding = (rigidbody.velocity == new Vector2(0.0f, 0.0f));
    }



    void Attack(){
        animator.SetTrigger("Attack");
        attackTime = 0.0f;
    }

    void Jump(){
        jumpVelocity = minJumpVelocity;
        isJumping = true;
        isGounding = false;
    }
    
    void Roll(bool moveLeft){
        isRolling = true;
        rollingSpeed = (moveLeft ? -movementSpeed : movementSpeed)*3.0f;
        rollingTime = 0.0f;
        animator.SetTrigger("Roll");
    }
} 
>>>>>>> Stashed changes
