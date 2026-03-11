🚀 Enterprise RESTful API Ecosystem

Este projeto é uma implementação completa de uma API RESTful de nível empresarial, desenvolvida durante minha especialização prática em arquitetura de microsserviços e nuvem. O foco principal é a criação de um ecossistema escalável, seguindo os mais altos padrões de maturidade e integração contínua.
🛠️ Tecnologias e Arquitetura

O projeto foi construído utilizando uma abordagem 90% prática, focada em:

    Core: ASP.NET Core com C# (Arquitetura em Camadas).

    API Excellence: Implementação do Modelo de Maturidade de Richardson (Nível 3) com suporte total a HATEOAS.

    Segurança: Autenticação e Autorização via JWT (JSON Web Tokens).

    Data & Migrations: SQL Server com gerenciamento de versões via Migrations.

    Documentação: Swagger (OpenAPI) para especificações técnicas.

    Cloud & DevOps: Deploy automatizado na Azure (App Services, Container Registry) via GitHub Actions (CI/CD).

    Modern Features: Versionamento de API, Paginação, Content Negotiation e Upload/Download de arquivos.

🧠 Diferenciais Implementados (Hands-on)

Além do desenvolvimento do CRUD tradicional, este repositório explora conceitos avançados:

    Containerização: Docker & Docker Compose para orquestração local.

    Cloud Native: Introdução ao Kubernetes (K8s) para escalabilidade.

    Integrações: Consumo de APIs de terceiros e integração experimental com ChatGPT API.

    Frontend Sync: Integração completa com um client em React JS.

🏗️ Estrutura do Projeto
Bash

├── src/
│   ├── API/             # Camada de entrada, Controllers e Configurações
│   ├── Business/        # Regras de negócio e Interfaces
│   ├── Repository/      # Acesso a dados e Contexto do Banco
│   └── Data/            # Migrations e Scripts SQL
├── docker-compose.yml   # Orquestração de containers
└── .github/workflows/   # Pipelines de CI/CD para Azure

🚀 Como Executar

    Clone o repositório:
    Bash

    git clone https://github.com/evandson-costa/nome-do-projeto.git

    Configure o Banco de Dados:
    Ajuste a ConnectionString no appsettings.json ou utilize o Docker.

    Execute via CLI:
    Bash

    dotnet restore
    dotnet run

    Acesse o Swagger: http://localhost:port/swagger
