using UnityEngine;

public class ContactsPoller 
{
    private const float CollisionThresholdValue = 0.1f;

    private ContactPoint2D[] _contacts = new ContactPoint2D[10];
    private readonly Collider2D _collider2D;

    public bool IsGrounded { get; private set; }
    public bool HasLeftContacts { get; private set; }
    public bool HasRightContacts { get; private set; }

    public ContactsPoller (Collider2D collider2D)
    {
        _collider2D = collider2D;
    }

    public void Update()
    {
        IsGrounded = false;
        HasLeftContacts = false;
        HasRightContacts = false;

        var contactsCount = _collider2D.GetContacts(_contacts);

        for (var i = 0; i < contactsCount; i++)
        {
            var normal = _contacts[i].normal;
            var rigidbody = _contacts[i].rigidbody;

            if (normal.y > CollisionThresholdValue)
                IsGrounded = true;

            if (normal.x > CollisionThresholdValue && rigidbody == null)
                HasLeftContacts = true;

            if (normal.x < -CollisionThresholdValue && rigidbody == null)
                HasRightContacts = true;
        }
    }
}
