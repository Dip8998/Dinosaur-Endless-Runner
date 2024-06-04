using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJspawner : MonoBehaviour
{
    public static OBJspawner Instance;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] public float maxTimer;
    private float _timer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
       Spawn();
    }
    private void Update()
    {
        if (_timer > maxTimer)
        {
            Spawn();
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }
    private void Spawn()
    {
        int randomIndex = Random.Range(0, 6);
        GameObject Obj = Instantiate(prefabs[randomIndex], transform.position , Quaternion.identity);
        Destroy(Obj , 10f);
    }
}
