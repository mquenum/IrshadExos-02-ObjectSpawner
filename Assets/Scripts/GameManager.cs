using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

            // cube creation
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            // change the cube scale
            cube.transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);

            // position the cube
            cube.transform.position = new Vector3(0, worldPosition.y, worldPosition.z);

            // set a color to the cube
            cube.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
