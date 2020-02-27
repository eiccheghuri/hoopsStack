using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch2 : MonoBehaviour
{
    private GameObject _gameObject = null;
    private Rigidbody _rigidbody;
    private Vector3 _mouseOffset;

    private GameObject _selectedGameObject;

    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField]
    private float _rayMaxDistance = 50f;

    private int TimeCount = 0;

    public void Update()
    {

        HookTouch();


    }

    public void HookTouch()
    {
        if(Input.GetMouseButtonDown(0)&&_selectedGameObject==null)
        {
            Ray _mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hit;
            if(Physics.Raycast(_mouseRay.origin,_mouseRay.direction,out _hit,_rayMaxDistance,_layerMask))
            {
                _gameObject = _hit.transform.gameObject;
                
                _selectedGameObject=_gameObject.GetComponentInParent<Pole>().SelectingFirstObjectFromList();
               

                if(_selectedGameObject==null)
                {
                    return;
                }
                _gameObject.GetComponentInParent<Pole>().DeleateObjectFromList();
                


                 _selectedGameObject.transform.position = new Vector3(_selectedGameObject.transform.position.x,
                 _selectedGameObject.transform.position.y,_selectedGameObject.transform.position.z);
                 _rigidbody = _selectedGameObject.GetComponent<Rigidbody>();
                _rigidbody.useGravity = false;
                _mouseOffset = _selectedGameObject.transform.position - _hit.transform.position;
                 
            }
        }
        else if(Input.GetMouseButtonDown(0)&&_selectedGameObject!=null)
        {
            
            Ray _mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hit;
            if(Physics.Raycast(_mouseRay.origin,_mouseRay.direction,out _hit,_rayMaxDistance,_layerMask))
            {
                 _gameObject = _hit.transform.gameObject;
                _selectedGameObject.transform.position = new Vector3(_gameObject.transform.position.x,_selectedGameObject.transform.position.y,_selectedGameObject.transform.position.z);
                //_selectedGameObject.transform.position = _gameObject.GetComponentInParent<Pole>()._pipeTransform.position;
            }
             _rigidbody.velocity = Vector3.zero;
            _rigidbody.useGravity = true;
            _selectedGameObject = null;


        }
        else if(Input.GetMouseButton(0)&& _selectedGameObject!=null)
        {

            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 finalPos = new Vector3(Mathf.Clamp(newPos.x+_mouseOffset.x,-2.27f,7),Mathf.Clamp(newPos.y + _mouseOffset.y,2f,3f),2.23f);

            _selectedGameObject.transform.position = finalPos;
            

        }
        else if(Input.GetMouseButtonUp(0)&&_selectedGameObject!=null)
        {

            _selectedGameObject.GetComponent<torusScripts>().isFalling = true;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.useGravity = true;
            
            _selectedGameObject = null;
        }



        

    }




}
