using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Color fullOpacity;
    private Color highTransparency;
    private bool isDragging = false;
    private Vector3 offset;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        fullOpacity = meshRenderer.material.color;
        highTransparency = new Color(fullOpacity.r, fullOpacity.g, fullOpacity.b, 0.3f); // ≈ı∏Ìµµ 30%
        meshRenderer.material.color = highTransparency;
    }

    void Update()
    {
        if (isDragging)
        {
            DragObject();
        }

        CheckForMouseEvents();
    }

    void CheckForMouseEvents()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if mouse is over the gameObject
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
            if (Input.GetMouseButtonDown(0)) // When left mouse button is pressed
            {
                StartDragging(hit.point);
            }
        }

        if (Input.GetMouseButtonUp(0) && isDragging) // When left mouse button is released
        {
            StopDragging();
        }

        // Check for right mouse click to rotate the object
        if (Input.GetMouseButtonDown(1) && hit.collider.gameObject == gameObject) // When right mouse button is clicked
        {
            RotateObject();
        }
    }

    void StartDragging(Vector3 hitPoint)
    {
        isDragging = true;
        meshRenderer.material.color = fullOpacity; // Change to full opacity when dragging
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z));
    }

    void StopDragging()
    {
        isDragging = false;
        meshRenderer.material.color = highTransparency; // Restore transparency when not dragging
    }

    void DragObject()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z));
        transform.position = mousePosition + offset;
    }

    void RotateObject()
    {
        transform.Rotate(0, -90, 0); // Rotate object counter-clockwise by 90 degrees
    }
}