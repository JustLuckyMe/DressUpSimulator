using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour
{
    [SerializeField] private GameObject collider;
    [SerializeField] private GameObject model;

    private bool isDragging = false;
    private Vector3 lastMousePosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button pressed
        {
            RaycastFromMouse();
        }

        if (Input.GetMouseButton(0)) // Left mouse button held down
        {
            if (isDragging)
            {
                RotateModelWithMouse();
            }
        }

        if (Input.GetMouseButtonUp(0)) // Left mouse button released
        {
            isDragging = false;
        }
    }

    void RaycastFromMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == collider)
            {
                isDragging = true;
                lastMousePosition = Input.mousePosition;
            }
        }
    }

    void RotateModelWithMouse()
    {
        Vector3 delta = Input.mousePosition - lastMousePosition;
        float rotationY = -delta.x * 0.5f;

        model.transform.Rotate(Vector3.up, rotationY, Space.World);

        lastMousePosition = Input.mousePosition;
    }
}