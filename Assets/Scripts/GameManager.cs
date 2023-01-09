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
            GameObject instPrefab = GameObject.Instantiate(obj, new Vector3(0, worldPosition.y, worldPosition.z), Quaternion.identity);
            instPrefab.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            _objects.Add(instPrefab);
            _counter++;
        }
        else
        {
            // get the list first obj
            GameObject _firstObject = _objects[0];
            // set the new position of that first object
            _firstObject.transform.position = new Vector3(0, worldPosition.y, worldPosition.z);
            // pop the list at item at index 0
            _objects.RemoveAt(0);
            // add the newly position first object et the end of list
            _objects.Add(_firstObject);
        }
    }
}
