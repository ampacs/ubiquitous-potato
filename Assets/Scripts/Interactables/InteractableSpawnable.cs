using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSpawnable : BaseInteractable {

    public override void Activate () {
        this.enabled = true;
        momentOfInteration = Time.time;
        if (particles != null) particles.Play();
        //AudioManager.instance.Play(soundEffects[0]);
    }

    //void Update() {
    //    if (Time.time - momentOfInteration > interationTime) {
    //    }
    //}
}
