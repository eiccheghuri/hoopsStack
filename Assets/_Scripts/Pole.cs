using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole : MonoBehaviour
{

    public List<GameObject> _torus;
    public Transform _pipeTransform;

    public void DeleateObjectFromList(int index)
    {
        _torus[index] = null;
       // _torus.RemoveAt(index);
    }
    public GameObject SelectingFirstObjectFromList()
    {
        for (int i = 0; i < _torus.Count; i++)
        {
            if(_torus[i]!=null)
            {
                return _torus[i];
            }
           

        }
        return null;
    }



}
