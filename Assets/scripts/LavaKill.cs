using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaKill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CheckAndReset(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CheckAndReset(collision.gameObject);
    }

    private void CheckAndReset(GameObject obj)
    {
        if (obj.CompareTag("Player"))
        {
            // Recarrega a cena atual
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}