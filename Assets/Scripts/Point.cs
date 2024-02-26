using UnityEngine;
using Random = System.Random;

public class Point
{
    private Vector3 _point;
    private float _currentDistance;
    private float _maxDistance = 0.1f;
    private Random _randomPositionPoint;
    private int _width;
    private int _height;

    public Vector3 GetPoint => _point;

    public Point(int width, int height)
    {
        _width = width;
        _height = height;
        _randomPositionPoint = new Random();
        NewPoint();
    }

    public void NewPoint()
    {
        float x = _randomPositionPoint.Next(_width, _height);
        float z = _randomPositionPoint.Next(_width, _height);
        _point = new Vector3(x, 0, z);
    }

    public bool CheckDistance(Vector3 entityPosition)
    {
        _currentDistance = Vector3.Distance(entityPosition, _point);
        if (_currentDistance <= _maxDistance)
        {
            return true;
        }
        return false;
    }


}
