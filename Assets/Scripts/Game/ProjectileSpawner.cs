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
    private float _timer = 0;

    private void Update()
    {
        if (_timer <= 0)
        {
            _timer = 4;
            var proj = Instantiate(projectile, transform);
            proj.GetComponent<Projectile>().SetGameController(gameFlow, direction);
            Destroy(proj, _timer);
        }
        _timer -= Time.deltaTime;
    }
}
