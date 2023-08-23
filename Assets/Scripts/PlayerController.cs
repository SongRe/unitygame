using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    // constants
    public float speed = 0.5f;
    public float horizontalInput;
    public float forwardInput;
    private float jumpDelta = 0.15f;
    private float nextJump = 0.5f;
    private float jumpTime = 0.0f;
    public float maxSpeed = 20.0f;

    // movement
    public float jumpForce;
    public Vector2 turn;
    public float sensitivity = 1.0f;
    public int totalJumps;
    public int numJumps;
 

    private float gravityModifier = 1.5f;


    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        numJumps = totalJumps;
        rb.maxDepenetrationVelocity = 20;
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {

        TurnHorizontal();
        Jump();
        Move();
    }

    private void FixedUpdate()
    {
    }

    void OnCollisionEnter(Collision collision) {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Ground")) {
            numJumps = totalJumps;
        }
    }

    void ClampHorizontal() {
        float newX = Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed);
        float newZ = Mathf.Clamp(rb.velocity.z, -maxSpeed, maxSpeed);
        rb.velocity = new Vector3(newX, rb.velocity.y, newZ);
    }
    void Move() {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        rb.AddForce(transform.forward * forwardInput * speed, ForceMode.Impulse);
        rb.AddForce(transform.right * horizontalInput * speed, ForceMode.Impulse);
        ClampHorizontal();
    }

    void Jump() {
        jumpTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && numJumps > 0 && jumpTime > nextJump)
        {
            nextJump = jumpTime + jumpDelta;

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            numJumps--;
            nextJump = nextJump - jumpTime;
            jumpTime = 0.0f;
        }
    }

    void TurnHorizontal() {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);
    }
}
