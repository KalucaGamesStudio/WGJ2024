using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    [Header("InputSystem")]
    public Move input = null;
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb;
    public float moveSpeed = 10f;

    [Header("Sprites")]
    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    private AnimatedSpriteRenderer activeSpriteRenderer;

    private void Awake()
    {
        input = new Move();
        rb = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = spriteRendererDown;
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Walk.performed += OnWalkPerformed;
        input.Player.Walk.canceled += OnWalkCancelled;

    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Walk.performed -= OnWalkPerformed;
        input.Player.Walk.canceled -= OnWalkCancelled;

    }
    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;

    }

    private void OnWalkPerformed(InputAction.CallbackContext value)
    {
        Vector2 inputVector = value.ReadValue<Vector2>();

        if (inputVector.x != 0 && inputVector.y != 0)
        {
            moveVector = Vector2.zero;
        }
        else
        {
            moveVector = inputVector;
        }
        UpdateAnimation();
    }
    private void OnWalkCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (moveVector == Vector2.up)
        {
            SetDirection(Vector2.up, spriteRendererUp);
        }
        else if (moveVector == Vector2.down)
        {
            SetDirection(Vector2.down, spriteRendererDown);
        }
        else if (moveVector == Vector2.left)
        {
            SetDirection(Vector2.left, spriteRendererLeft);
        }
        else if (moveVector == Vector2.right)
        {
            SetDirection(Vector2.right, spriteRendererRight);
        }
        else
        {
            SetDirection(Vector2.zero, activeSpriteRenderer);
        }
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRenderer)
    {
        moveVector = newDirection;

        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;

        activeSpriteRenderer = spriteRenderer;
        activeSpriteRenderer.idle = newDirection == Vector2.zero;
    }


}
