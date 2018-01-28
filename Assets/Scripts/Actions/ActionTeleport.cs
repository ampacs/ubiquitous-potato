using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TELEPORT_EXIT_DRECTION
{
    North,
    South,
    East,
    West
}

public static class teleport_exit_directionExtensions
{
    public static Vector3 UnitVector(this TELEPORT_EXIT_DRECTION self)
    {
        // Replace this with a dictionary or whatever you want ... you get the idea
        switch (self)
        {
            case TELEPORT_EXIT_DRECTION.North:
                return new Vector3(0, 0, 1.5f);
            case TELEPORT_EXIT_DRECTION.South:
                return new Vector3(0, 0, -1.5f);
            case TELEPORT_EXIT_DRECTION.East:
                return new Vector3(1.5f, 0, 0);
            case TELEPORT_EXIT_DRECTION.West:
                return new Vector3(-1.5f, 0, 0);
            default:
                return new Vector3(-0, 0, 0);
        }
    }
}



public class ActionTeleport : MonoBehaviour {

    public Transform sideA;
    public Transform sideB;

    public string teleportSound;

    //private bool jetlag;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioManager.instance.Play(teleportSound);
            if (this.transform == sideA)
                other.transform.position = sideB.position + TELEPORT_EXIT_DRECTION.West.UnitVector();
            else
                other.transform.position = sideA.position + TELEPORT_EXIT_DRECTION.East.UnitVector();          
        }
    }
}
