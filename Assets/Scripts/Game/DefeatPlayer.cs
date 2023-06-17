using UnityEngine;

namespace Game
{
    public class DefeatPlayer : MonoBehaviour
    {
        [SerializeField] 
        private GameFlow gameController;
    
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag.Equals("Player"))
            {
                gameController.Loose();
            }
        }
    }
}
