
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    
    [SerializeField] ScoreKeeper scoreKeeper;
    [SerializeField] private CameraShake cameraShake;

    [SerializeField] private int health = 50;
    [SerializeField] private int score = 50;

    [SerializeField] private bool canShakeCamera;
    [SerializeField] private bool isPlayer;


    private void Awake()
   {
      cameraShake = Camera.main.GetComponent<CameraShake>();
      scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

   private void OnTriggerEnter2D(Collider2D other)
   {
      Damage _damage = other.GetComponent<Damage>();

      if (_damage != null)
      {
        TakeDamage(_damage.GetDamage());
        ShakeCamera();
        _damage.Hit();
      }
   }

   void TakeDamage(int damage)
   {
      health -= damage;
      if (health<=0)
      {
            Die();
      }
   }

   void ShakeCamera()
   {
      if (cameraShake != null && canShakeCamera)
      {
         cameraShake.Play();
      }
   }

    public int GetHealth()
    {
        return health;
    }

    void Die()
    {
        if(!isPlayer)
        {
            scoreKeeper.GetNewScore(score);
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
        Destroy(gameObject);
    }
}
