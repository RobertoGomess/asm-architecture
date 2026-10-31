# Event Storming

**Sistema de gestão de oficina mecânica** · Domínio: Manutenção de veículos
Tech Challenge · Pós-graduação em Engenharia de Software (FIAP) · Fonte: board Miro · 31/10/2026

## Etapas

1. Eventos
2. Linha do tempo
3. Pontos de atenção
4. Eventos pivotais
5. Comandos e atores
6. Políticas
7. Modelos de leitura
8. Sistemas externos
9. Agregados

## Legenda

| Sigla | Significado |
|-------|-------------|
| EV | Evento de domínio |
| CMD | Comando |
| AT | Ator |
| POL | Política |
| ML | Modelo de leitura |
| SE | Sistema externo |
| PA | Ponto de atenção |
| AG | Agregado |

---

## Etapa 1 — Eventos

Brainstorm dos 25 eventos de domínio, ainda sem ordem cronológica.

- OS iniciada
- Cliente incluído
- Veículo incluído
- OS recebida
- Diagnóstico iniciado
- Serviço incluído na OS
- Insumo incluído na OS
- Insumo reservado
- Diagnóstico concluído
- Orçamento gerado
- E-mail de orçamento enviado
- Orçamento aprovado
- Orçamento rejeitado
- OS reprovada
- Reserva de insumo liberada
- Baixa de insumos realizada
- Insumos separados
- Execução iniciada
- Execução finalizada
- E-mail de entrega enviado
- Veículo entregue
- Cliente atualizado
- Veículo atualizado
- Lista de Serviços atualizada
- Insumo atualizado

---

## Etapa 2 — Linha do tempo

Eventos em ordem cronológica.

### Fluxo principal

1. OS iniciada
2. Cliente incluído — *cadastra novo*
3. Veículo incluído — *cadastra novo*
4. OS recebida
5. Diagnóstico iniciado
6. Serviço incluído na OS
7. Insumo incluído na OS
8. Insumo reservado
9. Diagnóstico concluído
10. Orçamento gerado
11. E-mail de orçamento enviado
12. Orçamento aprovado
13. Baixa de insumos realizada
14. Insumos separados — *em paralelo à baixa; libera o início da execução*
15. Execução iniciada
16. E-mail de entrega enviado — *link de acompanhamento enviado ao cliente quando a execução é iniciada*
17. Execução finalizada
18. E-mail de entrega enviado
19. Veículo entregue

### Fluxo alternativo (cliente rejeita o orçamento)

1. E-mail de orçamento enviado
2. Orçamento rejeitado — *cliente rejeita*
3. OS reprovada
4. Reserva de insumo liberada
5. Execução finalizada (retoma o fluxo principal para devolução do veículo)

### Fora do fluxo principal da OS

- Insumo atualizado
- Cliente atualizado
- Veículo atualizado
- Lista de Serviços atualizada

---

## Etapa 3 — Pontos de atenção

| Ponto de atenção | Evento relacionado |
|------------------|--------------------|
| Status extras justificados | Orçamento rejeitado |

---

## Etapa 4 — Eventos pivotais

Eventos que marcam a mudança de fase do ciclo da OS.

| Fase | Eventos da fase | Evento pivotal (fim da fase) |
|------|-----------------|------------------------------|
| Atendimento | OS iniciada, Cliente incluído, Veículo incluído, OS recebida | **OS recebida** |
| Diagnóstico | Diagnóstico iniciado, Serviço incluído na OS, Insumo incluído na OS, Insumo reservado, Diagnóstico concluído | **Diagnóstico concluído** |
| Orçamento | Orçamento gerado, E-mail de orçamento enviado, Orçamento aprovado / Orçamento rejeitado | **Orçamento aprovado** / **Orçamento rejeitado** |
| Execução | Baixa de insumos realizada, Insumos separados, Execução iniciada, E-mail de entrega enviado, Execução finalizada · (alternativo: OS reprovada, Reserva de insumo liberada) | **Execução finalizada** |
| Entrega | E-mail de entrega enviado, Veículo entregue | — |

---

## Etapa 5 — Comandos e atores

Comando que dispara cada evento e o ator que o executa. Comandos sem ator são disparados por política.

| Fase | Comando | Ator | Evento |
|------|---------|------|--------|
| Atendimento | Iniciar OS | Atendente | OS iniciada |
| Atendimento | Incluir cliente | Atendente | Cliente incluído |
| Atendimento | Incluir veículo | Atendente | Veículo incluído |
| Atendimento | Receber OS | Atendente | OS recebida |
| Diagnóstico | Iniciar diagnóstico | Mecânico | Diagnóstico iniciado |
| Diagnóstico | Incluir serviço na OS | Mecânico | Serviço incluído na OS |
| Diagnóstico | Incluir insumo na OS | Mecânico | Insumo incluído na OS |
| Diagnóstico | Reservar insumo | — (política) | Insumo reservado |
| Diagnóstico | Concluir diagnóstico | Mecânico | Diagnóstico concluído |
| Orçamento | Gerar orçamento | — (política) | Orçamento gerado |
| Orçamento | Enviar e-mail | — (política) | E-mail de orçamento enviado |
| Orçamento | Aprovar orçamento | Cliente | Orçamento aprovado |
| Orçamento | Rejeitar orçamento | Cliente | Orçamento rejeitado |
| Orçamento | Reprovada OS | — (política) | OS reprovada |
| Execução | Liberar reserva | — (política) | Reserva de insumo liberada |
| Execução | Dar baixa nos insumos | — (política) | Baixa de insumos realizada |
| Execução | Separar insumos | Estoquista | Insumos separados |
| Execução | Iniciar execução | Mecânico | Execução iniciada |
| Execução | Enviar e-mail | — (política) | E-mail de entrega enviado |
| Execução | Finalizar execução | Mecânico | Execução finalizada |
| Entrega | Enviar e-mail | — (política) | E-mail de entrega enviado |
| Entrega | Entregar veículo | Atendente | Veículo entregue |
| Fora do fluxo | Atualizar cliente | Atendente | Cliente atualizado |
| Fora do fluxo | Atualizar veículo | Atendente | Veículo atualizado |
| Fora do fluxo | Gerir serviços | Atendente, Mecânico | Lista de Serviços atualizada |
| Fora do fluxo | Atualizar insumo | Estoquista | Insumo atualizado |

