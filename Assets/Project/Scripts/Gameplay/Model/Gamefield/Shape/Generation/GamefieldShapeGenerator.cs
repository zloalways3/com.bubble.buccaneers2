using System.Collections.Generic;
using UnityEngine;

public class GamefieldShapeGenerator
{
    private const int MinY = 0;
    private const float DefaultZValue = 0;
    private const float RoundMultiplier = 10f;
    private const float _offsetAmplitude = 100f;

    private readonly int _width;
    private readonly int _offsetY;
    private readonly float _argumentsMultiplier;
    private readonly float _noiseMultiplier;

    private readonly float _offsetX;
    private readonly float _offsetZ;

    private float RandomOffset => Random.Range(-_offsetAmplitude, _offsetAmplitude);

    public GamefieldShapeGenerator(int width, int maxY, int offsetY, float noiseMultiplier)
    {
        _width = width;
        _offsetY = offsetY;
        _argumentsMultiplier = noiseMultiplier;
        _noiseMultiplier = 1f / maxY;

        _offsetX = RandomOffset;
        _offsetZ = RandomOffset;
    }

    public GamefieldShape Generate()
    {
        var columns = new List<GamefieldColumn>();

        for(int x = 0; x < _width; x++)
        {
            var inputX = (x + _offsetX) * _argumentsMultiplier;
            var inputZ = (DefaultZValue + _offsetZ) * _argumentsMultiplier;

            var y = Mathf.PerlinNoise(inputX, inputZ) * _noiseMultiplier;

            var roundedY = Mathf.RoundToInt(y * RoundMultiplier) + _offsetY;

            columns.Add(new GamefieldColumn(MinY, roundedY));
        }

        return new GamefieldShape(columns);
    }
}