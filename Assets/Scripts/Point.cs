using UnityEngine;
using Random = System.Random;

public class Point
{
    private Vector3 _point;
    private float _currentDistance;
    private float _maxDistance = 0.1f;
    private Random _randomPositionPoint;
    private int _minPositionX;
    private int _maxPositionZ;

    public Vector3 GetPoint => _point;

    public Point(int minPositionX, int maxPositionZ)
    {
        _minPositionX = minPositionX;
        _maxPositionZ = maxPositionZ;
        _randomPositionPoint = new Random();
        NewPoint();
    }

    public void NewPoint()
    {
        float x = _randomPositionPoint.Next(_minPositionX, _maxPositionZ);
        float z = _randomPositionPoint.Next(_minPositionX, _maxPositionZ);
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
