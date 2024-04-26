# Sistema de Agenda ASP.NET MVC

Este é um sistema de agenda desenvolvido em C# ASP.NET MVC utilizando o padrão de design Domain-Driven Design (DDD). O sistema é dividido em cinco projetos principais: MVC, API, Domain, Infrastructure e Tests.

## Estrutura do Projeto

1. **MVC**: Este projeto contém a camada de apresentação da aplicação, incluindo os controladores, visualizações e modelos de exibição. Ele se comunica com a camada de serviço (API) para manipulação de dados e regras de negócio.

2. **API**: O projeto API é responsável por fornecer endpoints RESTful para interação com a aplicação. Ele abstrai as operações de negócio e se comunica com o serviço de domínio para executar as operações solicitadas.

3. **Domain**: O projeto Domain é o núcleo da aplicação, onde as entidades de domínio, serviços e regras de negócio residem. Ele é independente da infraestrutura e das camadas de apresentação e serviço.

4. **Infrastructure**: Este projeto contém implementações concretas de interfaces definidas no projeto de domínio. Isso inclui acesso a dados, serviços de terceiros, serviços de e-mail, entre outros. Ele é responsável por fornecer as implementações específicas necessárias para a aplicação funcionar corretamente.

5. **Tests**: O projeto de teste contém testes automatizados para validar o comportamento do sistema. Utiliza a estrutura XUnit para escrever e executar testes unitários e de integração.

## Pré-requisitos

Certifique-se de ter os seguintes itens instalados em seu ambiente de desenvolvimento:

- Visual Studio ou Visual Studio Code
- .NET Core SDK
- SQL Server (ou outro banco de dados compatível)

## Configuração

1. Clone o repositório em sua máquina local.
2. Abra a solução no Visual Studio ou Visual Studio Code.
3. Verifique e ajuste a string de conexão com o banco de dados no arquivo `appsettings.json` do projeto `Infrastructure`.
4. Execute o comando `dotnet ef database update` no console do gerenciador de pacotes para criar o banco de dados e aplicar as migrações.
5. Inicie a aplicação.

## Executando a Aplicação

Para executar a aplicação, siga estas etapas:

1. Pressione F5 no Visual Studio ou execute `dotnet run` no terminal dentro da pasta do projeto MVC.
2. Abra um navegador da web e acesse a URL `http://localhost:<porta>`.

## Executando Testes

Para executar os testes, siga estas etapas:

1. Navegue até a pasta do projeto Tests.
2. Execute o comando `dotnet test` no terminal para executar todos os testes.
3. Analise os resultados dos testes exibidos no terminal.
