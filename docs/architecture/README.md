# 🏗️ Arquitetura do PriceRadar

Este documento descreve a arquitetura inicial do **PriceRadar**, suas camadas, responsabilidades e regras de dependência.

O objetivo é manter uma base de código **organizada, testável, desacoplada e preparada para evoluir** conforme novas funcionalidades forem adicionadas ao projeto.

---

## 📌 Visão Geral

O **PriceRadar** é uma aplicação para comparação de preços de produtos entre mercados, considerando não apenas o preço dos produtos, mas também fatores relacionados à localização e ao deslocamento do usuário.

A solução está sendo estruturada utilizando princípios de:

- **Clean Architecture**
- **Domain-Driven Design (DDD)**
- **SOLID**
- **Separation of Concerns**
- **Dependency Inversion**

A arquitetura inicial possui quatro projetos principais:

| Projeto | Responsabilidade |
|---|---|
| `PriceRadar.Domain` | Regras e conceitos centrais do negócio |
| `PriceRadar.Application` | Casos de uso e orquestração da aplicação |
| `PriceRadar.Infrastructure` | Banco de dados, integrações e serviços externos |
| `PriceRadar.Api` | Interface HTTP e ponto de entrada da aplicação |

---

## 📂 Estrutura do Repositório

```text
PriceRadar/
│
├── src/
│   ├── PriceRadar.Domain/
│   ├── PriceRadar.Application/
│   ├── PriceRadar.Infrastructure/
│   └── PriceRadar.Api/
│
├── tests/
│
├── docs/
│   ├── architecture/
│   ├── database/
│   └── requirements/
│
├── PriceRadar.slnx
└── .gitignore
```

### `src/`

Contém o código-fonte da aplicação.

### `tests/`

Será responsável pelos projetos de testes automatizados da solução.

### `docs/`

Centraliza a documentação técnica e funcional do PriceRadar.

A documentação será separada por assunto:

```text
docs/
├── architecture/   # Arquitetura e decisões técnicas
├── database/       # Modelagem e documentação do banco de dados
└── requirements/   # Requisitos funcionais e não funcionais
```

---

# 🧱 Camadas da Aplicação

## 🟦 Domain

```text
src/PriceRadar.Domain
```

A camada **Domain** representa o núcleo do sistema.

Ela contém os conceitos e regras de negócio fundamentais do PriceRadar.

Exemplos de elementos que poderão existir nessa camada:

- entidades;
- value objects;
- regras de negócio;
- enums;
- exceções de domínio;
- contratos estritamente relacionados ao domínio.

### Regra importante

> O `Domain` deve permanecer independente das demais camadas e de detalhes externos.

Isso significa que essa camada não deve conhecer:

- banco de dados;
- Entity Framework;
- APIs externas;
- interface web;
- serviços de e-mail;
- frameworks de infraestrutura.

---

## 🟩 Application

```text
src/PriceRadar.Application
```

A camada **Application** contém os casos de uso do sistema.

Ela será responsável por coordenar as operações necessárias para executar as funcionalidades do PriceRadar.

Exemplos futuros:

- pesquisar produtos;
- comparar preços;
- criar listas de compras;
- calcular o custo de uma compra;
- determinar mercados mais vantajosos;
- autenticar usuários;
- recuperar acesso à conta.

A camada:

```text
Application → Domain
```

pode depender do `Domain`, mas não deve depender diretamente dos detalhes concretos da infraestrutura.

---

## 🟨 Infrastructure

```text
src/PriceRadar.Infrastructure
```

A camada **Infrastructure** implementa os recursos técnicos necessários para que os casos de uso funcionem.

Ela poderá conter:

- persistência de dados;
- Entity Framework Core;
- acesso ao banco de dados;
- implementação de repositórios;
- integrações com APIs externas;
- serviços de localização;
- serviços de mapas e distância;
- envio de e-mails;
- autenticação e serviços externos;
- cache;
- logging;
- outras integrações.

A infraestrutura implementará contratos definidos pelas camadas internas quando necessário.

---

## 🟥 API

```text
src/PriceRadar.Api
```

A camada **API** será o ponto de entrada HTTP do backend.

Ela será responsável por:

1. receber requisições;
2. validar os dados de entrada quando aplicável;
3. encaminhar a operação para a camada `Application`;
4. transformar o resultado em uma resposta HTTP;
5. retornar a resposta ao cliente.

Exemplo conceitual:

```text
Cliente
   │
   ▼
PriceRadar.Api
   │
   ▼
PriceRadar.Application
   │
   ▼
PriceRadar.Domain
```

A API não deve concentrar regras de negócio.

---

# 🔗 Regra de Dependência

