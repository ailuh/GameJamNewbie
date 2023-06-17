    using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField] 
        private Sprite sprite; 
        [SerializeField] 
        private GameObject projectile; 
        [SerializeField] 
        private GameFlow gameFlow;
        [SerializeField] 
        private Vector3 direction;
        [SerializeField] 
        private float projectileLiveTime;
        private float _timer;
        private bool _isStarted;

        private void Start()
        {
            StartCoroutine(RandomStart());
        }

        private void Update()
        {
            if (_timer <= 0 && _isStarted)
            {
                _timer = projectileLiveTime;
                var proj = Instantiate(projectile, transform);
                proj.GetComponent<Projectile>().SetGameController(gameFlow, direction, sprite);
                Destroy(proj, _timer);
            }
            _timer -= Time.deltaTime;
        }

        private IEnumerator RandomStart()
        {
            var randSec = Random.Range(0.5f, 2);
            yield return new WaitForSeconds(randSec);
            _isStarted = true;
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}