---

## Etapa 6 — Políticas

Reações automáticas: quando um evento acontece, a política dispara o próximo comando.

| Quando (evento) | Política | Então (comando) |
|-----------------|----------|-----------------|
| Insumo incluído na OS | Reservar o disponível | Reservar insumo |
| Diagnóstico concluído | Orçar ao concluir o diagnóstico | Gerar orçamento |
| Orçamento gerado | Notificar o cliente | Enviar e-mail |
| Orçamento aprovado | Baixar insumos reservados | Dar baixa nos insumos |
| Orçamento rejeitado | Encerrar OS rejeitada | Reprovada OS |
| OS reprovada | Devolver reservas da OS encerrada | Liberar reserva |
| Execução iniciada | Notificar o cliente | Enviar e-mail |
| Execução finalizada | Notificar o cliente | Enviar e-mail |

---

## Etapa 7 — Modelos de leitura

Informações que o ator consulta para decidir antes de executar o comando.

| Modelo de leitura | Comando | Ator |
|-------------------|---------|------|
| Consulta de cliente (CPF/CNPJ) | Incluir cliente · Atualizar cliente | Atendente |
| Consulta de veículos (Placa \| CPF/CNPJ) | Incluir veículo · Atualizar veículo | Atendente |
| Listagem de OS | Iniciar diagnóstico · Iniciar execução | Mecânico |
| Listagem de OS | Entregar veículo | Atendente |
| Lista de Serviços | Incluir serviço na OS | Mecânico |
| Estoque de insumos | Incluir insumo na OS | Mecânico |
| Detalhamento da OS | Concluir diagnóstico · Finalizar execução | Mecânico |
| E-mail de orçamento | Aprovar orçamento · Rejeitar orçamento | Cliente |
| Insumos a separar | Separar insumos | Estoquista |
| Consulta de insumos (Nome \| Código) | Atualizar insumo | Estoquista |
| Consulta de Lista de Serviços (Nome \| Código) | Gerir serviços | Atendente, Mecânico |

---

## Etapa 8 — Sistemas externos

Integração com o **Serviço de e-mail** para notificar o cliente.

| Comando | Sistema externo | Evento |
|---------|-----------------|--------|
| Enviar e-mail (orçamento gerado) | Serviço de e-mail | E-mail de orçamento enviado |
| Enviar e-mail (execução iniciada) | Serviço de e-mail | E-mail de entrega enviado (link de acompanhamento) |
| Enviar e-mail (execução finalizada) | Serviço de e-mail | E-mail de entrega enviado |

---

## Etapa 9 — Agregados

Comandos e eventos agrupados pelo agregado responsável. Políticas ligam eventos da OS a comandos do Insumo.

### AG · Cliente

| Comando | Evento |
|---------|--------|
| Incluir cliente | Cliente incluído |
| Atualizar cliente | Cliente atualizado |

### AG · Veículo

| Comando | Evento |
|---------|--------|
| Incluir veículo | Veículo incluído |
| Atualizar veículo | Veículo atualizado |

### AG · Serviço (Lista de Serviços)

| Comando | Evento |
|---------|--------|
| Gerir serviços | Lista de Serviços atualizada |

### AG · Ordem de Serviço (+ Orçamento)

| Comando | Evento |
|---------|--------|
| Iniciar OS | OS iniciada |
| Receber OS | OS recebida |
| Iniciar diagnóstico | Diagnóstico iniciado |
| Incluir serviço na OS | Serviço incluído na OS |
| Incluir insumo na OS | Insumo incluído na OS |
| Concluir diagnóstico | Diagnóstico concluído |
| Gerar orçamento | Orçamento gerado |
| Enviar e-mail | E-mail de orçamento enviado |
| Aprovar orçamento | Orçamento aprovado |
| Rejeitar orçamento | Orçamento rejeitado |
| Reprovada OS | OS reprovada |
| Iniciar execução | Execução iniciada |
| Enviar e-mail | E-mail de entrega enviado |
| Finalizar execução | Execução finalizada |
| Enviar e-mail | E-mail de entrega enviado |
| Entregar veículo | Veículo entregue |

### AG · Insumo

| Comando | Evento |
|---------|--------|
| Reservar insumo | Insumo reservado |
| Dar baixa nos insumos | Baixa de insumos realizada |
| Liberar reserva | Reserva de insumo liberada |
| Separar insumos | Insumos separados |
| Atualizar insumo | Insumo atualizado |

### Políticas entre agregados

| Evento (Ordem de Serviço) | Política | Comando (Insumo) |
|---------------------------|----------|------------------|
| Insumo incluído na OS | Reservar o disponível | Reservar insumo |
| Orçamento aprovado | Baixar insumos reservados | Dar baixa nos insumos |
| OS reprovada | Devolver reservas da OS encerrada | Liberar reserva |