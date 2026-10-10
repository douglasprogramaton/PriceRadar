# Requisitos — PriceRadar

## Visão do produto

Plataforma de pesquisa e comparação de ofertas online em múltiplas categorias. **Segurança é requisito eliminatório**: somente lojas e vendedores aprovados podem ter ofertas exibidas. Preço baixo nunca substitui aprovação.

## MVP — requisitos funcionais

| Código | Requisito | Critério de aceitação |
|---|---|---|
| RF001 | Buscar produtos por nome ou termos | Busca retorna produtos da fonte integrada e identifica ausência de resultados. |
| RF002 | Consolidar identidade do produto | Ofertas de variantes distintas não são agrupadas como idênticas. |
| RF003 | Consultar ofertas de fontes autorizadas | Toda oferta contém identificador de origem e horário de consulta. |
| RF004 | Verificar loja **e** vendedor | Oferta é elegível apenas se ambos possuírem aprovação vigente; loja própria pode ser modelada como vendedor identificado. |
| RF005 | Filtrar ofertas não elegíveis | Ofertas reprovadas, desconhecidas ou com aprovação expirada não aparecem no resultado público. |
| RF006 | Comparar preços | Ordenação usa preço + frete conhecido; quando frete não estiver disponível, identifica custo parcial e não afirma menor custo final. |
| RF007 | Mostrar avaliações do produto | Exibir nota, contagem, fonte e atualização somente quando houver dados verificáveis; ausência é informada. |
| RF008 | Mostrar transparência da oferta | Exibir loja, vendedor, preço, disponibilidade, link de origem, atualização e estado do frete. |
| RF009 | Não haver resultados confiáveis | Exibir mensagem clara, sem recorrer automaticamente a ofertas não verificadas. |

## Regras de negócio

- **RN001:** loja deve estar aprovada e com aprovação vigente.
- **RN002:** vendedor deve estar aprovado individualmente, inclusive em marketplaces.
- **RN003:** reputação ausente, inconclusiva, expirada ou reprovada implica **não elegível**.
- **RN004:** preço mais baixo não pode ignorar regras de elegibilidade.
- **RN005:** avaliações de produto não substituem reputação de vendedor/loja.
- **RN006:** registrar fonte e momento da coleta de preço, avaliação e evidências de confiança.
- **RN007:** comparação exige correspondência suficientemente segura de produto e variante.
- **RN008:** não afirmar menor preço da internet: informar **menor preço entre ofertas elegíveis consultadas**.
- **RN009:** links de compra direcionam ao fornecedor; PriceRadar não processa pagamentos no MVP.
- **RN010:** falha na verificação ou expiração da aprovação bloqueia a oferta até nova avaliação.

## Requisitos não funcionais

- **RNF001:** não armazenar segredos em repositório; usar configuração segura.
- **RNF002:** logs estruturados com IDs de correlação, sem dados pessoais sensíveis desnecessários.
- **RNF003:** testes unitários para filtros de confiança, correspondência e classificação.
- **RNF004:** respeitar termos de uso, licenças, privacidade e limites das fontes externas.
- **RNF005:** manter rastreabilidade da origem e do instante de coleta.
- **RNF006:** falhas de provedores não podem tornar ofertas não verificadas elegíveis.

## Fora do MVP

Pesquisa por URL, login, lista de desejos, alertas, histórico de preços, múltiplas integrações, análise automatizada de avaliações textuais, comparação por CEP/frete em tempo real e aplicativo móvel.

## Dependências e decisões pendentes

1. Escolher e validar **fonte autorizada** de produtos, preços e links de ofertas.
2. Definir critérios objetivos e fontes verificáveis de aprovação de lojas e vendedores (ver [política](trust-policy.md)).
3. Verificar disponibilidade e licença de avaliações de produtos.
4. Definir como lidar com frete indisponível e produtos sem GTIN/EAN.

Sem essas fontes, o primeiro incremento técnico poderá usar um provedor simulado com dados **explicitamente fictícios**, nunca apresentados como ofertas reais.
