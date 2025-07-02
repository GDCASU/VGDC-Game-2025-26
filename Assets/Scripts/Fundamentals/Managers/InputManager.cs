using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/* -----------------------------------------------------------
 * Author:
 * 
 * 
 * Modified By:
 * 
 */// --------------------------------------------------------

/* -----------------------------------------------------------
 * Purpose:
 * 
 */// --------------------------------------------------------


/// <summary>
/// 
/// </summary>
public class InputManager : MonoBehaviour
{
    // Singleton Instance
    public static InputManager Instance;
    
    // Use this bool to gate all your Debug.Log Statements please
    [Header("Debugging")]
    [SerializeField] private bool _doDebugLog;
    
    // Input-Updated Values
    [HideInInspector] public Vector2 movementInput; // Vector2 for movement
    
    // Local variables
    private PlayerControls _playerControls;

    #region Player Events

    /// <summary> Player's Move Event </summary>
    public static event System.Action OnMove;
    public static event System.Action OnJump;

    #endregion

    #region Unity Events

    private void Awake()
    {
        // Handle Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // Control handling
        if (_playerControls == null)
        {
            _playerControls = new PlayerControls();
            BindPlayerEvents();
        }

        // Enable controls once all setup is done
        _playerControls.Enable();
    }
    
    private void OnDestroy()
    {
        if (Instance == this)
        {
            _playerControls?.Disable();
            Instance = null;
        }
        StopAllCoroutines();
    }

    #endregion
    
    #region Binding
    
    /// <summary>
    /// Binds all of the Players' controls to their respective events.
    /// </summary>
    private void BindPlayerEvents()
    {
        // Subscribe to input events
        
        // Movement
        _playerControls.Movement.Move.performed += i => HandleMovementInput(i);
        _playerControls.Movement.Jump.performed += i => HandleJump(i);
        
        // Gravity Gun
        _playerControls.GravityGun.LeftClickPush.performed += i => HandleLeftClickPush(i);
        _playerControls.GravityGun.RightClickPull.performed += i => HandleRightClickPull(i);
        _playerControls.GravityGun.MiddleWheelPress.performed += i => HandleMiddleWheelPress(i);
        _playerControls.GravityGun.ScrollWheelDown.performed += i => HandleScrollWheelDown(i);
        _playerControls.GravityGun.ScrollWheelUp.performed += i => HandleScrollWheelUp(i);
        
        // Level
        _playerControls.Level.Retry.performed += i => HandleLevelRetry(i);

        // UI
        _playerControls.UI.Pause.performed += i => HandlePause(i);
    }
    
    #endregion
    
    #region Movement Event Handlers
    
    private void HandleMovementInput(InputAction.CallbackContext context)
    {
        // Read value from input and set the movementInput Vector to it
        movementInput = context.ReadValue<Vector2>();
        if (_doDebugLog) Debug.Log("The Movement Input read was = " + movementInput);
    }

    private void HandleJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnJump?.Invoke();
        }
    }
    
    #endregion

    #region Gravity Gun Event Handlers
    
    private void HandleLeftClickPush(InputAction.CallbackContext context)
    {
        
    }
    
    private void HandleRightClickPull(InputAction.CallbackContext context)
    {
        
    }
    
    private void HandleMiddleWheelPress(InputAction.CallbackContext context)
    {
        
    }
    
    private void HandleScrollWheelUp(InputAction.CallbackContext context)
    {
        
    }
    
    private void HandleScrollWheelDown(InputAction.CallbackContext context)
    {
        
    }
    
    #endregion
    
    #region Level Event Handlers

    private void HandleLevelRetry(InputAction.CallbackContext context)
    {
        
    }
    
    #endregion
    
    #region UI Event Handlers

    private void HandlePause(InputAction.CallbackContext context)
    {
        
    }
    
    #endregion
}
