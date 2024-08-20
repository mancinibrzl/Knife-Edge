using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Header("Rota��o do Alvo")]
    [SerializeField] private int[] velocidadesDeRotacao;
    private int velocidadeDeRotacaoAtual;

    [Header("Cron�metro da Troca de Velocidade")]
    [SerializeField] private float tempoMaximoParaTrocarVelocidade = 2f;
    private float tempoAtualParaTrocarVelocidade;

    private void Update()
    {
        RodarCronometroDaTrocaDeVelocidade();
        RotacionarAlvo();
    }

    private void RodarCronometroDaTrocaDeVelocidade()
    {
        tempoAtualParaTrocarVelocidade -= Time.deltaTime;
        if (tempoAtualParaTrocarVelocidade <= 0)
        {
            EscolherNovaVelocidadeDeRotacao();
            tempoAtualParaTrocarVelocidade = tempoMaximoParaTrocarVelocidade;
        }
    }

    private void EscolherNovaVelocidadeDeRotacao()
    {
        velocidadeDeRotacaoAtual = velocidadesDeRotacao[Random.Range(0, velocidadesDeRotacao.Length)];
    }

    private void RotacionarAlvo()
    {
        transform.Rotate(0f, 0f, velocidadeDeRotacaoAtual * Time.deltaTime);
    }
}
