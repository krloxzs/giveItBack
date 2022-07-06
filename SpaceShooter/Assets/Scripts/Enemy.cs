using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PerformMovement();
    }

    private void PerformMovement()
    {
        float scale = _speed * Time.deltaTime;
        transform.Translate(Vector3.down * scale);
        if (transform.position.y <= -5.4)
        {
            transform.position = new Vector3(Random.Range(-9.0f, 9.0f), 7.4f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "Player")
        {
            Destroy(this.transform.gameObject);
            Player player =  other.transform.GetComponent<Player>();
            if (player != null) 
            {
                player.Damage();
            }
        }
        if (other.tag == "Bullet")
        {
            Destroy(other.transform.gameObject);
            Destroy(this.transform.gameObject);
        }
    }
}
