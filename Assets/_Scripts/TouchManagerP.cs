using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManagerP : MonoBehaviour
{
    private GameObject _gameObject = null;
    private Rigidbody _rigidbody;
    private Vector3 _mouseOffset;

    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField]
    private float _rayMaxDistance=50f;
    private Plane _objectPlane;

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            Ray mouseray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(mouseray.origin,mouseray.direction,out hit,_rayMaxDistance,_layerMask))
            {
                 _gameObject = hit.transform.gameObject;

                _objectPlane = new Plane(Camera.main.transform.forward*-1,_gameObject.transform.position);
                Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                float _rayDistance;
                _objectPlane.Raycast(mRay,out _rayDistance);
                _mouseOffset = _gameObject.transform.position - mRay.GetPoint(_rayDistance);
                _rigidbody = _gameObject.GetComponent<Rigidbody>();
                _rigidbody.useGravity = false;
            }


        }
        else if(Input.GetMouseButton(0)&& _gameObject)
        {
            
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float _rayDistance;
            if(_objectPlane.Raycast(mRay,out _rayDistance))
            {
                _gameObject.transform.position = mRay.GetPoint(_rayDistance) + _mouseOffset;
               // _gameObject.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y, 2.230411f);

            }
           


        }
        else if(Input.GetMouseButtonUp(0)&&_gameObject)
        {
            _gameObject = null;
            
            _rigidbody.useGravity = true;
        }
    }


}
