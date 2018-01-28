using UnityEngine;

public class HazardFire : BaseHazard {

    void OnTriggerStay(Collider other) {
        if (other.transform.tag.Equals("Player")) {
            if (element == null)
                 other.transform.GetComponent<PlayerHealthManager>().ApplyDamage(damage);
            else other.transform.GetComponent<PlayerHealthManager>().ApplyDamage(damage, element.type);
            triggeredByPlayer = true;
        }
        triggered = true;
    }
}
