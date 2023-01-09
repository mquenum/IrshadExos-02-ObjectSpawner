using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _obj;
    [SerializeField] int _nbObjectBySec = 10;
    [SerializeField] float _spawnCircleRadius = 1.0f;
    [SerializeField] private int _maxNumberOfObject = 10;

    private List<GameObject> _objects;
    private int _counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        _objects = new List<GameObject>();
        // launches function (1st parameter) at given time (2nd parameter) and relaunches it every given time
        // (3rd parameter, here one second divided by the number of obj by second)
        InvokeRepeating("ObjSpawn", 0.0f, (1.0f / _nbObjectBySec));
    }

    private void ObjSpawn()
    {
        if (_obj)
        {
            // obj creation
            InstObj(_obj);
        }
    }

    private void InstObj(GameObject obj)
    {
        if (_counter < _maxNumberOfObject)
        {
            GameObject instPrefab = GameObject.Instantiate(obj, Random.insideUnitSphere * _spawnCircleRadius, Quaternion.identity);
            // set a random color to the obj
            instPrefab.GetComponent<Renderer>().material.color = Random.ColorHSV();
            //instPrefab.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            _objects.Add(instPrefab);
            _counter++;
        }
        else
        {
            // position the obj that was added last
            _objects[0].transform.position = Random.insideUnitSphere * _spawnCircleRadius;
        }
    }
}
