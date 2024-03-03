using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Cinemachine.CinemachineBrain brain;
    public Cinemachine.CinemachineVirtualCamera mainCamera;
    public Cinemachine.CinemachineVirtualCamera secondaryCamera;

    private GameObject _crossHair;

    // Start is called before the first frame update
    void Start()
    {
        if (brain == null)
        {
            brain = GetComponent<Cinemachine.CinemachineBrain>();
        }
        _crossHair = GameObject.FindGameObjectWithTag("Crosshair");
        mainCamera.Priority = 1;
        secondaryCamera.Priority = -1;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void toggleCamera()
    {
        mainCamera.Priority *= -1;
        secondaryCamera.Priority *= -1;
        _crossHair.SetActive(!_crossHair.activeSelf);
    }
}
