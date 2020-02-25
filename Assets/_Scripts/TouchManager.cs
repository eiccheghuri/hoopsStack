using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    private GameObject _gameObject = null;
    private Rigidbody _rigidbody;
    private Vector3 _mouseOffset;

    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField]
    private float _rayMaxDistance = 50f;

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            Ray mouseray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(mouseray.origin,mouseray.direction,out hit,_rayMaxDistance,_layerMask))
            {
                 _gameObject = hit.transform.gameObject;
                

                _mouseOffset = hit.transform.localPosition-hit.point;
               
                _rigidbody = _gameObject.GetComponent<Rigidbody>();
                _rigidbody.useGravity = false;
            }


        }
        else if(Input.GetMouseButton(0)&& _gameObject)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _gameObject.transform.position = new Vector3(newPos.x+_mouseOffset.x,newPos.y+_mouseOffset.y, 2.230411f);
            
        }
        else if(Input.GetMouseButtonUp(0)&&_gameObject)
        {
            
            _gameObject = null;
            _rigidbody.useGravity = true;
        }
    }


    public Ray GenerateMouseRay()
    {

        Vector3 mosuePosFar = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.farClipPlane);
        Vector3 mousePosNear = new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.nearClipPlane);
        Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mosuePosFar);
        Vector3 mosePosN = Camera.main.ScreenToWorldPoint(mousePosNear);
        Ray mouseRay = new Ray(mosePosN,mousePosF-mosePosN);
        return mouseRay;
    }

    

    


}
