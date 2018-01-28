using UnityEngine;

public class BaseHazard : MonoBehaviour {
    public BaseElement element;
    public int damage = 100;
    public bool walkable { get; protected set; }
    protected bool collided;
    protected bool collidedWithPlayer;
    protected bool triggered;
    protected bool triggeredByPlayer;

    void OnCollisionEnter(Collision collisionInfo) {
        if (collisionInfo.gameObject.tag.Equals("Player")) {
            if (element == null)
                 collisionInfo.gameObject.GetComponent<PlayerHealthManager>().ApplyDamage(damage);
            else collisionInfo.gameObject.GetComponent<PlayerHealthManager>().ApplyDamage(damage, element.type);
            collidedWithPlayer = true;
        }
        collided = true;
    }

    void OnTriggerEnter(Collider other) {
        if (other.transform.tag.Equals("Player")) {
            if (element == null)
                 other.transform.GetComponent<PlayerHealthManager>().ApplyDamage(damage);
            else other.transform.GetComponent<PlayerHealthManager>().ApplyDamage(damage, element.type);
            triggeredByPlayer = true;
        }
        triggered = true;
    }
}
