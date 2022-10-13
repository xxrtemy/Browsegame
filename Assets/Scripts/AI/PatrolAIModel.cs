using UnityEngine;

public class PatrolAIModel
{
    private readonly AIConfig _config;
    private Transform _target;
    private int _currentPointIndex;

    public PatrolAIModel(AIConfig config)
    {
        _config = config;
        _target = GetNextWaypoint();
    }

    public Vector2 CalculateVelocity(Vector2 fromPosition)
    {
        var distance = Vector2.Distance(_target.position, fromPosition);

        if (distance <= _config.MinDistanceToTarget)
            _target = GetNextWaypoint();

        var direction = ((Vector2)_target.position - fromPosition).normalized;
        return direction * _config.Speed;
    }

    private Transform GetNextWaypoint()
    {
        _currentPointIndex = (_currentPointIndex + 1) % _config.Waypoints.Length;
        return _config.Waypoints[_currentPointIndex];
    }
}