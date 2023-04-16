using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScorePlayer : MonoBehaviour
{
    [SerializeField]
    private List<float> _NoteTiming;

    [SerializeField]
    private AnimationCurve _LeftCurve;

    [SerializeField]
    private AnimationCurve _RightCurve;

    [SerializeField]
    private LineRenderer _LeftGuardRail;

    [SerializeField]
    private LineRenderer _RightGuardRail;

    [SerializeField]
    private MeshCollider _Road;

    public float ElapsedTime => _ElapsedTime;
    private float _ElapsedTime;

    public float BPM;

    public float HighSpeed;

    void Update()
    {
        _ElapsedTime += Time.deltaTime;

        List<Vector3> left = new();
        List<Vector3> right = new();
        List<Vector3> meshVertices = new();

        float beat = BPM * _ElapsedTime / 60;
        for (int i = 0; i <= 1100; ++i)
        {
            float offset = 0.1f * i - 10.0f;
            left.Add(new(8 * _LeftCurve.Evaluate(beat + offset / HighSpeed) + 8, 0, offset));
            right.Add(new(8 * _RightCurve.Evaluate(beat + offset / HighSpeed) - 8, 0, offset));
            meshVertices.Add(new(8 * _LeftCurve.Evaluate(beat + offset / HighSpeed) + 8, 0, offset));
            meshVertices.Add(new(8 * _RightCurve.Evaluate(beat + offset / HighSpeed) - 8, 0, offset));
        }

        _LeftGuardRail.SetPositions(left.ToArray());
        _RightGuardRail.SetPositions(right.ToArray());

        _Road.sharedMesh = new();
        _Road.sharedMesh.SetVertices(meshVertices.ToArray());
        _Road.sharedMesh.SetTriangles(Enumerable.Range(0, 1100)
            .Select(value => (new int[] { 0, 1, 2, 2, 1, 3 }).Select(_value => _value + value).ToArray())
            .Aggregate((prev, curr) => prev.Concat(curr).ToArray()), 0);
    }
}
