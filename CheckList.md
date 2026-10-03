# Checklist: Tech Challenge Fase 1 (SOAT)

> Atividade obrigatória, vale **90% da nota da fase**. Entrega em **um único arquivo PDF** com todas as informações e links.

---

## 1. Planejamento e DDD (antes de codar)

- [ ] Realizar o **Event Storming** de três fluxos: criação da OS, acompanhamento da OS e gestão de peças/insumos
- [ ] Identificar e documentar: eventos de domínio, comandos, políticas/regras de negócio, atores
- [ ] Definir agregados, entidades e objetos de valor
- [ ] Identificar Bounded Contexts (quando houver)
- [ ] Montar os diagramas pedidos na disciplina de DDD
- [ ] Criar a **Linguagem Ubíqua** e o glossário dos principais termos
- [ ] Documentar a relação entre a documentação e o código implementado
- [ ] Publicar no Miro (ou equivalente) com **acesso liberado sem pedir permissão**
- [ ] Exportar para PDF/imagens e salvar no repositório:

  ```
  docs/
    ddd/
      event-storming.pdf
      diagramas.pdf
      linguagem-ubiqua.md
  ```

> A documentação precisa refletir o código entregue. Material genérico ou de aula não conta.

---

## 2. Funcionalidades: Criação da OS

- [ ] Identificar cliente por CPF/CNPJ
- [ ] Cadastrar veículo (placa, marca, modelo, ano)
- [ ] Incluir serviços solicitados
- [ ] Incluir peças e insumos
- [ ] Gerar orçamento automaticamente (serviços + peças)
- [ ] Enviar/disponibilizar orçamento para aprovação
- [ ] Registrar aprovação ou rejeição do orçamento

---

## 3. Funcionalidades: Acompanhamento da OS

- [ ] Implementar os status: Recebida, Em diagnóstico, Aguardando aprovação, Em execução, Finalizada, Entregue
- [ ] Implementar regras de transição de status
- [ ] Alterar status automaticamente conforme as ações no sistema
- [ ] Criar API para o cliente consultar o andamento da OS

---

## 4. Funcionalidades: Gestão administrativa

- [ ] CRUD de clientes
- [ ] CRUD de veículos
- [ ] CRUD de serviços
- [ ] CRUD de peças e insumos
- [ ] Controle de estoque
- [ ] Listagem de OS
- [ ] Detalhamento de OS
- [ ] Monitoramento/cálculo do tempo médio de execução dos serviços

---

## 5. Requisitos técnicos

- [ ] Back-end **monolítico** com **arquitetura em camadas**
- [ ] Escolher o banco de dados e **justificar a decisão**
- [ ] APIs RESTful
- [ ] Documentação **Swagger/OpenAPI**
- [ ] **Autenticação JWT** nas APIs administrativas
- [ ] Validação de CPF/CNPJ
- [ ] Validação de placa do veículo
- [ ] **Tratamento adequado de transações** nos fluxos principais
- [ ] `Dockerfile` para build da aplicação
- [ ] `docker-compose.yml` orquestrando o ambiente completo
- [ ] Execução local simples

---

## 6. Qualidade e segurança

- [ ] Testes unitários
- [ ] Testes de integração dos fluxos principais
- [ ] **Cobertura mínima de 80%** nos domínios críticos, com evidência (relatório)
- [ ] Executar **análise de vulnerabilidades** e guardar o relatório/resultado no repositório
- [ ] Garantir que não haja credenciais, senhas, tokens ou dados sensíveis no repo

---

## 7. Repositório GitHub

- [ ] Repositório(s) **público(s)** durante todo o período de correção e revisão de notas
- [ ] Branch `main` **protegida**, com tudo entrando via **Pull Request**
- [ ] Definir a versão final (branch, tag ou hash do commit)
- [ ] Apenas arquivos necessários ao projeto
- [ ] Documentação da API (Swagger/OpenAPI) incluída

### README.md completo, com:

- [ ] Objetivo do projeto
- [ ] Descrição resumida da solução
- [ ] Arquitetura utilizada
- [ ] Tecnologias utilizadas
- [ ] Pré-requisitos
- [ ] Instruções para execução
- [ ] Instruções para execução dos testes
- [ ] Como acessar o Swagger/documentação da API
- [ ] Decisão e justificativa do banco de dados
- [ ] Usuários/credenciais de demonstração ou procedimento de autenticação
- [ ] Estrutura dos principais diretórios
- [ ] Link para a documentação DDD
- [ ] Link para o vídeo

---

## 8. Vídeo (YouTube, público, máx. 15 min)

**Requisitos:** áudio compreensível, mostrar o projeto **do commit informado no PDF**, apresentar/identificar os integrantes do grupo, ficar disponível durante toda a correção.

**Conteúdo mínimo a demonstrar:**

- [ ] Proposta da solução
- [ ] Arquitetura do projeto
- [ ] Organização do monólito e suas camadas
- [ ] Escolha e justificativa do banco de dados
- [ ] Processo de Event Storming
- [ ] Principais elementos de DDD usados
- [ ] Fluxo de criação e acompanhamento de uma OS
- [ ] Inclusão de serviços, peças e insumos
- [ ] Geração e aprovação do orçamento
- [ ] Alteração dos status da OS
- [ ] Autenticação das APIs administrativas
- [ ] Execução da aplicação
- [ ] Documentação Swagger/OpenAPI
- [ ] Testes automatizados
- [ ] Resultado da análise de vulnerabilidades

---

## 9. PDF de entrega (arquivo único)

**Primeira página (obrigatório):**

- [ ] Curso: SOAT — Software Architecture
- [ ] Fase: 1
- [ ] Número do grupo
- [ ] Nome completo de todos os integrantes
- [ ] RM de todos os integrantes
- [ ] Username do Discord de todos
- [ ] Linguagem e principais tecnologias

**Demais conteúdos:**

- [ ] Link completo e **clicável** de todos os repositórios
- [ ] **Branch e hash do commit** da entrega final
- [ ] Link clicável do vídeo no YouTube
- [ ] Link direto da documentação DDD (Miro ou equivalente)

---

## 10. Revisão final (antes de enviar)

- [ ] Testar todos os links em aba anônima (repositório, vídeo, Miro)
- [ ] Conferir se o hash do commit no PDF é o mesmo mostrado no vídeo
- [ ] Clonar o repo do zero e subir com `docker-compose up` seguindo só o README
- [ ] Verificar que a documentação DDD bate com o código
- [ ] Conferir o prazo de entrega

---

## Sugestão de divisão de tarefas

| Frente | Responsabilidade |
|---|---|
| DDD/Docs | Event Storming, diagramas, linguagem ubíqua, Miro |
| Domínio e OS | Fluxo da OS, status, orçamento, regras de transição |
| Cadastros | CRUDs, estoque, validações CPF/CNPJ/placa |
| Infra/Segurança | JWT, Docker, banco, análise de vulnerabilidades, proteção da `main` |
| Qualidade | Testes unitários/integração, cobertura 80% |
| Entrega | README, vídeo, PDF final |