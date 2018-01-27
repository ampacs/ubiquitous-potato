using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour {
    public enum GameInteraction { Burnable, Pushable, Spawnable, Shieldable }

    public bool activated = false;
    public GameInteraction interaction;
    public ParticleSystem particles;
    public string[] soundEffects;
    public Vector3 centerOfInteraction;
    public Vector3 directionOfInteraction;
    public float interationTime;
    protected float momentOfInteration;

    public abstract void Activate ();
}
