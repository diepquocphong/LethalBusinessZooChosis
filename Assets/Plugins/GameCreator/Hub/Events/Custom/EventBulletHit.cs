using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using UnityEngine;
using System;
[Version(1, 0, 0)]
[Title("On Bullet Hit")]
[Category("Custom/Weapons")]
[Description("Triggered when a bullet hits an object")]
[Image(typeof(IconCollision), ColorTheme.Type.Blue)]
[Serializable]
public class EventBulletHit : GameCreator.Runtime.VisualScripting.Event
{
    [SerializeField] private TagValue m_TargetTag = new TagValue();

    protected override void OnAwake(Trigger trigger)
    {
        base.OnAwake(trigger);
        EnsureColliderExists(trigger.gameObject);
    }

    private void EnsureColliderExists(GameObject gameObject)
    {
        Collider collider = gameObject.GetComponent<Collider>();
        if (collider == null)
        {
            gameObject.AddComponent<BoxCollider>();
        }
    }

    protected override void OnCollisionEnter3D(Trigger trigger, Collision collision)
    {
        base.OnCollisionEnter3D(trigger, collision);

        if (!this.IsActive) return;
        if (!collision.gameObject.CompareTag(this.m_TargetTag.Value)) return;

        GetGameObjectLastCollidedEnter.Instance = collision.gameObject;
        _ = this.m_Trigger.Execute(collision.gameObject);
    }
}

