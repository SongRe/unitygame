using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Cinemachine.CinemachineBrain brain;
    public Cinemachine.CinemachineVirtualCamera mainCamera;
    public Cinemachine.CinemachineVirtualCamera secondaryCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.Priority = 1;
        secondaryCamera.Priority = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)) // Right click
        {
            toggleCamera();
        }
    }

    void toggleCamera()
    {
        mainCamera.Priority *= -1;
        secondaryCamera.Priority *= -1;
    }
}
