# ADR-004: Escolha do PostgreSQL como banco de dados (Amazon RDS)

- **Status:** Aceito
- **Data:** 2026-09-29
- **Decisores:** 

## Contexto

O projeto é um MVP acadêmico em C# / .NET, com arquitetura Onion (ver [ADR-003](ADR-003-adocao-onion-architecture.md)), que será hospedado na AWS usando o serviço gerenciado **Amazon RDS**.

Precisamos escolher o SGBD relacional. As opções avaliadas foram **PostgreSQL** e **SQL Server**. Os fatores considerados foram:

- **Custo:** no RDS, o SQL Server é oferecido apenas no modelo *License Included* (a licença Microsoft é embutida no valor por hora), enquanto o PostgreSQL não tem custo de licença.
- **Recursos técnicos:** o sistema deve usar dados semiestruturados (JSON), busca textual e extensões (ex.: PostGIS, pg_trgm).
- **Evolução da infraestrutura:** há interesse em evitar componentes adicionais (como um Redis) nas fases iniciais.

## Decisão

Adotar o **PostgreSQL** rodando no **Amazon RDS for PostgreSQL**.

Diretrizes:

1. Acesso a dados via **Npgsql** / **Entity Framework Core** (provider `Npgsql.EntityFrameworkCore.PostgreSQL`), implementado apenas na camada `Infrastructure`.
2. Interfaces de repositório permanecem na camada `Domain`, sem dependência do PostgreSQL (regra do ADR-003).
3. Recursos específicos do PostgreSQL (JSONB, full-text search, extensões) devem ficar **encapsulados na Infrastructure**, para limitar o acoplamento ao banco.
4. Manter a versão do PostgreSQL atualizada no RDS, evitando cobranças de *Extended Support* para versões fora de suporte.

## Alternativas consideradas

### SQL Server (Amazon RDS for SQL Server)
- (+) Integração natural com o ecossistema .NET e ferramentas Microsoft.
- (+) Possui recursos nativos de JSON, full-text search e tipos espaciais.
- (–) Custo maior no RDS, pois a licença é incluída no preço por hora e não há opção de trazer a própria licença.
- (–) Ecossistema de extensões e indexação de JSON menos flexível que o do PostgreSQL (JSONB com índices GIN, pg_trgm, PostGIS).

**Descartado** principalmente por custo e pelos recursos técnicos do PostgreSQL.

## Consequências

**Positivas**
- (+) Sem custo de licenciamento de software no RDS.
- (+) JSONB, full-text search e extensões disponíveis sem componentes extras.
- (+) Portabilidade: roda em containers e em qualquer nuvem, o que ajuda em uma futura migração para microsserviços.
- (+) Possibilidade de adiar a adoção de um cache dedicado (ver nota abaixo).

**Negativas / trade-offs**
- (–) Menor afinidade nativa com o ecossistema Microsoft (ferramentas, tooling).
- (–) Recursos específicos do PostgreSQL aumentam o acoplamento se vazarem para fora da Infrastructure.
- (–) Necessário acompanhar o ciclo de vida das versões do PostgreSQL no RDS.

### Nota sobre uso como cache

O PostgreSQL pode atender necessidades simples de cache no MVP (ex.: tabelas `UNLOGGED`, colunas JSONB, expiração via job agendado), evitando mais um componente de infraestrutura. Porém **não substitui o Redis** em cenários de alta taxa de leitura, baixa latência ou TTL nativo, e o cache consome recursos do mesmo banco transacional.

**Critério de revisão:** reavaliar a adoção de um cache dedicado se o uso do banco como cache impactar o desempenho das operações transacionais.

## Validação pendente

- [ ] Simular o custo no [AWS Pricing Calculator](https://calculator.aws/) para a região e a classe de instância do projeto, comparando PostgreSQL e SQL Server.

## Referências
- Documentação do Amazon RDS for PostgreSQL e do RDS for SQL Server (páginas de preços).
- Documentação do PostgreSQL: JSONB, Full Text Search, `pg_trgm`, PostGIS.
