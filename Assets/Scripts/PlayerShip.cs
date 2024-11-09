using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShip : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D kebab;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private Transform spit_point;

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private GameObject kebab_explosion;

    [SerializeField]
    private float timed_shot = 0.5f;
    
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float spit_speed = 5f;

    private float speedAtual = 0f;

    private PlayerControls playerControls;

    public float padding = 0.6f;

    private Vector2 screenBounds;

    void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.PlayerShip.Enable();
        playerControls.PlayerShip.Movement.performed += InputMovePerformedHandler;
        playerControls.PlayerShip.Movement.canceled += InputMoveCanceledHandler;
        playerControls.PlayerShip.Shoot.performed += InputShootPerformedHandler;
        playerControls.PlayerShip.Shoot.canceled += InputShootCanceledHandler;
        playerControls.PlayerShip.Shield.performed += InputShieldPerformedHandler;

        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

    void Update()
    {
        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, screenBounds.y * -1 + padding, screenBounds.y - padding);
        transform.position = position;
    }

    private void InputShieldPerformedHandler(InputAction.CallbackContext context)
    {
        Shoot();
    }

    private void InputShootCanceledHandler(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    private void InputShootPerformedHandler(InputAction.CallbackContext context)
    {
        Shoot();
    }

    private void InputMoveCanceledHandler(InputAction.CallbackContext context)
    {
        kebab.velocity = Vector2.zero;
    }

    private void InputMovePerformedHandler(InputAction.CallbackContext context)
    {
        float verticalInput = context.ReadValue<float>();
        kebab.velocity = verticalInput * speed * Vector2.up;
    }

    // Update is called once per frame
    private void Shoot()
    {
        GameObject laser = Instantiate(projectile, spit_point.position, transform.rotation);
        laser.GetComponent<Rigidbody2D>().velocity = Vector2.right * spit_speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Instantiate(kebab_explosion, transform.position, transform.rotation);
    }
}
