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
                _gameObject.GetComponentInParent<Pole>().DeleateObjectFromList(0);
                


                _selectedGameObject.transform.position = new Vector3(_selectedGameObject.transform.position.x,
                    _selectedGameObject.transform.position.y+1f,_selectedGameObject.transform.position.z);
                 _rigidbody = _selectedGameObject.GetComponent<Rigidbody>();
                _rigidbody.useGravity = false;
                 
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

            _rigidbody.useGravity = true;
            _selectedGameObject = null;


        }
        else if(Input.GetMouseButton(0)&& _selectedGameObject!=null)
        {

            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _selectedGameObject.transform.position = new Vector3(newPos.x ,newPos.y, 2.23f);
            

        }
        else if(Input.GetMouseButtonUp(0)&&_selectedGameObject!=null)
        {

            _selectedGameObject.GetComponent<torusScripts>().isFalling = true;
            _rigidbody.useGravity = true;
            
            _selectedGameObject = null;
        }



        

    }




}
