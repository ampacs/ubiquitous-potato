using UnityEngine;

public class InteractableDestructable : BaseInteractable {

    public override void Activate () {
        activated = true;
        momentOfInteration = Time.time;
        if (particles != null) particles.Play();
        //AudioManager.instance.Play(soundEffects[0]);
    }

    void Update() {
        if (activated && Time.time - momentOfInteration > interationTime) {
            Destroy(this.gameObject);
        }
    }
}
