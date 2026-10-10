# ADR-005: Brevo + MailKit como padrão inicial para envio de e-mail no MVP

- **Status:** Proposto
- **Data:** 2026-10-02
- **Decisores:** [Nome do(a) aluno(a)], [Orientador(a), se aplicável]

## Contexto

O MVP precisa enviar e-mails transacionais (ex.: confirmação de cadastro,
recuperação de senha e notificações do sistema). Nesta fase, o projeto tem
volume baixo de envios, orçamento praticamente nulo e prazo curto, o que
torna a simplicidade de configuração e o custo inicial critérios centrais.

Também é desejável não acoplar a aplicação a um provedor específico, já que
o provedor poderá ser trocado quando o projeto evoluir além do MVP.

## Decisão

Adotar o **Brevo** (via SMTP relay) como provedor de envio de e-mail e o
**MailKit** como biblioteca cliente SMTP na aplicação, para o MVP.

O envio será encapsulado em uma abstração (ex.: `IEmailSender`), de modo que
a implementação com MailKit/Brevo possa ser substituída sem impacto nas
regras de negócio. As credenciais SMTP serão mantidas fora do código-fonte,
em variáveis de ambiente ou gerenciador de segredos.

## Alternativas consideradas

**Amazon SES (AWS)**
- Vantagens: custo por e-mail muito baixo em escala, alta capacidade de
  envio, integração nativa com o ecossistema AWS e boa reputação de entrega.
- Desvantagens: exige conta e configuração na AWS (IAM, regiões, verificação
  de domínio), a conta começa em modo *sandbox* e requer solicitação de
  acesso à produção, e há maior curva de configuração para um MVP. O ganho
  de custo só se torna relevante com volumes maiores do que os esperados
  neste momento.
- Motivo da não escolha agora: a complexidade operacional inicial não se
  justifica para o volume e o prazo do MVP.

Observação: o SES também expõe interface SMTP, portanto é compatível com o
MailKit e continua sendo um caminho viável de migração futura.

## Consequências

- (+) Configuração rápida: basta host, porta, usuário e senha SMTP, sem
  depender de infraestrutura adicional.
- (+) Plano gratuito do Brevo suficiente para o volume esperado do MVP
  (limites a validar na documentação vigente).
- (+) MailKit é uma biblioteca madura, mantida ativamente e padrão de
  mercado no ecossistema .NET para SMTP.
- (+) A abstração `IEmailSender` reduz o custo de migração para o SES ou
  outro provedor.
- (–) Limite diário/mensal de envios no plano gratuito, que pode restringir o
  crescimento e exigir upgrade ou migração.
- (–) Dependência de um provedor externo fora do ecossistema AWS, caso o
  restante da infraestrutura venha a ser nela hospedado.
- (–) O uso de SMTP oferece menos recursos que a API nativa do provedor
  (ex.: rastreamento mais granular, templates e webhooks), que exigiriam
  integração adicional.
- (–) Será necessário configurar SPF, DKIM e DMARC no domínio para garantir
  entregabilidade, independentemente do provedor.