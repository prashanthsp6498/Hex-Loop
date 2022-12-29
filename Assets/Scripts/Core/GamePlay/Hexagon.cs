using UnityEngine;
using HexLoop.Core.ScoreSystem;
using HexLoop.Core.ManagerUtil;

namespace HexLoop.Core.GamePlay
{
    public class Hexagon : MonoBehaviour
    {
        [SerializeField] private float speed = 4f;
        [SerializeField] private Rigidbody2D rb;

        private void Start()
        {
            rb.rotation = Random.Range(0f, 360f);
            transform.localScale = Vector3.one * 10f;
        }

        private void Update()
        {
            transform.localScale -= Vector3.one * (speed * Time.deltaTime);    
            if (transform.localScale.x < 0.5f)
            {
                GameFactory.Get<ScoreModel>().IncrementScore();
                GameFactory.Get<Spawner>().AddToPool(gameObject);
            }
        }
    }
}
