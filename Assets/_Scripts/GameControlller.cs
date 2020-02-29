using System.Collections.Generic;
using UnityEngine;

public class GameControlller : MonoBehaviour
{
    private GameLevelController gameLevelCOntroller;
   
    public List<GameObject> _torus;
    private int _numberOfTorus;

    private void Start()
    {
        gameLevelCOntroller = FindObjectOfType<GameLevelController>();
        _numberOfTorus = _torus.Count;

       
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

    public void AssingningTorus()
    {

    }

}//Game Controller Class