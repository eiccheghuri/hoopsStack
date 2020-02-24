using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlller : MonoBehaviour
{

    public GameObject _torus;
    public Camera _camera;


    public void Start()
    {
        
    }

    public void Update()
    {
        



    }

    public void TouchMethod()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // get the touch position from the screen touch to world point
                Vector3 touchedPos = _camera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                // lerp and set the position of the current object to that of the touch, but smoothly over time.
                transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
            }
        }
    }





}//Game Controller Class
