using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private bool _cube;
    [SerializeField] private bool _sphere;
    [SerializeField] private bool _capsule;
    [SerializeField] private bool _cylinder;
    [SerializeField] private bool _plane;

    void Update()
    {
        CubeOnClick();
    }

    private void CubeOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // get the mouse position
            Vector3 mousePosition = Input.mousePosition;

            // since mouse position z axis is always at 0 (because mouse position is in 2D: top & left)
            // set the z axis to a distance from camera
            mousePosition.z = 5.0f;

            // create a variable where we transform screen coordinates in space coordinates (relative to game view)
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // obj creation
            // TODO: LE CODE LE PLUS DEGUEULASSE DU MONDE, A REVOIR... MAIS COMMENT ?
            GameObject obj;
            if (_cube)
            {
                _prefab = null;
                _sphere = false;
                _capsule = false;
                _cylinder = false;
                _plane = false;

                obj = GameObject.CreatePrimitive(PrimitiveType.Cube);

                SetupObj(obj, worldPosition);
            }
            else if (_sphere)
            {
                _prefab = null;
                _cube = false;
                _capsule = false;
                _cylinder = false;
                _plane = false;

                obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                SetupObj(obj, worldPosition);
            }
            else if (_capsule)
            {
                _prefab = null;
                _cube = false;
                _sphere = false;
                _cylinder = false;
                _plane = false;

                obj = GameObject.CreatePrimitive(PrimitiveType.Capsule);

                SetupObj(obj, worldPosition);
            }
            else if (_cylinder)
            {
                _prefab = null;
                _cube = false;
                _sphere = false;
                _capsule = false;
                _plane = false;

                obj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

                SetupObj(obj, worldPosition);
            }
            else if (_plane)
            {
                _prefab = null;
                _cube = false;
                _sphere = false;
                _capsule = false;
                _cylinder = false;

                obj = GameObject.CreatePrimitive(PrimitiveType.Plane);

                SetupObj(obj, worldPosition);
            }
            else if (_prefab)
            {
                _cube = false;
                _sphere = false;
                _capsule = false;
                _cylinder = false;
                _plane = false;

                obj = _prefab.gameObject;

                SetupObj(obj, worldPosition);
            }
        }
    }

    private void SetupObj(GameObject obj, Vector3 worldPosition)
    {
        // change the obj scale
        obj.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);

        // position the obj
        obj.transform.position = new Vector3(0, worldPosition.y, worldPosition.z);

        if (_prefab == null)
        {
            // set a color to the obj
            obj.GetComponent<Renderer>().material.color = Color.red;
        }

        if (_prefab)
        {
            GameObject instPrefab = GameObject.Instantiate(_prefab, new Vector3(0, worldPosition.y, worldPosition.z), Quaternion.identity);
            instPrefab.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
}
