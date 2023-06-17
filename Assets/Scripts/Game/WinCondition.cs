using UnityEngine;

namespace Game
{
    public class WinCondition : MonoBehaviour
    {
        [SerializeField] 
        private GameFlow gameController;
        [SerializeField] 
        private AudioClip finishLevelClip;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag.Equals("Player"))
            {
                _audioSource.PlayOneShot(finishLevelClip);
                gameController.Win();
            }
        }
    }
}
