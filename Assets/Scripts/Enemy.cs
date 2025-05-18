using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Vértices percorridos pelo inimigo
    [SerializeField] private Transform[] vertices;

    // Posições de origem e destino utilizadas na movimentação
    private Vector3 sourcePosition, destinationPosition;

    // Tempo de inicio e distância
    private float startTime, distance;

    // Índice do vértice
    private int verticesIndex = 0;

    void Start()
    {
        // Obtendo posições de inicio e destino
        sourcePosition = transform.position;
        destinationPosition = vertices[0].position;

        // Obtendo a distância e o tempo
        startTime = Time.time;
        distance = Vector3.Distance(sourcePosition, destinationPosition);
    }

    void Update()
    {
        // Calculando o intervalo de tempo e a velocidade
        float timeInterval = Time.time - startTime;
        float moveSpeed = (timeInterval / distance) * vertices.Length;

        // Realizando a movimentação
        this.transform.position = Vector3.Lerp(sourcePosition, destinationPosition, moveSpeed);

        // Ação a ser realizada quando chegar no destino
        if (Vector3.Distance(transform.position, destinationPosition) == 0)
        {
            // Incrementando indice
            verticesIndex++;
            verticesIndex = verticesIndex % vertices.Length;

            // Obtendo novas posições de origem e destino
            sourcePosition = destinationPosition;
            destinationPosition = vertices[verticesIndex].position;

            // Virando para a posição de destino
            transform.LookAt(destinationPosition);

            // Calculando a nova distância e tempo
            distance = Vector3.Distance(sourcePosition, destinationPosition);
            startTime = Time.time;
        }
    }
}
