using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 50f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        if(Input.GetMouseButtonDown(0)) //Prints the name of the tile being clicked on
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                // Get the top-most object that is not the parent of all tiles
                Transform selectedObject = hit.transform;
                while (selectedObject.parent != null && selectedObject.parent.name != "HexGrid")
                {
                    selectedObject = selectedObject.parent;
                }

                Debug.Log(selectedObject.name);
            }

            else
                Debug.Log("uhh");
        }
    }
}
