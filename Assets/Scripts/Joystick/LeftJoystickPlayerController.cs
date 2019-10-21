using UnityEngine;
public class LeftJoystickPlayerController : MonoBehaviour
{
    public LeftJoystick leftJoystick; // the game object containing the LeftJoystick script
    public Transform rotationTarget; // the game object that will rotate to face the input direction
    public float moveSpeed = 6.0f; // movement speed of the player character
    public int rotationSpeed = 8; // rotation speed of the player character
    public Animator animator; // the animator controller of the player character
    private Vector3 leftJoystickInput; // holds the input of the Left Joystick
    private Rigidbody2D rigidBody; // rigid body component of the player character
    public GameObject lightFlick;
    
    
    

    void Start()
    {
        leftJoystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<LeftJoystick>();
        animator = gameObject.GetComponent<Animator>();
        if (transform.GetComponent<Rigidbody2D>() == null)
        {
            Debug.LogError("A RigidBody component is required on this game object.");
        }
        else
        {
            rigidBody = transform.GetComponent<Rigidbody2D>();
        }

        if (leftJoystick == null)
        {
            Debug.LogError("The left joystick is not attached.");
        }

        if (rotationTarget == null)
        {
            Debug.LogError("The target rotation game object is not attached.");
        }
        
    }

    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -155, 158),
                                            Mathf.Clamp(transform.position.y, -150, 150));
    }

    void FixedUpdate()
    {
        // get input from both joysticks
        leftJoystickInput = leftJoystick.GetInputDirection();

        float xMovementLeftJoystick = leftJoystickInput.x; // The horizontal movement from joystick 01
        float yMovementLeftJoystick = leftJoystickInput.y; // The vertical movement from joystick 01	

        // if there is no input on the left joystick
        if (leftJoystickInput == Vector3.zero)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isIdle", true);
        }
  
        // if there is only input from the left joystick
        if (leftJoystickInput != Vector3.zero)
        {
            // calculate the player's direction based on angle
            float tempAngle = Mathf.Atan2(yMovementLeftJoystick, xMovementLeftJoystick);
            xMovementLeftJoystick *= Mathf.Abs(Mathf.Cos(tempAngle));
            yMovementLeftJoystick *= Mathf.Abs(Mathf.Sin(tempAngle));

            leftJoystickInput = new Vector3(xMovementLeftJoystick, yMovementLeftJoystick,0);
            leftJoystickInput = transform.TransformDirection(leftJoystickInput);
            leftJoystickInput *= moveSpeed;

            // rotate the player to face the direction of input
            Vector3 temp = transform.position;
            temp.x += xMovementLeftJoystick;
            temp.y += yMovementLeftJoystick;
            Vector3 lookDirection = temp - transform.position;
            if (lookDirection != Vector3.zero)
            {
                //rotationTarget.localRotation = Quaternion.Slerp(rotationTarget.localRotation, Quaternion.LookRotation(lookDirection), rotationSpeed * Time.deltaTime);
                if (lookDirection.x < 0)
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                    lightFlick.transform.localPosition = new Vector3(0, 0, 1.35f);
                    
                } else
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    lightFlick.transform.localPosition = new Vector3(0, 0, -1.35f);
                }
            }
            if (animator != null)
            {
                animator.SetBool("isRunning", true);
                animator.SetBool("isIdle", false);
            }

            // move the player

            rigidBody.transform.Translate(leftJoystickInput * Time.fixedDeltaTime);
            
        }
    }
    
}