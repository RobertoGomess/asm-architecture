# Linguagem Ubíqua — Sistema de gestão de oficina mecânica

> Tech Challenge · Pós-graduação em Engenharia de Software (FIAP)
> Fonte: board Miro do Event Storming · gerado em 23/10/2026

Este documento reúne os termos que o time usa ao falar do domínio. Os mesmos nomes devem aparecer no código (classes, métodos, eventos, endpoints), nas conversas e na documentação.

## Domínio e subdomínios

**Domínio:** Manutenção de veículos

| Tipo | Subdomínio | Contexto delimitado |
|---|---|---|
| Principal | Gestão de Serviços Mecânicos — ciclo completo da OS, do atendimento à entrega | Ordem de Serviço |
| Suporte | Gestão de Estoque | Estoque |
| Suporte | Gestão de Clientes | Cadastros |
| Suporte | Gestão de Veículos | Cadastros |
| Suporte | Lista de Serviços | Cadastros |
| Genérico | Controle de Acesso | Controle de Acesso |
| Genérico | Notificação | Serviço de e-mail (externo) |

## Contextos delimitados

| Contexto | Responsabilidade | Principais entidades e objetos de valor |
|---|---|---|
| **Ordem de Serviço** | Ciclo de status da OS, orçamento e acompanhamento | OrdemDeServico (raiz), Orcamento · ServicoDaOS, InsumoDaOS, StatusOS, HistoricoDeStatus, PeriodoDeExecucao |
| **Cadastros** | Dados de referência mantidos por CRUD | Cliente, Veiculo, Servico · Documento (CPF ou CNPJ), Email, Telefone, Placa, Dinheiro |
| **Estoque** | Quantidades, reservas, baixas e separação de insumos | Insumo · QuantidadeEmEstoque (total e reservada), Reserva, Dinheiro |
| **Controle de Acesso** | Autenticação JWT nas APIs administrativas e perfis de acesso | Usuário · Perfil (Atendente, Mecânico e Estoquista), Credencial |

## Glossário

### Todos os contextos

| Termo | Definição |
|---|---|
| Oficina | Oficina mecânica de médio porte, especializada em manutenção de veículos |
| Notificação | Subdomínio genérico de envio de mensagens ao cliente |

### Ordem de Serviço

| Termo | Definição |
|---|---|
| Gestão de Serviços Mecânicos | Subdomínio principal que cobre todo o ciclo da Ordem de Serviço, do atendimento à entrega. Não confundir com a Lista de Serviços nem com a fase Execução |
| Ordem de Serviço (OS) | Registro do atendimento de um veículo, da abertura até a entrega |
| Status da OS | Fase atual da OS; são 8 status |
| Diagnóstico | Avaliação do veículo pelo Mecânico, que define serviços e insumos. Quando ele termina, o orçamento é gerado |
| Orçamento | Soma do preço de cada serviço incluído com o preço unitário x quantidade de cada insumo incluído, gerado automaticamente |
| Aprovar / Rejeitar | Decisão do cliente sobre o orçamento, registrada pelo link do e-mail |
| Separação | Preparo físico dos insumos da OS pelo Estoquista |
| Execução | Realização dos serviços pelo Mecânico, do início à finalização |
| Tempo de execução | Intervalo entre o início e a finalização da execução pelo Mecânico; a média considera só OS executadas |
| Entrega | Saída do veículo com o serviço executado; leva ao status Entregue |
| Devolução | Saída do veículo após orçamento rejeitado; também leva ao status Entregue |

### Cadastros

| Termo | Definição |
|---|---|
| Cliente | Dono do veículo, identificado por CPF ou CNPJ; acompanha a OS e aprova ou rejeita o orçamento |
| Veículo | Bem do cliente, identificado pela placa; tem marca, modelo e ano |
| Placa | Identificador do veículo; precisa ser validada |
| CPF / CNPJ | Documento que identifica o cliente; precisa ser validado |
| Serviço | Item da Lista de Serviços (ex.: troca de óleo) com preço. É o mesmo conceito quando incluído numa OS: a OS referencia serviços da Lista de Serviços |
| Lista de Serviços | Conjunto dos serviços oferecidos, mantido por Atendente e Mecânico |

### Estoque

| Termo | Definição |
|---|---|
| Insumo | Item de estoque usado no serviço, com preço unitário. É o termo oficial; peça é sinônimo aceito |
| Estoque | Quantidade de cada insumo na oficina, dividida em disponível e reservada |
| Entrada no estoque | Registro, pelo Estoquista, de novas unidades de um insumo |
| Reserva | Bloqueio da quantidade de um insumo quando ele é incluído numa OS |
| Liberação da reserva | Devolução da quantidade reservada ao estoque disponível, na rejeição ou no ajuste |
| Baixa | Saída definitiva do insumo do estoque, quando o cliente aprova o orçamento |

### Controle de Acesso

| Termo | Definição |
|---|---|
| Atendente | Recebe o cliente, abre a OS, mantém clientes, veículos e serviços e registra entrega ou devolução |
| Mecânico | Diagnostica, inclui serviços e insumos, ajusta o orçamento, inicia e finaliza a execução; mantém serviços |
| Estoquista | Cadastra insumos, dá entrada no estoque e separa insumos para a OS |
| Controle de Acesso | Subdomínio e contexto genérico de autenticação JWT e perfis |

## Fases da OS (eventos pivotais)

Atendimento → Diagnóstico → Orçamento → Execução → Entrega

## Comandos e eventos

Comandos sem ator são disparados por uma política.

