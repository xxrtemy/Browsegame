using System;
using UnityEngine;

public class CoinView : MonoBehaviour
{
    public Action<CoinView> OnLevelObjectContact { get; set; }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var levelObject = collider.gameObject.GetComponent<CharacterView>();

        if (levelObject != null)
            OnLevelObjectContact?.Invoke(this);
    }
}
