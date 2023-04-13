using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{
    [SerializeField]
    private BGMPlayer _BGMPlayer;

    [SerializeField]
    private int _SpectrumNum;

    [SerializeField]
    private SpectrumBar _BarPrefab;
    private SpectrumBar[] _SpectrumBars;

    void Start()
    {
        _SpectrumBars = new SpectrumBar[_SpectrumNum];
        for(int i = 0; i < _SpectrumNum; ++i)
        {
            SpectrumBar bar = Instantiate(_BarPrefab);
            bar.transform.parent = transform;
            bar.transform.position = new Vector3(2.0f * i - _SpectrumNum + 1.0f, 0, 60);
            _SpectrumBars[i] = bar;
        }
    }

    void Update()
    {
        float[] spectrum = _BGMPlayer.GetSpectrum(_SpectrumNum, 0);
        for (int i = 0; i < _SpectrumNum; ++i)
        {
            _SpectrumBars[i].BarHeight = spectrum[i] * 500.0f;
        }
    }
}
