# Políticas

Regras do tipo "Quando `<evento>` então `<comando>`".

| Quando (evento) | Então (comando) | Observações |
|-----------------|-----------------|-------------|
| `InsumoIncluidoNaOS` | Reservar insumo | **Reservar o disponível**: reserva no estoque a quantidade disponível do insumo. |
| `DiagnosticoConcluido` | Gerar orçamento | **Orçar ao concluir o diagnóstico**: orçamento calculado com base nos serviços e insumos da OS. |
| `OrcamentoGerado` | Enviar e-mail | **Notificar o cliente**: envia o orçamento para aprovação pelo serviço de e-mail (sistema externo). |
| `OrcamentoAprovado` | Dar baixa nos insumos | **Baixar insumos reservados**: em paralelo, o Estoquista separa os insumos; a execução só inicia após `InsumosSeparados`. |
| `OrcamentoRejeitado` | Reprovada OS | **Encerrar OS rejeitada**: ponto de atenção "Status extras justificados". Após `OSReprovada`, o fluxo segue para Finalizar execução. |
| `OSReprovada` | Liberar reserva | **Devolver reservas da OS encerrada**: insumos reservados voltam ao estoque disponível. |
| `ExecucaoIniciada` | Enviar e-mail | **Notificar o cliente**: envia o link de acompanhamento da OS. |
| `ExecucaoFinalizada` | Enviar e-mail | **Notificar o cliente**: avisa que o veículo está pronto para entrega. |