using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private float _offsetPosition = 0.8f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.2f;

    private float _nextFire = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        // take the current position = new position to (0,0,0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
       CalculateMovement();
       FireWeapon();
    }

    void FireWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (Time.time > _nextFire))
        {
            _nextFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, transform.position + new Vector3(0, _offsetPosition,0), Quaternion.identity);
        }
    }
    
    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float scale = _speed * Time.deltaTime;
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * scale);
        transform.position = new Vector3(transform.position.x, Math.Clamp(transform.position.y, -3.8f, 0), 0);
        if (transform.position.x >= 11.3)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        } 
        else if (transform.position.x <= -11.3)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }
}
