using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    private GameObject gobj = null;
    private Rigidbody _rigidbody;
    private Vector3 _mouseOffset;

    [SerializeField]
    private LayerMask _layerMask;

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            Ray mouseray = GenerateMouseRay();
            RaycastHit hit;
            if(Physics.Raycast(mouseray.origin,mouseray.direction,out hit,50f,_layerMask))
            {
                gobj = hit.transform.gameObject;
                _mouseOffset = hit.transform.position-hit.point;
                
                _rigidbody = gobj.GetComponent<Rigidbody>();
                _rigidbody.useGravity = false;
            }


        }
        else if(Input.GetMouseButton(0)&& gobj)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gobj.transform.position = new Vector3(newPos.x+_mouseOffset.x,newPos.y+_mouseOffset.y,gobj.transform.position.z);
          //  gobj.transform.position = new Vector3(newPos.x + _mouseOffset.x, gobj.transform.position.y, newPos.z + _mouseOffset.z);



        }
        else if(Input.GetMouseButtonUp(0)&&gobj)
        {
            gobj = null;
            _rigidbody.useGravity = true;
        }
    }


    public Ray GenerateMouseRay()
    {

        Vector3 mosuePosFar = new Vector3(Input.mousePosition.x
            , Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 mousePosNear = new Vector3(Input.mousePosition.x,
            Input.mousePosition.y,Camera.main.nearClipPlane);
        Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mosuePosFar);
        Vector3 mosePosN = Camera.main.ScreenToWorldPoint(mousePosNear);
        Ray mr = new Ray(mosePosN,mousePosF-mosePosN);
        return mr;
    }

    

    


}
