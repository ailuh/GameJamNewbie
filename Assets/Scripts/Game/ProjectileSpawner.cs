using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject projectile; 
    [SerializeField] 
    private GameFlow gameFlow;
    [SerializeField] 
    private Vector3 direction;
    [SerializeField] 
    private float projectileLiveTime;
    private float _timer;

    private void Update()
    {
        if (_timer <= 0)
        {
            _timer = projectileLiveTime;
            var proj = Instantiate(projectile, transform);
            proj.GetComponent<Projectile>().SetGameController(gameFlow, direction);
            Destroy(proj, _timer);
        }
        _timer -= Time.deltaTime;
    }
}
