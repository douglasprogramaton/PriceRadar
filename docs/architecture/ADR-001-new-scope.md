# ADR-001 — Comparação de ofertas online com confiança obrigatória

**Status:** Aceita para orientar o planejamento (implementação pendente)

## Contexto

A proposta inicial comparava supermercados, distâncias e combustível. O produto foi redefinido para pesquisar itens de várias categorias em lojas online e recomendar somente ofertas de lojas e vendedores aprovados.

## Decisão

- Manter .NET 10, DDD e Clean Architecture e os quatro projetos existentes.
- Substituir o foco em deslocamento por identidade de produto, oferta, avaliação e elegibilidade de loja/vendedor.
- Aplicar filtro eliminatório de confiança **antes** de classificar ofertas por preço.
- Separar avaliações de produto da confiança comercial.
- Exigir origem, data e clareza sobre limitações dos dados.
- Começar com um caso de uso vertical pequeno e provedor simulado; integrar fonte real apenas após validação de autorização e dados.

## Consequências

**Positivas:** arquitetura testável, regras claras, menor risco de recomendar ofertas inseguras e expansão gradual de fontes.

**Custos/riscos:** cobertura reduzida, dependência de provedores externos, necessidade de critérios auditáveis e atualização frequente das avaliações de confiança.

## Fora do escopo inicial

Comparação por combustível/distância, autenticação, alertas, histórico de preços e promessa de busca irrestrita em toda a internet.
