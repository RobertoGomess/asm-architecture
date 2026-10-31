# Comandos

| Comando | Ator | Agregado | Evento resultante |
|---------|------|----------|-------------------|
| Iniciar OS | Atendente | Ordem de Serviço | OS iniciada |
| Incluir cliente | Atendente | Cliente | Cliente incluído |
| Incluir veículo | Atendente | Veículo | Veículo incluído |
| Receber OS | Atendente | Ordem de Serviço | OS recebida |
| Iniciar diagnóstico | Mecânico | Ordem de Serviço | Diagnóstico iniciado |
| Incluir serviço na OS | Mecânico | Ordem de Serviço | Serviço incluído na OS |
| Incluir insumo na OS | Mecânico | Ordem de Serviço | Insumo incluído na OS |
| Reservar insumo | Política: Reservar o disponível | Insumo | Insumo reservado |
| Concluir diagnóstico | Mecânico | Ordem de Serviço | Diagnóstico concluído |
| Gerar orçamento | Política: Orçar ao concluir o diagnóstico | Ordem de Serviço (+ Orçamento) | Orçamento gerado |
| Enviar e-mail | Política: Notificar o cliente | Ordem de Serviço | E-mail de orçamento enviado |
| Aprovar orçamento | Cliente | Ordem de Serviço | Orçamento aprovado |
| Rejeitar orçamento | Cliente | Ordem de Serviço | Orçamento rejeitado |
| Reprovada OS | Política: Encerrar OS rejeitada | Ordem de Serviço | OS reprovada |
| Liberar reserva | Política: Devolver reservas da OS encerrada | Insumo | Reserva de insumo liberada |
| Dar baixa nos insumos | Política: Baixar insumos reservados | Insumo | Baixa de insumos realizada |
| Separar insumos | Estoquista | Insumo | Insumos separados |
| Iniciar execução | Mecânico | Ordem de Serviço | Execução iniciada |
| Enviar e-mail | Política: Notificar o cliente | Ordem de Serviço | E-mail de entrega enviado (link de acompanhamento) |
| Finalizar execução | Mecânico | Ordem de Serviço | Execução finalizada |
| Enviar e-mail | Política: Notificar o cliente | Ordem de Serviço | E-mail de entrega enviado |
| Entregar veículo | Atendente | Ordem de Serviço | Veículo entregue |
| Atualizar cliente | Atendente | Cliente | Cliente atualizado |
| Atualizar veículo | Atendente | Veículo | Veículo atualizado |
| Gerir serviços | Atendente, Mecânico | Serviço (Lista de Serviços) | Lista de Serviços atualizada |
| Atualizar insumo | Estoquista | Insumo | Insumo atualizado |