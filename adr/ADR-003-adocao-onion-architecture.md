# ADR-003: Adoção da Onion Architecture

- **Status:** Aceito
- **Data:** 2026-09-29
- **Decisores:** 

## Contexto

O projeto é um MVP acadêmico (pós-graduação em Arquitetura de Software), desenvolvido em **C# / .NET**. Apesar de ser um MVP, existe a expectativa de que o sistema evolua, e já são previstas duas mudanças relevantes:

- troca do banco de dados / mecanismo de persistência;
- migração futura para microsserviços.

Por isso, precisamos de uma arquitetura que mantenha o sistema fácil de evoluir e manter, sem impor complexidade excessiva neste estágio inicial.

## Decisão

Adotar a **Onion Architecture** como estilo arquitetural da aplicação.

As dependências apontam sempre para o centro:

```
Presentation / Infrastructure  →  Application  →  Domain
```

Estrutura de camadas (solution .NET):

| Camada | Responsabilidade | Depende de |
|--------|------------------|------------|
| `Domain` | Entidades, value objects, agregados, regras de negócio e interfaces de repositório | Nada |
| `Application` | Casos de uso, serviços de aplicação, DTOs | Domain |
| `Infrastructure` | Persistência, integrações externas, implementação das interfaces | Application, Domain |
| `Presentation` | API / interface com o usuário, composição das dependências (DI) | Application |

Regras:

1. O `Domain` não referencia frameworks, ORM nem bibliotecas de infraestrutura.
2. Repositórios são declarados como interfaces no núcleo e implementados em `Infrastructure`.
3. Injeção de dependência é usada para ligar as implementações na camada externa.

## Alternativas consideradas

### Clean Architecture
Muito próxima da Onion em princípios (regra de dependência apontando para o centro), porém com mais camadas e conceitos formais (use cases/interactors, boundaries, presenters). **Descartada** por adicionar cerimônia desnecessária para um MVP. Como as duas compartilham a mesma ideia central, migrar de uma para outra, se necessário, tem custo baixo.

## Consequências

**Positivas**
- (+) Domínio isolado de infraestrutura, o que facilita a troca de banco de dados.
- (+) Domínio e casos de uso testáveis sem banco ou API.
- (+) Fronteiras claras entre camadas, o que ajuda a separar módulos em microsserviços no futuro (ver bounded contexts em `domain/`).
- (+) Menos camadas e conceitos que a Clean Architecture, favorecendo a simplicidade do MVP.

**Negativas / trade-offs**
- (–) Mais projetos e interfaces do que uma arquitetura em camadas simples (mais código de "cola" e mapeamentos).
- (–) Exige disciplina para respeitar a regra de dependência (pode ser reforçada com testes de arquitetura, como NetArchTest).
- (–) A migração para microsserviços não é automática: a Onion organiza o código, mas a separação dos serviços exigirá decisões próprias (ver ADR futuro).

## Referências
- Palermo, Jeffrey. *The Onion Architecture* (2008).
- Martin, Robert C. *Clean Architecture*. Pearson, 2017.
