using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableShield : BaseInteractable {

    public bool isShielded;
    public BaseElement shieldElement;
    public GameObject shieldObject;
    private GameObject instantiatedGameObject;
    public override void Activate () {
        this.enabled = true;
        momentOfInteration = Time.time;
        if (particles != null) particles.Play();

        isShielded = true;
        //CapsuleCollider capsule = shieldObject.GetComponent<CapsuleCollider>();
        //capsule.radius = PlayerController.instance.GetComponent<CapsuleCollider>().radius*1.05f;
        //capsule.height = PlayerController.instance.GetComponent<CapsuleCollider>().height*1.05f;
        //capsule.center = new Vector3(0f, 2*0.05f*PlayerController.instance.GetComponent<CapsuleCollider>().height, 0f);
        //instantiatedGameObject = (GameObject)Instantiate(shieldObject, PlayerController.instance.transform.position, transform.rotation, PlayerController.instance.transform);
        //AudioManager.instance.Play(soundEffects[0]);
    }

    void Update() {
        if (isShielded && Time.time - momentOfInteration > interationTime) {
            isShielded = false;
        }
    }
}
