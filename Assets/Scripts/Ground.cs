using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    

    private MeshRenderer _ground;
    private  float _speed;
    
    void Awake()
    {
        _ground = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
         _speed = GameManager.Instance.gameSpeed / transform.localScale.x;
        _ground.material.mainTextureOffset += Vector2.right * _speed * Time.deltaTime;
    }
}
