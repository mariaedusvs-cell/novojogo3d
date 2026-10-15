using UnityEngine;
using System.Collections;

public class ChaoFalso : MonoBehaviour
{
    public float tempoParaCair = 0.5f; // Tempo entre pisar e o chão cair
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica se o objeto que pisou é o jogador (adicione a tag "Player" ao seu jogador)
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(QuedaChao());
        }
    }

    IEnumerator QuedaChao()
    {
        yield return new WaitForSeconds(tempoParaCair);

        // Desativa o Kinematic para permitir que a física da gravidade atue
        rb.isKinematic = false;
        
        // Opcional: destruir o chão depois de alguns segundos para limpar a cena
        Destroy(gameObject, 5f);
    }
}