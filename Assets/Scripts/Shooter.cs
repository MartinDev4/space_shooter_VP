using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 12f;
    [SerializeField] private float projectileLifetime = 6f;
    [SerializeField] private float fireRate = .25f;

    public bool isShooting;
    private Coroutine _shootingCoroutine;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        Fire();
    }

    private void Fire() {
        if (isShooting && _shootingCoroutine == null) {
            _shootingCoroutine = StartCoroutine(FireContinously());
        } else if(!isShooting && _shootingCoroutine != null) {
            StopCoroutine(_shootingCoroutine);
            _shootingCoroutine = null;
        }
    }

    private IEnumerator FireContinously() {
        while (true) {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null) {
                rb.velocity = transform.up * projectileSpeed;
            }
            
            Destroy(instance, projectileLifetime);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
