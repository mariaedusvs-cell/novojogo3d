using UnityEngine;
using System.Collections;

public class PlataformaQuedaTempo : MonoBehaviour
{
    [Header("Configurações de Tempo")]
    [SerializeField] private float tempoParaCair = 1.5f; // Tempo que o jogador pode ficar em cima antes de cair
    
    [Header("Configuração de Queda")]
    [SerializeField] private bool destruirAposCair = true;
    [SerializeField] private float tempoAteDestruir = 3f;

    private bool jogadorEmCima = false;
    private float cronometro = 0f;
    private Rigidbody rb;
    private bool jaCaiu = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Garante que a plataforma começa travada se tiver Rigidbody
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    private void Update()
    {
        // Se o jogador estiver em cima e a plataforma ainda não caiu
        if (jogadorEmCima && !jaCaiu)
        {
            cronometro += Time.deltaTime;

            // Se o tempo esgotar, faz a plataforma cair
            if (cronometro >= tempoParaCair)
            {
                Cair();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jogadorEmCima = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jogadorEmCima = false;
            
            // Opcional: Se quiser que o cronômetro reinicie caso o jogador saia antes de cair:
            // cronometro = 0f; 
        }
    }

    private void Cair()
    {
        jaCaiu = true;

        if (rb != null)
        {
            // Libera a física para a plataforma cair com a gravidade
            rb.isKinematic = false;
            rb.useGravity = true;
        }
        else
        {
            // Caso não queira usar Rigidbody, você pode fazer ela descer por código (Translate)
            // Ou adicionar um Rigidbody dinamicamente via código:
            Rigidbody novoRb = gameObject.AddComponent<Rigidbody>();
            novoRb.useGravity = true;
        }

        // Destroi a plataforma após cair para não acumular lixo na cena
        if (destruirAposCair)
        {
            Destroy(gameObject, tempoAteDestruir);
        }
    }
}