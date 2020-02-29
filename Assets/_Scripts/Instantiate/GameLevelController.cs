using UnityEngine;

public class GameLevelController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _torusPrefab;
    [SerializeField]
    private Transform spawnTransform;

    private void Awake()
    {
        InstantiateTorus();
    }

    private void Start()
    {
        
    }


    


    private void InstantiateTorus()
    {
        for (int i = 0; i < _torusPrefab.Length; i++)
        {
           GameObject tempObject= Instantiate(_torusPrefab[i],transform.position,Quaternion.identity);

            tempObject.transform.position = new Vector3(transform.position.x, transform.position.y+i, 2.23f);


        }
    }

}