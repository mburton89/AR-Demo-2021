using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform sphere;
    public Transform spawnPoint;
    public float shootForce;

    public void SetYRotation(float yRot)
    {
        sphere.eulerAngles = new Vector3(0, yRot, sphere.eulerAngles.z);
    }

    public void SetZRotation(float zRot)
    {
        sphere.eulerAngles = new Vector3(0, sphere.eulerAngles.y, zRot);
    }

    public void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shootForce, ForceMode.Impulse);
    }
}
