using UnityEngine;

public class ActionElementSpawn : BaseAction {

    BaseInteractable interactable;

    public GameObject gameObjectToSpawn;

    public override bool Condition () {
        return true;
    }

    public override void Activate () {
        particles.Play();
        GameObject instantiatedGameObject = (GameObject)Instantiate(gameObjectToSpawn, transform.position, transform.rotation);
    }

    public override void Deactivate () {

    }
}
