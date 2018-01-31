using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonolithController : Actor {

    public bool activated;
    public Vector3 keystoneOffset;

    public BoxCollider boxCollider;
    public SphereCollider sphereCollider;
    public MeshRenderer meshRenderer;

    public Material[] materials;
    public ParticleSystem[] particleSystems;

    private Material defaultMaterial;

    public void Activate () {
        sphereCollider.enabled = true;
        keystone.GetComponent<KeystoneManager>().AddElementToPlayer();
        activated = true;

        switch (keystone.GetComponent<KeystoneManager>().element.GetComponent<BaseElement>().type) {
            case BaseElement.ElementType.Air:
                particleSystems[0].Play();
                meshRenderer.material = materials[0];
                break;
            case BaseElement.ElementType.Earth:
                particleSystems[1].Play();
                meshRenderer.material = materials[1];
                break;
            case BaseElement.ElementType.Fire:
                particleSystems[2].Play();
                meshRenderer.material = materials[2];
                break;
            case BaseElement.ElementType.Water:
                particleSystems[3].Play();
                meshRenderer.material = materials[3];
                break;
            default:
                meshRenderer.material = materials[4];
                break;
        }
    }

    public void Deactivate () {
        sphereCollider.enabled = false;
        if (keystone != null)
            keystone.GetComponent<KeystoneManager>().RemoveElementFromPlayer();
        activated = false;

        for (int i = 0; i < particleSystems.Length; i++) {
            particleSystems[i].Stop();
        }
        meshRenderer.material = materials[4];
    }

    void Start () {
        if (activated) {
            Activate();
        } else {
            Deactivate();
        }
        defaultMaterial = meshRenderer.sharedMaterial;
    }

    void FixedUpdate() {

    }
}
