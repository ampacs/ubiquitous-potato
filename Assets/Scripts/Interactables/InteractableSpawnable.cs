using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSpawnable : BaseInteractable {

    public GameObject extraSpawnableGameObject;

    public override void Activate () {
        this.enabled = true;
        momentOfInteration = Time.time;
        if (particles != null) particles.Play();
        //AudioManager.instance.Play(soundEffects[0]);
    }

    public void Deactivate () {
        if (particles != null) particles.Stop();
        /*GameObject instantiatedGameObject = (GameObject)*/
        Instantiate(extraSpawnableGameObject, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    //void Update() {
    //    if (Time.time - momentOfInteration > interationTime) {
    //    }
    //}
}
