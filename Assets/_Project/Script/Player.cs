using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidBody;
    [SerializeField] float _speed;
    [SerializeField] Transform _camera;
    [SerializeField] private float _powerupDuration;
    private Coroutine _powerupCoroutine;
    public Action OnPowerUpStart;
    public Action OnPowerUpStop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 horizontalDirection = horizontal * _camera.right;
        Vector3 verticalDirection = vertical * _camera.forward;
        verticalDirection.y = 0;
        horizontalDirection.y = 0;
        Vector3 movementDirection = horizontalDirection + verticalDirection;
        _rigidBody.linearVelocity = movementDirection * _speed * Time.fixedDeltaTime;
    }

    public void PickPowerUp()
    {
        if (_powerupCoroutine != null)
        {
            StopCoroutine(_powerupCoroutine);
        }
        _powerupCoroutine = StartCoroutine(StartPowerUp());
    }

    private IEnumerator StartPowerUp()
    {
        if (OnPowerUpStart != null)
        {
            OnPowerUpStart();
            Debug.Log("Power Up");
        }
        yield return new WaitForSeconds(_powerupDuration);
        if (OnPowerUpStop != null)
        {
            OnPowerUpStop();
        }
    }
}
