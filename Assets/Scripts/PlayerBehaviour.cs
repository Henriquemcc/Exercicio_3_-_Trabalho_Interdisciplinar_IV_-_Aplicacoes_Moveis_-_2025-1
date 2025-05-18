using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBehaviour : MonoBehaviour
{
    [Header("Propriedades de Movimentação")]

    // Velocidade de Movimentação
    [SerializeField] private float moveSpeed = 5;

    // Componente responsável por simular a gravidade e realizar movimentação do player
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Obtendo movimentação da entrada
        float moveX = Input.GetAxis("Vertical");
        float moveZ = Input.GetAxis("Horizontal");

        // Aplicando movimento ao player
        Vector3 movement = new Vector3(moveX, 0f, moveZ) * moveSpeed;
        _rigidbody.linearVelocity = new Vector3(movement.x, _rigidbody.linearVelocity.y, movement.z);
    }
}
