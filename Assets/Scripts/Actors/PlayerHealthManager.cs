using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

    public bool shieldedByAir;
    public bool shieldedByEarth;
    public bool shieldedByFire;
    public bool shieldedByWater;
    public bool alive = true;
    public int hp = 100;


    private InteractableShield _shieldSpawner;

    public void ApplyDamage (int damage) {
        hp -= damage;
    }

    public void ApplyDamage (int damage, BaseElement.ElementType elementalType) {
        switch (elementalType) {
            case BaseElement.ElementType.Air:
                if (shieldedByEarth) {
                    damage = 0;
                }
                break;
            case BaseElement.ElementType.Earth:
                if (shieldedByAir) {
                    damage = 0;
                }
                break;
            case BaseElement.ElementType.Fire:
                if (shieldedByWater) {
                    damage = 0;
                }
                break;
            case BaseElement.ElementType.Water:
                if (shieldedByFire) {
                    damage = 0;
                }
                break;
            default:
                break;
        }
        hp -= damage;
    }

    // Use this for initialization
    void Start () {
        _shieldSpawner = gameObject.GetComponent<InteractableShield>();
        alive = true;
        hp = 100;
    }
    
    // Update is called once per frame
    void Update () {
        shieldedByAir = false;
        shieldedByEarth = false;
        shieldedByFire = false;
        shieldedByWater = false;

        if (_shieldSpawner.isShielded) {
            switch (_shieldSpawner.shieldElement.type) {
                case BaseElement.ElementType.Air:
                    shieldedByAir = true;
                    break;
                case BaseElement.ElementType.Earth:
                    shieldedByEarth = true;
                    break;
                case BaseElement.ElementType.Fire:
                    shieldedByFire = true;
                    break;
                case BaseElement.ElementType.Water:
                    shieldedByWater = true;
                    break;
                default:
                    break;
            }
        }

        if (hp <= 0) {
            alive = false;
        }
    }
}
