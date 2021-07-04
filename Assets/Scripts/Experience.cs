using UnityEngine;

public class Experience : MonoBehaviour
{
    [SerializeField] private int amount = 20;
    [SerializeField] ParticleSystem gainedParticle;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            UIManager.Instance.IncreaseExperience(amount);
            Instantiate(gainedParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }    
    }
}
