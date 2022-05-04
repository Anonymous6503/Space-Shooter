using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileLifeTime = 5f;
    [SerializeField] private float baseFiringRate = 0.3f;
    [Header("isEnemy")]
    [SerializeField] private bool isEnemy;
    [SerializeField] private float firingRateVariance = 0f;
    [SerializeField] private float minimumFiringRate = 0.1f;
    [HideInInspector]public bool isFiring;

    private Coroutine firingCoroutine;
    void Start()
    {
        if (isEnemy)
        {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinously());
        }
        else if(!isFiring && firingCoroutine !=null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
        
    }

    private IEnumerator FireContinously()
    {
        while (true)
        {
            GameObject fireInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = fireInstance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            
            Destroy(fireInstance, projectileLifeTime);
            float firingRate = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
            firingRate = Mathf.Clamp(firingRate, minimumFiringRate, float.MaxValue);
            yield return new WaitForSeconds(firingRate);
        }
    }
}
