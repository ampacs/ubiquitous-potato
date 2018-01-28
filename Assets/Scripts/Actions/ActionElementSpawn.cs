﻿using UnityEngine;

public class ActionElementSpawn : BaseAction {

    BaseInteractable interactable;

    public GameObject gameObjectToSpawn;

    public override bool Condition () {
        return true;
    }

    public override void Activate () {
    }

    public override void Deactivate () {

    }

    void Awake() {
        //particles.Play();
        actionMoment = Time.time;
    }

    void Start() {
        RaycastHit hit;
        if (Physics.Raycast(PlayerController.instance.transform.position + positionOffsetMultiplier*PlayerController.instance.transform.forward, Vector3.down, out hit, 10f)) {
            GameObject instantiatedGameObject = (GameObject)Instantiate(gameObjectToSpawn, PlayerController.instance.transform.position + positionOffsetMultiplier*PlayerController.instance.transform.forward + (hit.distance-0.5f)*Vector3.down, transform.rotation);
        } else {
            Destroy(this.gameObject);
        }
    }

    void Update() {
        if (Time.time - actionMoment > actionTime) {
            Destroy(this.gameObject);
        }
    }
}