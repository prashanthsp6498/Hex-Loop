using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hexagon : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] Rigidbody2D rb;

    void Start()
    {
        rb.rotation = Random.Range(0f, 360f);
        transform.localScale = Vector3.one * 10f;
    }

    void Update()
    {
        transform.localScale -= Vector3.one * speed * Time.deltaTime;    
        if (transform.localScale.x < 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
