using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Animator animator;
    int runState;
    int idleState;

    private Quaternion steer = Quaternion.identity;
    private Vector3 rotationVector = new Vector3();
    private float rotationAngle;
    public float maxRotationAngle;

    private float horizontalInput;
    public float horizontalSpeed = 20;
    public float forwardSpeed = 20;
    bool isRunning;

    public Transform bossObject;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        runState = Animator.StringToHash("run");
        idleState = Animator.StringToHash("idle");
        isRunning = animator.GetBool(runState);
    }

    public void RotatePlayer()
    {
        rotationAngle = Mathf.Lerp(rotationAngle, horizontalInput * maxRotationAngle, 100 * Time.deltaTime);
        rotationVector.y = rotationAngle;
        steer.eulerAngles = rotationVector;
        transform.rotation = steer;
    }

    public void MovePlayer()
    {
        // Get the users horizontal
        horizontalInput = Input.GetAxis("Horizontal");
        Vector3 directionyVector = new Vector3(horizontalInput * horizontalSpeed * Time.deltaTime, 0, forwardSpeed * Time.deltaTime);
        transform.Translate(directionyVector);
    }

    public void MoveToBoss()
    {
        transform.position = Vector3.MoveTowards(transform.position, bossObject.position, 1 * Time.deltaTime);
    }

    public void LimitHorizontalPosition()
    {
        if(transform.position.x < -25f)
            transform.position = new Vector3(-25f, transform.position.y, transform.position.z);
        if (transform.position.x > 25f)
            transform.position = new Vector3(25f, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        isRunning = animator.GetBool(runState);

        if (Input.GetKey(KeyCode.W))
        {
            if (!isRunning)
            {
                animator.SetBool(runState, true);
            }
            MovePlayer();
            RotatePlayer();
            LimitHorizontalPosition();
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool(runState, false);
        }
    }
}
