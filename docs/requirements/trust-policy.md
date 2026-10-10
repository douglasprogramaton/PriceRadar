# Política de confiança — proposta inicial

> **Não existe ainda selo PriceRadar ativo nem avaliação real de lojas.** Este documento define comportamento e decisões a validar antes da produção.

## Entidades avaliadas

- **Loja/plataforma:** domínio oficial, identidade jurídica verificável, histórico e evidências de reputação disponíveis legalmente.
- **Vendedor:** identidade individual da parte responsável pela venda, inclusive seller de marketplace; não herda aprovação automática da plataforma.
- **Produto:** avaliações e atributos próprios, independentes da confiabilidade do vendedor.

## Estados

`Pendente`, `Aprovado`, `Reprovado`, `Expirado` e `Inconclusivo`.

Somente `Aprovado`, com evidências e validade atuais, permite exibição. Na dúvida, **bloquear** (fail closed).

## Critérios candidatos (ainda sem limiares definidos)

1. Identidade da loja e vendedor confirmável.
2. Canal e domínio de compra legítimos; verificação de redirecionamentos.
3. Evidências independentes e atuais de reputação e atendimento.
4. Indicadores verificáveis de fraude, reclamações e resolução, quando acessíveis legalmente.
5. Histórico e consistência dos dados; ausência de sinais críticos.

**Não inventar nota numérica nem chamar de “verificado” sem evidências.** Limiar, peso, fonte, validade, revisão e contestação exigem definição e testes antes de qualquer recomendação pública.

## Política de publicação

- Exibir somente ofertas cuja **loja E vendedor** estejam aprovados.
- Revalidar periodicamente; expiração, indisponibilidade da fonte ou alerta relevante suspende elegibilidade.
- Guardar proveniência da decisão (fonte, momento, versão da política), sem expor dados pessoais desnecessários.
- Separar “mais barato entre elegíveis” de “melhor avaliado”; avaliações de produto não tornam vendedores confiáveis.
- Informar ao usuário que aprovação reduz risco, mas **não garante** ausência de problemas.