Uma das principais regras da arquitetura é manter as dependências apontando para as camadas internas.

Visão simplificada:

```text
                  ┌───────────────────────┐
                  │    PriceRadar.Api     │
                  └───────────┬───────────┘
                              │
                              ▼
                  ┌───────────────────────┐
                  │ PriceRadar.Application│
                  └───────────┬───────────┘
                              │
                              ▼
                  ┌───────────────────────┐
                  │   PriceRadar.Domain   │
                  └───────────────────────┘
                              ▲
                              │
                  ┌───────────┴───────────┐
                  │PriceRadar.Infrastructure│
                  └───────────────────────┘
```

De forma resumida:

```text
API -------------> Application -------------> Domain
                         ▲
                         │
Infrastructure ----------┘
```

### Dependências permitidas inicialmente

```text
PriceRadar.Application
└── PriceRadar.Domain

PriceRadar.Infrastructure
└── PriceRadar.Application

PriceRadar.Api
└── PriceRadar.Application
```

Essas dependências poderão evoluir conforme a arquitetura for implementada, mas sempre preservando a independência das regras centrais do negócio.

---

# 🚫 O que queremos evitar

Para manter o projeto saudável, devemos evitar:

- regras de negócio dentro de controllers/endpoints;
- `Domain` dependendo de banco de dados;
- acesso direto ao banco pela API;
- classes com muitas responsabilidades;
- dependências circulares;
- código de infraestrutura misturado com regras de negócio;
- credenciais e secrets versionados no Git;
- arquivos gerados por compilação no repositório.

---

# 🧪 Testabilidade

A separação das camadas também permitirá criar testes de forma organizada.

A estrutura prevista é:

```text
tests/
├── PriceRadar.Domain.Tests/
├── PriceRadar.Application.Tests/
├── PriceRadar.Infrastructure.Tests/
└── PriceRadar.Api.Tests/
```

Os projetos de teste serão adicionados conforme o desenvolvimento avançar.

---

# 🗄️ Persistência de Dados

Os detalhes de persistência ficarão isolados na camada:

```text
PriceRadar.Infrastructure
```

O domínio não deverá depender diretamente da tecnologia de banco de dados utilizada.

A documentação específica da modelagem ficará em:

```text
docs/database/
```

---

# 🔐 Segurança

Informações sensíveis não deverão ser armazenadas diretamente no código-fonte ou enviadas ao repositório.

Exemplos:

- senhas;
- tokens;
- chaves de API;
- strings de conexão contendo credenciais;
- secrets de serviços externos.

Configurações sensíveis deverão utilizar mecanismos apropriados de configuração e gerenciamento de secrets.

---

# 📐 Princípios Arquiteturais

Durante o desenvolvimento do PriceRadar, procuraremos seguir estes princípios:

### Separation of Concerns

Cada camada possui responsabilidades bem definidas.

### Dependency Inversion

As regras de negócio não devem depender diretamente das implementações de infraestrutura.

### Single Responsibility

Classes, serviços e componentes devem possuir responsabilidades claras e específicas.

### Testability

As decisões arquiteturais devem facilitar a criação de testes automatizados.

### Maintainability

A estrutura deve facilitar manutenção, evolução e entendimento do projeto.

---

# 🗺️ Evolução da Arquitetura

A arquitetura será documentada progressivamente.

Entre os próximos documentos poderão estar:

```text
docs/architecture/
├── README.md
├── system-context.md
├── container-diagram.md
├── dependency-rules.md
└── decisions/
```

Também poderão ser adicionados **Architecture Decision Records (ADRs)** para registrar decisões técnicas importantes.

Exemplo:

```text
docs/architecture/decisions/
├── ADR-001-clean-architecture.md
├── ADR-002-database.md
└── ADR-003-authentication.md
```

---

# 🎯 Objetivo Arquitetural

A arquitetura do PriceRadar deve permitir que o sistema cresça sem transformar o código em uma estrutura difícil de manter.

Buscamos principalmente:

- baixo acoplamento;
- alta coesão;
- separação clara de responsabilidades;
- facilidade de manutenção;
- facilidade de testes;
- substituição de tecnologias externas com menor impacto;
- organização adequada para crescimento;
- código compreensível para outros desenvolvedores.

---

## 📚 Documentação Relacionada

Conforme o projeto evoluir, a documentação será organizada em:

- `docs/architecture` — arquitetura;
- `docs/database` — banco de dados;
- `docs/requirements` — requisitos.

---

> **Nota:** este documento representa a arquitetura inicial do PriceRadar e será atualizado conforme novas decisões técnicas forem tomadas durante o desenvolvimento.