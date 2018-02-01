using UnityEngine;

public class DestroyedParticles : MonoBehaviour {

    public float lifetime = 10f;
    private float _momentOfCreation;
    private ParticleSystem _particleSystem;

    void Start () {
        _momentOfCreation = Time.time;
    }
    
    // Update is called once per frame
    void Update () {
        if (Time.time - _momentOfCreation > lifetime) {
            Destroy(gameObject);
        }
    }
}
