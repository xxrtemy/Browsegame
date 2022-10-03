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

    [SerializeField]
    private List<CoinView> _coinViews;

    private ParalaxManager _paralaxManager;
    private SpriteAnimator _spriteAnimator;
    private AimingMuzzle _aimingMuzzle;
    private BulletsEmitter _bulletsEmitter;
    private PhysicsPlayerWalk _physicsPlayerWalk;
    private CoinsManager _coinsManager;


    [SerializeField]
    private List<BulletView> _bullets;

    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera, _background.transform);
        _aimingMuzzle = new AimingMuzzle(_cannonView.transform, _characterView.transform);
        _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
        _bulletsEmitter = new BulletsEmitter(_bullets, _cannonView.MuzzleTransform);
        _physicsPlayerWalk = new PhysicsPlayerWalk(_characterView, _spriteAnimator);
        _coinsManager = new CoinsManager(_coinViews);

    }

    private void Update()
    {
        _paralaxManager.Update();
        _spriteAnimator.Update();
        _aimingMuzzle.Update();
        _bulletsEmitter.Update();
    }

    private void FixedUpdate()
    {
        _physicsPlayerWalk.FixedUpdate();
    }

    private void OnDestroy()
    {
        _coinsManager.Dispose();
    }
}