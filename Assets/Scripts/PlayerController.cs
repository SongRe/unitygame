using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    public float speed = 20;
    public float horizontalInput;
    public float forwardInput;
    public float jumpForce;

    public int totalJumps;
    public int numJumps;
    private float jumpDelta = 0.15f;
    private float nextJump = 0.5f;
    private float jumpTime = 0.0f;

    private float gravityModifier = 1.5f;


    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        numJumps = totalJumps;
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    void OnCollisionEnter(Collision collision) {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Ground")) {
            numJumps = totalJumps;
        }
    }

    void Move() {
        jumpTime += Time.deltaTime;

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // transform.position = transform.position + new Vector3(0, 0, 1);

        if (Input.GetKeyDown(KeyCode.Space) && numJumps > 0 && jumpTime > nextJump)
        {
            nextJump = jumpTime + jumpDelta;

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            numJumps--;
            nextJump = nextJump - jumpTime;
            jumpTime = 0.0f;
        }
    }
}
