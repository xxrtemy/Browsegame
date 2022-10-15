using UnityEngine;

public class RootGenerator : MonoBehaviour
{
    [SerializeField]
    private GenerateLevelView _generateLevelView;

    [SerializeField]
    private GenerateLevelController _generateLevelController;

    public void Awake()
    {
        _generateLevelController = new GenerateLevelController(_generateLevelView);
        _generateLevelController.Awake();
    }
}
