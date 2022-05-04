using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    private Vector2 minBound, maxBound;


    [SerializeField] private float paddingLeft;
    [SerializeField] private float paddingRight;
    [SerializeField] private float paddingTop;
    [SerializeField] private float paddingBottom;
    [SerializeField] private float moveSpeed = 10f;

    private Shooter _shooter;


    private void Awake()
    {
        _shooter = GetComponent<Shooter>();
    }


    // Start is called before the first frame update
    void Start()
    {
        InitBound();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void InitBound()
    {
        Camera mainCamera = Camera.main;

        minBound = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBound.x + paddingLeft, maxBound.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBound.y + paddingBottom , maxBound.y - paddingTop);
        transform.position = newPos;
    }   
    
    void OnMove(InputValue inputValue)
    {
        rawInput = inputValue.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (_shooter!=null)
        {
            _shooter.isFiring = value.isPressed;
        }
    }
}
