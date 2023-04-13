using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class SpectrumBar : MonoBehaviour
{
    private Mesh _Mesh;

    private Vector3[] _Vertices;

    public float BarHeight;

    void Start()
    {
        _Mesh = GetComponent<MeshFilter>().sharedMesh;
        _Vertices = _Mesh.vertices;
    }

    void Update()
    {
        _Mesh.vertices = _Vertices
            .Select(value => new Vector3(value.x, value.y * BarHeight, value.z))
            .ToArray();
    }
}
