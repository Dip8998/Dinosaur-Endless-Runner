using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMove : MonoBehaviour
{
    [SerializeField] private float _objMoveSpeed;

    void Update()
    {
        // pipe move towards left side
        _objMoveSpeed = GameManager.Instance.gameSpeed;
        transform.position += Vector3.left * _objMoveSpeed * Time.deltaTime;
    }
}
