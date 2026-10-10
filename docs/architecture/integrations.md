# Estratégia de integrações externas

## Princípio

PriceRadar não é uma base universal de preços. A cobertura depende de **fontes com acesso permitido**, qualidade, atualização e atributos suficientes para identificar o mesmo produto.

## Ordem de preferência

1. APIs oficiais/documentadas com permissão de uso comercial ou de portfólio, conforme aplicável.
2. Feeds de catálogo e programas de parceiros com autorização explícita.
3. Dados licenciados de agregadores.
4. Extração de páginas apenas após avaliar autorização, termos, limites técnicos e requisitos legais — nunca presumir permissão por uma URL ser pública.

## Dados mínimos de uma oferta

Identificador de origem, URL, produto e variante, loja, vendedor efetivo, preço, moeda, disponibilidade e momento da consulta. Frete e avaliações são opcionais, mas ausência deve ser indicada.

## Confiança e avaliações

A integração de catálogo **não comprova** a confiabilidade de uma loja ou vendedor. Avaliações de produtos também não comprovam reputação comercial. Fontes, licenças, cobertura, recência e confiabilidade devem ser verificadas separadamente.

## Fases

- **Fase 1:** adaptador simulado com dados fictícios identificados; testar filtros e ranking.
- **Fase 2:** um provedor real autorizado e avaliação documentada de cobertura.
- **Fase 3:** novos provedores, deduplicação e tratamento de divergências.

## Riscos abertos

Ausência de API pública, variação de preço por CEP, seller diferente da loja, frete variável, promoções condicionais, avaliações não licenciadas, produtos similares confundidos e indisponibilidade das fontes.
