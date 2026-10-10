# Arquitetura — PriceRadar

## Contexto e objetivo

O PriceRadar compara ofertas online de múltiplas categorias, priorizando **elegibilidade de loja e vendedor**, correspondência correta do produto e transparência dos preços. Substitui a proposta anterior centrada em supermercados, distância e combustível. Ver [ADR-001](ADR-001-new-scope.md).

O repositório mantém **DDD, Clean Architecture e .NET 10**, com as camadas já existentes. Este documento descreve a arquitetura **alvo**, não funcionalidades já implementadas.

## Estrutura existente

```text
PriceRadar/
├── src/
│   ├── PriceRadar.Domain/
│   ├── PriceRadar.Application/
│   ├── PriceRadar.Infrastructure/
│   └── PriceRadar.Api/
├── docs/
│   ├── architecture/
│   └── requirements/
└── PriceRadar.slnx
```

Os projetos já existem; as entidades, serviços, adaptadores e testes descritos a seguir são **planejados**, não criados nesta atualização documental.

## Responsabilidades e dependências

```text
Api ───────────► Application ───────────► Domain
                    ▲
                    │ implementações de portas
Infrastructure ─────┘
```

- **Domain:** entidades e regras puras, sem HTTP, banco ou dependência de provedores.
- **Application:** casos de uso, DTOs e contratos de acesso a catálogo, ofertas, avaliações e confiança.
- **Infrastructure:** implementações de contratos, provedores externos, persistência, cache e observabilidade.
- **Api:** endpoints, validação de entrada, DI, tratamento de erros e documentação HTTP.

As dependências de compilação existentes serão revisadas quando introduzirmos contratos e implementações; o diagrama indica a direção arquitetural desejada, não a configuração completa atual.

## Conceitos do domínio (propostos)

| Conceito | Responsabilidade |
|---|---|
| `Product` | Identidade canônica e atributos do produto. |
| `ProductVariant` | Modelo, capacidade, cor, tamanho, condição e outros atributos comparáveis. |
| `Merchant` | Loja/plataforma responsável pela oferta. |
| `Seller` | Vendedor efetivo, mesmo quando opera dentro de marketplace. |
| `Offer` | Produto/variante, vendedor, loja, preço, moeda, disponibilidade, URL, data e frete conhecido. |
| `TrustAssessment` | Estado, evidências, versão da política e validade de aprovação. |
| `ProductRatingSummary` | Nota agregada, quantidade, fonte e data de coleta, se disponíveis. |
| `Money` | Valor monetário e moeda, sem operações entre moedas incompatíveis. |

Não modelar reputação do produto como reputação do vendedor. Não assumir GTIN universal para todas as categorias.

## Fluxo de pesquisa

1. Receber termo de busca e filtros.
2. Consultar catálogo/ofertas por interface da Application, usando fonte autorizada.
3. Normalizar e associar ofertas à variante correta; casos ambíguos não entram em comparações exatas.
4. Consultar avaliações de confiança **da loja e do vendedor**.
5. Excluir ofertas sem aprovação vigente de qualquer uma das partes.
6. Enriquecer com avaliações de produto disponíveis, sem inventar dados ausentes.
7. Ordenar ofertas elegíveis por custo conhecido e sinalizar frete indisponível.
8. Retornar origem e instante de atualização; nunca prometer cobertura de toda a internet.

## Interfaces planejadas (nomes ilustrativos)

- `IProductSearchProvider`: busca e identidade de produtos.
- `IOfferProvider`: consulta de ofertas e disponibilidade.
- `ITrustAssessmentProvider`: evidências e estado de aprovação de loja/vendedor.
- `IProductRatingProvider`: resumo de avaliações de produtos.
- `IClock`: abstração de tempo para testes e expiração.

Contratos serão desenhados a partir do primeiro caso de uso e não precisam refletir diretamente o formato de APIs externas.

## Segurança e resiliência

- **Fail closed:** ausência/erro/expiração da verificação impede exibição da oferta.
- Não colocar tokens ou chaves em código, Git ou logs.
- Validar URLs e restringir destinos para evitar redirecionamentos perigosos.
- Respeitar limites, licenças, privacidade e termos de integração.
- Aplicar timeouts, tratamento de falhas e cache com validade explícita.
- Registrar fonte e timestamp de cada dado; não transformar dado fictício em oferta real.

## Testes previstos

- Unitários de elegibilidade (`Aprovado`/`Pendente`/`Expirado`), incluindo seller de marketplace.
- Unitários de correspondência de variantes e ordenação por preço/frete.
- Integração com adaptador simulado, falhas e dados incompletos.
- Testes de API para resultados vazios e ausência de ofertas confiáveis.

## Próximos incrementos

1. Validar provedor de dados e política de confiança.
2. Criar testes e entidades mínimas do domínio.
3. Implementar caso de uso de busca com provedor simulado.
4. Expor endpoint de pesquisa com respostas transparentes.
5. Integrar primeiro provedor real autorizado e validar qualidade dos dados.
6. Evoluir para histórico, alertas e novas fontes em branches específicas.

Consulte [requisitos](../requirements/README.md), [política de confiança](../requirements/trust-policy.md) e [integrações](integrations.md).
