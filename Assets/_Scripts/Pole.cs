using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole : MonoBehaviour
{
    public List<GameObject> _torus;

    public Transform _pipeTransform;

    public int index;
    private string _currentMaterial = "", _previousMaterial = "";

    public GameObject[] _torusArrary;

    private void Start()
    {
        _torusArrary = GameObject.FindGameObjectsWithTag("torus");
    }

    public void DeleateObjectFromList()
    {
        _torus[index] = null;
    }

    public GameObject SelectingFirstObjectFromList()
    {
        for (int i = 0; i < _torus.Count; i++)
        {
            if (_torus[i] != null)
            {
                index = i;
                return _torus[i];
            }
        }
        return null;
    }

    public void InsertGameobjectInList(GameObject torusObject)
    {
        for (int i = _torus.Count - 1; i >= 0; --i)
        {
            if (_torus[i] == null)
            {
                _torus[i] = torusObject;

                return;
            }
        }
    }

    public void GameOver()
    {
        for (int i = _torus.Count - 1; i >= 0; i--)
        {
            if (_torus[i] != null)
            {
                _currentMaterial = _torus[i].GetComponentInChildren<MeshRenderer>().material.name;
            }

            if (_currentMaterial == _previousMaterial)
            {
                _previousMaterial = _currentMaterial;
            }
        }

        if (_previousMaterial == _currentMaterial || _previousMaterial == "")
        {
            Debug.Log("Same Material On :" + gameObject.name);
        }
    }

    private IEnumerator willCheckForGameOver()
    {
        yield return new WaitForSeconds(3f);
        GameOver();
    }
}