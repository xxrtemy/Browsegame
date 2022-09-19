using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    public SpriteRenderer SpriteRenderer => _spriteRenderer;
}