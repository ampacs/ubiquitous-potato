using UnityEngine;

public class HazardCanon : BaseHazard {

    public GameObject bullet;

    public float bulletSpeed;
    public float bulletRate;

    public Vector3 bulletStartPosition;
    public Vector3 bulletShootDirection;

    GameObject _currentBullet;
    float _timeSinceLastBullet;

    void ShootBullet() {
        _currentBullet = (GameObject) Instantiate(bullet, transform.position + bulletStartPosition, transform.rotation);
        HazardBullet bulletHazard = _currentBullet.GetComponent<HazardBullet>();
        bulletHazard.directionOfMovement = bulletShootDirection;
        bulletHazard.speed = bulletSpeed;
        _timeSinceLastBullet = Time.time;
    }

    void FixedUpdate () {
        if (Time.time -_timeSinceLastBullet > 1f/bulletRate && _currentBullet == null) {
            ShootBullet();
        }
    }
}
