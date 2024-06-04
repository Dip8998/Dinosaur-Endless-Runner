using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dinosaur : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    private bool _isGrouded = true;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))&& _isGrouded == true)
        {
            _rb.AddForce(Vector2.up * _speed , ForceMode2D.Impulse);
            _isGrouded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrouded = true;
        }
        if (collision.gameObject.CompareTag("Obstacal"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