| Fase | Comando | Ator | Evento | Agregado |
|---|---|---|---|---|
| Atendimento | Iniciar OS | Atendente | OS iniciada | Ordem de Serviço |
| Atendimento | Incluir cliente | Atendente | Cliente incluído | Cliente |
| Atendimento | Incluir veículo | Atendente | Veículo incluído | Veículo |
| Atendimento | Receber OS | Atendente | OS recebida | Ordem de Serviço |
| Diagnóstico | Iniciar diagnóstico | Mecânico | Diagnóstico iniciado | Ordem de Serviço |
| Diagnóstico | Incluir serviço na OS | Mecânico | Serviço incluído na OS | Ordem de Serviço |
| Diagnóstico | Incluir insumo na OS | Mecânico | Insumo incluído na OS | Ordem de Serviço |
| Diagnóstico | Reservar insumo | — | Insumo reservado | Insumo |
| Diagnóstico | Concluir diagnóstico | Mecânico | Diagnóstico concluído | Ordem de Serviço |
| Orçamento | Gerar orçamento | — | Orçamento gerado | Ordem de Serviço |
| Orçamento | Enviar e-mail | — | E-mail de orçamento enviado | Ordem de Serviço |
| Orçamento | Aprovar orçamento | Cliente | Orçamento aprovado | Ordem de Serviço |
| Orçamento | Rejeitar orçamento | Cliente | Orçamento rejeitado | Ordem de Serviço |
| Execução | Reprovada OS | — | OS reprovada | Ordem de Serviço |
| Execução | Liberar reserva | — | Reserva de insumo liberada | Insumo |
| Execução | Dar baixa nos insumos | — | Baixa de insumos realizada | Insumo |
| Execução | Separar insumos | Estoquista | Insumos separados | Insumo |
| Execução | Iniciar execução | Mecânico | Execução iniciada | Ordem de Serviço |
| Execução | Enviar e-mail | — | E-mail de entrega enviado | Ordem de Serviço |
| Execução | Finalizar execução | Mecânico | Execução finalizada | Ordem de Serviço |
| Entrega | Enviar e-mail | — | E-mail de entrega enviado | Ordem de Serviço |
| Entrega | Entregar veículo | Atendente | Veículo entregue | Ordem de Serviço |
| Fora do fluxo da OS | Atualizar cliente | Atendente | Cliente atualizado | Cliente |
| Fora do fluxo da OS | Atualizar veículo | Atendente | Veículo atualizado | Veículo |
| Fora do fluxo da OS | Gerir serviços | Atendente, Mecânico | Lista de Serviços atualizada | Serviço |
| Fora do fluxo da OS | Atualizar insumo | Estoquista | Insumo atualizado | Insumo |

## Políticas

| Quando acontece | Política | Então dispara |
|---|---|---|
| Insumo incluído na OS | Reservar o disponível | Reservar insumo |
| Diagnóstico concluído | Orçar ao concluir o diagnóstico | Gerar orçamento |
| Orçamento gerado | Notificar o cliente | Enviar e-mail (orçamento) |
| Orçamento aprovado | Baixar insumos reservados | Dar baixa nos insumos |
| Orçamento rejeitado | Encerrar OS rejeitada | Reprovada OS |
| OS reprovada | Devolver reservas da OS encerrada | Liberar reserva |
| Execução iniciada | Notificar o cliente | Enviar e-mail |
| Execução finalizada | Notificar o cliente | Enviar e-mail |

## Modelos de leitura

| Modelo de leitura | Usado antes de |
|---|---|
| Consulta de cliente (CPF/CNPJ) | Incluir cliente, Atualizar cliente |
| Consulta de veículos (Placa \| CPF/CNPJ) | Incluir veículo, Atualizar veículo |
| Listagem de OS | Iniciar diagnóstico, Iniciar execução, Entregar veículo |
| Lista de Serviços | Incluir serviço na OS |
| Estoque de insumos | Incluir insumo na OS |
| Detalhamento da OS | Concluir diagnóstico, Finalizar execução |
| E-mail de orçamento | Aprovar orçamento, Rejeitar orçamento |
| Insumos a separar | Separar insumos |
| Consulta de Lista de Serviços (Nome \| Código) | Gerir serviços |
| Consulta de insumos (Nome \| Código) | Atualizar insumo |

## Sistemas externos

| Sistema | Uso |
|---|---|
| Serviço de e-mail | Envia ao cliente o e-mail de orçamento e os e-mails de início e fim da execução. Integrado ao contexto Ordem de Serviço por uma camada anticorrupção (ACL) |

## Pontos de atenção

| Ponto | Onde |
|---|---|
| Status extras justificados | Orçamento rejeitado |

## Termos a confirmar

Alguns termos do glossário descrevem ações que ainda não aparecem no fluxo do Event Storming:

- **Devolução** e "registra entrega ou devolução" (Atendente): no fluxo, a OS reprovada segue para Finalizar execução e Entregar veículo; não há o comando "Devolver veículo".
- "Ajusta o orçamento" (Mecânico) e liberação da reserva "no ajuste": não há comando de ajuste do orçamento.
- **Separação** está no contexto Ordem de Serviço no glossário, mas o comando Separar insumos pertence ao agregado Insumo (contexto Estoque).
- **Entrada no estoque** e "Cadastra insumos, dá entrada no estoque" (Estoquista): o fluxo só tem Atualizar insumo.
- **Tempo de execução** considera só OS executadas, mas a OS reprovada também passa por Finalizar execução.
- **Status da OS**: o board cita 8 status, mas não os lista.
