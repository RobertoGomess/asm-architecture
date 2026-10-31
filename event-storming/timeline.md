# Linha do Tempo

Sequência cronológica dos eventos de domínio.

1. `OSIniciada`
2. `ClienteIncluido` (somente se o cliente ainda não existir)
3. `VeiculoIncluido` (somente se o veículo ainda não existir)
4. `OSRecebida`
5. `DiagnosticoIniciado`
6. `ServicoIncluidoNaOS`
7. `InsumoIncluidoNaOS`
8. `InsumoReservado`
9. `DiagnosticoConcluido`
10. `OrcamentoGerado`
11. `EmailDeOrcamentoEnviado`
12. `OrcamentoAprovado`
    - Caminho alternativo (cliente rejeita):
      1. `OrcamentoRejeitado`
      2. `OSReprovada`
      3. `ReservaDeInsumoLiberada`
      4. segue para `ExecucaoFinalizada` (passo 17)
13. `BaixaDeInsumosRealizada`
14. `InsumosSeparados` (em paralelo à baixa)
15. `ExecucaoIniciada`
16. `EmailDeAcompanhamentoEnviado`
17. `ExecucaoFinalizada`
18. `EmailDeEntregaEnviado`
19. `VeiculoEntregue`

## Fora do fluxo principal da OS

Eventos que podem ocorrer a qualquer momento, independentemente de uma OS:

1. `InsumoAtualizado`
2. `ClienteAtualizado`
3. `VeiculoAtualizado`
4. `ListaDeServicosAtualizada`