using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSpawnable : BaseInteractable {

    public GameObject gameObjectToSpawn;

    public override void Activate () {
        this.enabled = true;
        momentOfInteration = Time.time;
        if (particles != null) particles.Play();
        
    }
}
