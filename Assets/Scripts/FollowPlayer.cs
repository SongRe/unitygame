using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;


    private float smoothSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0f, 2.5f, -5.5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void LateUpdate()
    {
        Vector3 desiredPos = player.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPos;
        transform.LookAt(player);
        //transform.position = player.transform.position + new Vector3(0, 5, -7);
    }
}
