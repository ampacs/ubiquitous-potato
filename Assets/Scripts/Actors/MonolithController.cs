using UnityEngine;

public class MonolithController : Actor {

    public bool activated;
    public Vector3 keystoneOffset;

    public BoxCollider boxCollider;
    public SphereCollider sphereCollider;
    private MeshRenderer[] _meshRenderers;
    private MeshRenderer _meshRenderer;

    public Material[] materials;
    public ParticleSystem[] particleSystems;

    //private Material defaultMaterial;

    public void Activate () {
        Debug.Log("Activated!");
        sphereCollider.enabled = true;
        keystone.GetComponent<KeystoneManager>().AddElementToPlayer();
        activated = true;

        Debug.Log(keystone.GetComponent<KeystoneManager>().element.GetComponent<BaseElement>().type.ToString());

        switch (keystone.GetComponent<KeystoneManager>().element.GetComponent<BaseElement>().type) {
            case BaseElement.ElementType.Air:
                particleSystems[0].Play();
                SetMaterialInChildren(materials[0]);
                break;
            case BaseElement.ElementType.Earth:
                particleSystems[1].Play();
                SetMaterialInChildren(materials[1]);
                break;
            case BaseElement.ElementType.Fire:
                particleSystems[2].Play();
                SetMaterialInChildren(materials[2]);
                //_meshRenderer.materials = new Material[]{materials[2]};
                //_meshRenderer.material = materials[2];
                break;
            case BaseElement.ElementType.Water:
                particleSystems[3].Play();
                SetMaterialInChildren(materials[3]);
                break;
            default:
                SetMaterialInChildren(materials[4]);
                break;
        }
    }

    public void Deactivate () {
        Debug.Log("Deactivated!");
        sphereCollider.enabled = false;
        if (keystone != null)
            keystone.GetComponent<KeystoneManager>().RemoveElementFromPlayer();
        activated = false;

        for (int i = 0; i < particleSystems.Length; i++) {
            particleSystems[i].Stop();
        }
        SetMaterialInChildren(materials[4]);
    }

    private void SetMaterialInChildren (Material material) {
        if (_meshRenderers != null)
            for (int i = 0; i < _meshRenderers.Length; i++) {
                _meshRenderers[i].material = material;
            }
    }

    void Start () {
        //defaultMaterial = materials[4];
        _meshRenderers = GetComponentsInChildren<MeshRenderer>();
        Debug.Log("** " + _meshRenderers.Length);
        SetMaterialInChildren(materials[4]);

        if (activated) {
            Activate();
        } else {
            Deactivate();
        }
    }
}
