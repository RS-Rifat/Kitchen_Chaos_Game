using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInput : MonoBehaviour
{

    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlernateAction;

    private PlayerInputAction playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputAction();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
    }

    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlernateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        // input as a vector 2 because we only need to move the player to x and y axis
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        // normalized the input values
        inputVector = inputVector.normalized;

        return inputVector;
    }
}
