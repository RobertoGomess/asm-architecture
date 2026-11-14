# Checklist: Tech Challenge Fase 2 (SOAT)

> Atividade obrigatória, vale **60% da nota de todas as disciplinas da fase**. Evolui a aplicação da Fase 1 com foco em qualidade, resiliência e escalabilidade. Usar o **mesmo repositório da Fase 1**.

---

## 1. Refatoração do código (Fase 1 → Fase 2)

- [ ] Aplicar **Clean Code**: nomes claros, simplicidade, coesão
- [ ] Aplicar **Clean Architecture** ou **Arquitetura Hexagonal** (separação de camadas e direção das dependências)
- [ ] Registrar a escolha da abordagem arquitetural (ADR)
- [ ] Testes automatizados (unitários e/ou integração) cobrindo os **fluxos críticos**

---

## 2. APIs (alterar/criar)

### Abertura de OS

- [ ] Receber dados do cliente, veículo, serviços e peças
- [ ] Retornar a **identificação única** da OS

### Consulta de status da OS

- [ ] Informar a situação atual: Recebida, Diagnóstico, Aguardando Aprovação, Execução, Finalizada, Entregue

### Aprovação de orçamento

- [ ] Endpoint para receber **notificações externas** de aprovação ou recusa do orçamento pelo cliente

### Listagem de OS

- [ ] Ordenar por status: **Em Execução > Aguardando Aprovação > Diagnóstico > Recebida**
- [ ] Dentro do mesmo status, **mais antigas primeiro**
- [ ] Excluir da listagem (exclusão **lógica**, não física) as OS **Finalizadas** e **Entregues**

### Atualização de status

- [ ] Atualizar status da OS via ferramenta externa, como **e-mail** (ver ADR-005: Brevo/MailKit)

---

## 3. Conteinerização (Docker)

- [ ] `Dockerfile` atualizado
- [ ] `docker-compose.yml` para desenvolvimento local

---

## 4. Orquestração (Kubernetes)

Manifestos YAML em `/k8s`:

- [ ] Deployments
- [ ] Services
- [ ] ConfigMaps
- [ ] Secrets (variáveis sensíveis, ex.: tokens de serviços externos)
- [ ] **Horizontal Pod Autoscaler (HPA)** escalando por CPU/memória
- [ ] Garantir que os Secrets reais **não** sejam commitados (usar placeholders/variáveis da pipeline)

---

## 5. Infraestrutura como Código (Terraform)

Scripts em `/infra`:

- [ ] Provisionamento do **cluster Kubernetes** (local ou cloud)
- [ ] Provisionamento do **banco de dados**
- [ ] Documentar **quais recursos são criados**
- [ ] Documentar **como aplicar** (`init`, `plan`, `apply`, `destroy`)

---

## 6. CI/CD

Pipeline configurada (GitHub Actions, GitLab CI etc.) executando:

- [ ] Build da aplicação
- [ ] Execução dos testes automatizados
- [ ] Build da imagem Docker
- [ ] Deploy no cluster Kubernetes
- [ ] Deploy do banco de dados
- [ ] Aplicação dos manifestos YAML no cluster
- [ ] Arquivos de configuração da pipeline versionados no repositório

---

## 7. Repositório GitHub

- [ ] Mesmo repositório da Fase 1
- [ ] Compartilhado com o usuário **`soat-architecture`**
- [ ] Código-fonte atualizado e refatorado
- [ ] `Dockerfile` e `docker-compose` revisados
- [ ] Manifestos Kubernetes em `/k8s`
- [ ] Scripts Terraform em `/infra`
- [ ] Arquivos da pipeline CI/CD

### README.md atualizado, com:

- [ ] Descrição da solução e dos objetivos desta fase
- [ ] Desenho da arquitetura proposta, incluindo:
  - [ ] Componentes da aplicação
  - [ ] Infraestrutura provisionada
  - [ ] Fluxo de deploy
- [ ] Instruções para execução local
- [ ] Instruções para deploy em Kubernetes
- [ ] Instruções para provisionamento da infraestrutura com Terraform
- [ ] Link para a collection completa das APIs (Postman, Swagger ou similar)
- [ ] Link para o vídeo demonstrativo

---

## 8. Vídeo (YouTube ou Vimeo, público ou não listado, máx. 15 min)

**O vídeo deve demonstrar:**

- [ ] Deploy da aplicação
- [ ] Execução do CI/CD
- [ ] Consumo das APIs
- [ ] Escalabilidade automática (simular aumento de carga ou múltiplas OS e mostrar o HPA escalando)

---

## 9. PDF de entrega (portal do aluno)

- [ ] Link do repositório GitHub (compartilhado com `soat-architecture`)
- [ ] Desenho da arquitetura com os recursos escolhidos
- [ ] Link do vídeo (até 15 min)

---

## 10. Revisão final (antes de enviar)

- [ ] Confirmar acesso do usuário `soat-architecture` ao repositório
- [ ] Testar todos os links em aba anônima (repositório, vídeo, collection)
- [ ] Rodar a pipeline do zero e confirmar que todas as etapas passam
- [ ] Provisionar com Terraform e fazer deploy no K8s seguindo só o README
- [ ] Subir localmente com `docker-compose up` seguindo só o README
- [ ] Verificar que não há credenciais, senhas ou tokens no repositório
- [ ] Conferir o prazo de entrega

---

## Sugestão de divisão de tarefas

| Frente | Responsabilidade |
|---|---|
| Arquitetura/Refatoração | Clean Code, Clean Architecture/Hexagonal, ADRs |
| APIs | Abertura, consulta de status, aprovação de orçamento, listagem, atualização via e-mail |
| Qualidade | Testes unitários/integração dos fluxos críticos |
| Kubernetes | Deployments, Services, ConfigMaps, Secrets, HPA |
| IaC | Terraform do cluster e do banco, documentação |
| CI/CD | Pipeline de build, testes, imagem, deploy |
| Entrega | README, desenho da arquitetura, vídeo, PDF final |
