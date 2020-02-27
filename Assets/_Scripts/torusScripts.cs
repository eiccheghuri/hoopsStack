using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torusScripts : MonoBehaviour
{

    public GameObject[] _poleArray;
    private Vector3 _distance;
    private Rigidbody _rigidbody;
    public bool isFalling=false;
    private float _minDistance=0;
    private int _index;
    

    private void Start()
    {
        _poleArray = GameObject.FindGameObjectsWithTag("base");
        _rigidbody = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        if(isFalling==true)
        {
            for (int i = 0; i < _poleArray.Length; i++)
            {
                float tempDistance = Vector3.Distance(transform.position,_poleArray[i].transform.position);
                if(i==0)
                {
                    _minDistance = tempDistance;
                    _index = i;
                }
                else if(tempDistance<_minDistance)
                {
                    _minDistance = tempDistance;
                    _index = i;
                }

                
            }
            transform.position = new Vector3(_poleArray[_index].transform.position.x,transform.position.y,transform.position.z);
            Pole _pole = _poleArray[_index].GetComponentInParent<Pole>();
            _pole.InsertGameobjectInList(transform.gameObject);
          
             isFalling = false;
           
           
        }
    }


}
