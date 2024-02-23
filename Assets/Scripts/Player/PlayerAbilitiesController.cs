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


    // Abilities
    public GameObject AbilityOne;
    public GameObject BasicAbility;



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
    private GameObject _currentIndicator;
    private CombatEntity _player;


    // Ability scripts

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

        if (AbilityOne == null)
        {
            AbilityOne = Instantiate(AbilityOne);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<StarterAssets.Inputs>();
        _playerInput = GetComponent<PlayerInput>();
        _abilityState = PlayerConstants.ABILITY_STATE.NONE;

        if (_player == null)
        {
            _player = GetComponent<PlayerStatusController>().getPlayer();
        }
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
        _onFireInternal();
    }


    private void _onFireInternal()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 direction = new Vector3();
        Vector3 hitPos = new Vector3();
        bool hasHit = false;
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 playerPos = transform.position;
            hitPos = hit.point;
            playerPos.y = 0;
            direction = (hitPos - playerPos).normalized;
            hasHit = true;
            Instantiate(tempProjectile, hit.point, Quaternion.identity); // helper indicator
        }

        switch (_abilityState)
        {
            case PlayerConstants.ABILITY_STATE.ABILITY_1:
                if (hasHit)
                {
                    AbilityScript abilityScript = AbilityOne.GetComponent<AbilityScript>();
                    abilityScript.Initialize();
                    abilityScript.setAbilityStat(AbilityStat.X_SCALING, 2.0f);
                    abilityScript.Fire(Vector3.up, hitPos, ref _player);
                    toggleCamera();
                }

                break;
            case PlayerConstants.ABILITY_STATE.NONE:
                if (hasHit)
                {
                    AbilityScript abilityScript = BasicAbility.GetComponent<AbilityScript>();
                    abilityScript.Initialize();
                    abilityScript.Fire(direction, transform.position, ref _player);
                }
                break;
        }
    }

    private void PlayerActions()
    {
        _cameraDelta -= Time.deltaTime;
        if (_input.focusPressed && _cameraDelta <= 0.0)
        {
            toggleCamera();
            _abilityState = PlayerConstants.ABILITY_STATE.ABILITY_1;
        }


        if (!_isFocused)
        {
            _abilityState = PlayerConstants.ABILITY_STATE.NONE;
            if (_currentIndicator != null)
            {
                Destroy(_currentIndicator);
                _currentIndicator = null;
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
                        if (_currentIndicator == null)
                        {
                            Vector3 hitPos = hit.point;
                            hitPos.y = 0.5f;
                            _currentIndicator = Instantiate(AbilityOne.GetComponent<PillarAbilityScript>().GetIndicator(), hitPos, Quaternion.identity);
                        } else
                        {
                            _currentIndicator.transform.position = new Vector3(hit.point.x, 0.05f, hit.point.z);
                        }
                    }
                }
                break;
        }
    }


    private void toggleCamera()
    {
        CameraController.GetComponent<CameraController>().toggleCamera();
        _cameraDelta = _basicActionTimeout;
        _input.focusPressed = false;
        _isFocused = !_isFocused;
    }
 
}


