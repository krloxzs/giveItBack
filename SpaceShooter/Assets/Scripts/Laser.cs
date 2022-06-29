using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _laserSpeed = 8.5f;
    private
 
    void Update()
    {
        CalculateMovement();
    }
    void CalculateMovement()
    {
        float scale = _laserSpeed * Time.deltaTime;
        transform.Translate(Vector3.up * scale);
        if (transform.position.y >= 8)
        {
            Destroy(this.gameObject);
        } 
    }
}
