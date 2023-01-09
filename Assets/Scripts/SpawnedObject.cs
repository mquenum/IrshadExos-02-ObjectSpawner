using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObject : MonoBehaviour
{
    [SerializeField] private float _minSpeed = 1.0f;
    [SerializeField] private float _maxSpeed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ici");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
