using UnityEngine;

[CreateAssetMenu(fileName = "torus", menuName = "CustomObject/Torus")]
public class torus : ScriptableObject
{
    public string prefabName;
    public GameObject torusPrefab;
    public Material torusMaterial;
}