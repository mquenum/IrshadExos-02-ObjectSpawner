using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _obj;
    [SerializeField] private int _maxNumberOfObject = 10;

    private List<GameObject> _objects;
    private int _counter = 0;

    private void Start()
    {
        _objects = new List<GameObject>();
    }

    void Update()
    {
        CubeOnClick();
    }

    private void CubeOnClick()
    {
        if (_obj && Input.GetMouseButtonDown(0))
        {
            // get the mouse position
            Vector3 mousePosition = Input.mousePosition;

            // since mouse position z axis is always at 0 (because mouse position is in 2D: top & left)
            // set the z axis to a distance from camera
            mousePosition.z = 5.0f;

            // create a variable where we transform screen coordinates in space coordinates (relative to game view)
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // obj creation
            SetupObj(_obj, worldPosition);
        }
    }

    private void SetupObj(GameObject obj, Vector3 worldPosition)
    {
        if (_counter < _maxNumberOfObject)
        {
            GameObject instPrefab = GameObject.Instantiate(_obj, new Vector3(0, worldPosition.y, worldPosition.z), Quaternion.identity);
            instPrefab.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            _objects.Add(instPrefab);
            _counter++;
        }
        else
        {
            // position the obj that was added last
            _objects[_maxNumberOfObject - 1].transform.position = new Vector3(0, worldPosition.y, worldPosition.z);
        }
    }
}
