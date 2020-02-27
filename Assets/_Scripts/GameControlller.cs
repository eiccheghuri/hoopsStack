using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlller : MonoBehaviour
{

    public int numberOfBase;
    public List<GameObject> _torus;
    private int _numberOfTorus;

    private void Start()
    {
        _numberOfTorus = _torus.Count;
        SameColorTorus();
    }

    private void Update()
    {
        
    }

    public void SameColorTorus()
    {
        for (int i = 0; i < _torus.Count; i++)
        {
            string material_name = _torus[i].GetComponentInChildren<MeshRenderer>().material.name;
            
        }
    }



}//Game Controller Class
