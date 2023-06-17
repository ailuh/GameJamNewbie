using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 _position;
    private GameFlow _gameController;
    
    public void SetGameController(GameFlow gameFlow, Vector3 direction)
    {
        _gameController = gameFlow;
        _position = direction;

    }
    
    void Update()
    {
        transform.position += _position;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            _gameController.Loose();
        }
    }
}
