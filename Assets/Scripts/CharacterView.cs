using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [Header("Settings")]
    [SerializeField]
    private float _walkSpeed = 1;

    [SerializeField]
    private float _animationsSpeed = 3;

    [SerializeField]
    private float _jumpStartSpeed = 2;

    [SerializeField]
    private float _movingThresholdValue = 0.1f;

    [SerializeField]
    private float _flyThresholdValue = 0.3f;

    [SerializeField]
    private float _groundLevel = 0.1f;

    [SerializeField]
    private float _acceleration = -10f;

    public SpriteRenderer SpriteRenderer => _spriteRenderer;

    public float WalkSpeed => _walkSpeed;
    public float AnimationsSpeed => _animationsSpeed;
    public float JumpStartSpeed => _jumpStartSpeed;
    public float MovingThresholdValue => _movingThresholdValue;
    public float FlyThresholdValue => _flyThresholdValue;
    public float GroundLevel => _groundLevel;
    public float Acceleration => _acceleration;
}