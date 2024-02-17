using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]

[RequireComponent(typeof(PlayerInput))]


public class PlayerAbilitiesController : MonoBehaviour
{
    public float maxDistance = 5.0f;
    public GameObject CameraController;
    public GameObject tempProjectile;
    public GameObject Missile;

    // Indicators
    public GameObject CircleIndicator;


    // game objects
    private CharacterController _controller;
    private StarterAssets.Inputs _input;
    private GameObject _mainCamera;
    private PlayerInput _playerInput;
    
    private Cinemachine.CinemachineBrain _cinemachineBrain;


    // deltas
    private float _cameraDelta;

    // timeout stuff
    private float _basicActionTimeout = 0.10f;




    // State variables
    private PlayerConstants.ABILITY_STATE _abilityState;
    private bool _isFocused = false;
    public GameObject currentIndicator;

    private void Awake()
    {
        // get a reference to our main camera
        if (_mainCamera == null)
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            _cinemachineBrain = _mainCamera.GetComponent<Cinemachine.CinemachineBrain>();
        }
        if (CameraController == null)
        {
            CameraController = GameObject.FindGameObjectWithTag("CameraController");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<StarterAssets.Inputs>();
        _playerInput = GetComponent<PlayerInput>();
        _abilityState = PlayerConstants.ABILITY_STATE.NONE;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerActions();
        RenderAbilityPreviews();
    }



    // Public method to be called by input system
    public void OnFire()
    {
        _onFire();
    }


    private void _onFire()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 direction = new Vector3();
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 playerPos = transform.position;
            Vector3 hitPos = hit.point;
            playerPos.y = 0;

            direction = (hitPos - playerPos).normalized;

            Instantiate(tempProjectile, hit.point, Quaternion.identity);
        }
        print("direction: " + direction);

        switch (_abilityState)
        {
            case PlayerConstants.ABILITY_STATE.ABILITY_1:
                

                break;
            case PlayerConstants.ABILITY_STATE.NONE:
                if (direction != null)
                {
                    print("trying to fire");
                    Vector3 spawningPos = transform.position;
                    GameObject missile = Instantiate(Missile, transform.position, Quaternion.identity);
                    missile.GetComponent<BasicMissile>().Fire(direction);
                }
                break;
        }
    }

    private void PlayerActions()
    {
        _cameraDelta -= Time.deltaTime;
        if (_input.focusPressed && _cameraDelta <= 0.0)
        {
            CameraController.GetComponent<CameraController>().toggleCamera();
            _cameraDelta = _basicActionTimeout;
            print(_input.focusPressed);
            _input.focusPressed = false;
            _isFocused = !_isFocused;
            _abilityState = PlayerConstants.ABILITY_STATE.ABILITY_1;
        }


        if (!_isFocused)
        {
            _abilityState = PlayerConstants.ABILITY_STATE.NONE;
            if (currentIndicator != null)
            {
                Destroy(currentIndicator);
                currentIndicator = null;
            }
        }
    }

    private void RenderAbilityPreviews()
    {
        switch (_abilityState)
        {
            case PlayerConstants.ABILITY_STATE.ABILITY_1:
                if (_isFocused)
                {
                    // Get the position the mouse is looking at 
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit hit) )
                    {
                        if (currentIndicator == null)
                        {
                            Vector3 hitPos = hit.point;
                            hitPos.y = 0.5f;
                            currentIndicator = Instantiate(CircleIndicator, hitPos, Quaternion.identity);
                        } else
                        {
                            print("trying to update current indicator position");
                            currentIndicator.transform.position = new Vector3(hit.point.x, 0.05f, hit.point.z);
                        }
                        
                    }

                    // TODO: show preview
                }
                break;
        }
    }
 
}


