using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class DragTransform : MonoBehaviour
{
    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance;

    private Rigidbody _rigidbody;

    private Renderer renderer;
    private void Start()
    {
        // renderer = GetComponent<Renderer>();

        _rigidbody = GetComponent<Rigidbody>();
    }


    void OnMouseEnter()
    {
      //  renderer.material.color = mouseOverColor;
    }

    void OnMouseExit()
    {
     //   renderer.material.color = originalColor;
    }

    void OnMouseDown()
    {
        distance = Vector2.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        _rigidbody.useGravity = false;
       
    }

    void OnMouseUp()
    {
        dragging = false;
        _rigidbody.useGravity = true;
       
        
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
           // _rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }
}

