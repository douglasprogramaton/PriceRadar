# PriceRadar

Comparador de ofertas online que prioriza **segurança de compra**, **correspondência correta do produto** e **custo total**, não apenas o menor preço anunciado.

> Status: arquitetura e requisitos em definição. Ainda não há integração operacional com lojas nem verificação automatizada de vendedores.

## Objetivo

Permitir pesquisar produtos de diferentes categorias (eletrônicos, eletrodomésticos, vestuário, utensílios domésticos, alimentos etc.) e comparar apenas ofertas de **lojas e vendedores aprovados** conforme critérios verificáveis.

## Princípios

- Nunca recomendar oferta de loja ou vendedor sem aprovação válida.
- Separar **reputação da loja/vendedor** de **avaliações do produto**.
- Comparar variantes equivalentes (modelo, capacidade, tamanho, condição etc.).
- Informar origem, horário de coleta e limitações dos dados.
- Não inventar notas, avaliações, preços ou selos de verificação.

## MVP proposto

1. Buscar produtos por texto em um catálogo alimentado por **fonte autorizada**.
2. Normalizar e identificar variantes dos produtos.
3. Validar loja e vendedor com regras explícitas; bloquear ofertas sem evidências suficientes.
4. Listar ofertas elegíveis com preço, moeda, disponibilidade e data de atualização.
5. Exibir avaliações de produtos **quando fornecidas legitimamente**, com fonte e quantidade.
6. Ordenar ofertas por menor custo conhecido, sem confundir preço sem frete com custo final.

A pesquisa por URL, múltiplos provedores, histórico de preços, alertas e análise avançada de reputação ficam para fases posteriores. A integração inicial dependerá da existência de uma fonte com permissão de uso e dados suficientes.

## Tecnologia

.NET 10 / C#, DDD e Clean Architecture. Projetos: `PriceRadar.Domain`, `PriceRadar.Application`, `PriceRadar.Infrastructure` e `PriceRadar.Api`.

Documentação: [requisitos](docs/requirements/README.md), [arquitetura](docs/architecture/README.md), [critérios de confiança](docs/requirements/trust-policy.md), [integrações](docs/architecture/integrations.md) e [decisão arquitetural](docs/architecture/ADR-001-new-scope.md).

## Desenvolvimento

Trabalhar em branches, revisar alterações, executar `dotnet build PriceRadar.slnx` e testes disponíveis antes de abrir PR. Este repositório ainda contém a estrutura inicial, sem regras de negócio implementadas.
