public class AIPatrol
{
    private readonly EnemyView _view;
    private readonly PatrolAIModel _model;

    public AIPatrol(EnemyView view, PatrolAIModel model)
    {
        _view = view;
        _model = model;
    }

    public void FixedUpdate()
    {
        _view.Rigidbody.velocity = _model.CalculateVelocity(_view.transform.position);
    }
}
