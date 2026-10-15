using UnityEngine;

public class ChaoFalsoFantasminha : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou no trigger é o jogador
        if (other.CompareTag("Player"))
        {
            // Opção A: Se o jogador usar CharacterController
            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null)
            {
                // Desativa temporariamente o CharacterController para ele cair livremente
                cc.enabled = false;
                // Reativa depois de um tempo ou deixe cair (pode reativar via outro script se preferir)
            }

            // Opção B: Se o jogador usar Rigidbody
            Rigidbody rbPlayer = other.GetComponent<Rigidbody>();
            if (rbPlayer != null)
            {
                // Garante que a gravidade está ativa para ele cair
                rbPlayer.useGravity = true;
                rbPlayer.isKinematic = false;
            }
        }
    }
}