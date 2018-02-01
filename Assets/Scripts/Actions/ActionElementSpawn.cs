using UnityEngine;

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

    void Start() {
        RaycastHit hit;
        if (Physics.Raycast(PlayerController.instance.transform.position + positionOffsetMultiplier*PlayerController.instance.transform.forward, Vector3.down, out hit, 10f)) {
            GameObject instantiatedGameObject = (GameObject)Instantiate(gameObjectToSpawn, PlayerController.instance.transform.position + positionOffsetMultiplier*PlayerController.instance.transform.forward + hit.distance*Vector3.down, transform.rotation);
            GameManager.instance.interactables.Add(instantiatedGameObject);
        } else {
            Destroy(this.gameObject);
        }
    }

    void Update() {
        if (Time.time - actionMoment > actionTime) {
            if (audioSource != null)
                audioSource.Stop();
            Destroy(this.gameObject);
        }
    }
}
