# Eventos de Domínio

Nomeie no passado (ex.: `PedidoCriado`).

| Evento | Descrição | Origem (comando) |
|--------|-----------|------------------|
| `OSIniciada` | Atendente abriu uma nova ordem de serviço. | Iniciar OS |
| `ClienteIncluido` | Novo cliente cadastrado (quando ainda não existia). | Incluir cliente |
| `VeiculoIncluido` | Novo veículo cadastrado e vinculado ao cliente (quando ainda não existia). | Incluir veículo |
| `OSRecebida` | OS registrada com cliente e veículo e liberada para diagnóstico. Evento pivotal. | Receber OS |
| `DiagnosticoIniciado` | Mecânico começou a avaliar o veículo. | Iniciar diagnóstico |
| `ServicoIncluidoNaOS` | Serviço da lista de serviços adicionado à OS. | Incluir serviço na OS |
| `InsumoIncluidoNaOS` | Insumo do estoque adicionado à OS. | Incluir insumo na OS |
| `InsumoReservado` | Quantidade disponível do insumo reservada para a OS. | Reservar insumo |
| `DiagnosticoConcluido` | Mecânico encerrou o diagnóstico com serviços e insumos definidos. Evento pivotal. | Concluir diagnóstico |
| `OrcamentoGerado` | Orçamento calculado a partir dos serviços e insumos da OS. | Gerar orçamento |
| `EmailDeOrcamentoEnviado` | Orçamento enviado ao cliente para aprovação pelo serviço de e-mail. | Enviar e-mail |
| `OrcamentoAprovado` | Cliente aprovou o orçamento. Evento pivotal. | Aprovar orçamento |
| `OrcamentoRejeitado` | Cliente rejeitou o orçamento. Evento pivotal (caminho alternativo). | Rejeitar orçamento |
| `OSReprovada` | OS encerrada por rejeição do orçamento. | Reprovada OS |
| `ReservaDeInsumoLiberada` | Reservas da OS reprovada devolvidas ao estoque disponível. | Liberar reserva |
| `BaixaDeInsumosRealizada` | Insumos reservados baixados do estoque após a aprovação. | Dar baixa nos insumos |
| `InsumosSeparados` | Estoquista separou fisicamente os insumos da OS. | Separar insumos |
| `ExecucaoIniciada` | Mecânico começou a executar os serviços. | Iniciar execução |
| `EmailDeAcompanhamentoEnviado` | Link de acompanhamento enviado ao cliente no início da execução. | Enviar e-mail |
| `ExecucaoFinalizada` | Serviços concluídos (ou OS reprovada encerrada). Evento pivotal. | Finalizar execução |
| `EmailDeEntregaEnviado` | Cliente avisado de que o veículo está pronto para retirada. | Enviar e-mail |
| `VeiculoEntregue` | Veículo devolvido ao cliente; fim do fluxo da OS. | Entregar veículo |
| `ClienteAtualizado` | Dados cadastrais do cliente alterados. | Atualizar cliente |
| `VeiculoAtualizado` | Dados cadastrais do veículo alterados. | Atualizar veículo |
| `ListaDeServicosAtualizada` | Serviço incluído, alterado ou desativado na lista de serviços. | Gerir serviços |
| `InsumoAtualizado` | Dados ou quantidade em estoque do insumo alterados. | Atualizar insumo |