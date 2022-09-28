using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private SpriteRenderer _background;

    [SerializeField]
    private CharacterView _characterView;

    [SerializeField]
    private CannonView _cannonView;
    
    [SerializeField]
    private SpriteAnimationsConfig _spriteAnimationConfig;

    private ParalaxManager _paralaxManager;
    private SpriteAnimator _spriteAnimator;
    private PlayerWalk _playerWalk;
    private AimingMuzzle _aimingMuzzle;
    private BulletsEmitter _bulletsEmitter;


    [SerializeField]
    private List<BulletView> _bullets;

    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera, _background.transform);
        _aimingMuzzle = new AimingMuzzle(_cannonView.transform, _characterView.transform);
        _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
        _playerWalk = new PlayerWalk(_characterView, _spriteAnimator);
        _bulletsEmitter = new BulletsEmitter(_bullets, _cannonView.MuzzleTransform);

    }

    private void Update()
    {
        _paralaxManager.Update();
        _spriteAnimator.Update();
        _playerWalk.Update();
        _aimingMuzzle.Update();
        _bulletsEmitter.Update();
    }

    private void FixedUpdate()
    {

    }

    private void OnDestroy()
    {

    }
}