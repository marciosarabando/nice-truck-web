# Nice-Truck-Web

Pré-Requisito

- Sdk .Net Core: 5.0.302

Execução:

- Clonar o projeto em um diretório local
- Acessar pelo terminal o diretório da aplicação web: /NiceTruck.Web
- Executar o comando "dotnet run"
- Acessar o sistema pela url local: https://localhost:5001/

Requisito principal
Como usuário, eu necessito de um cadastro de caminhões, onde eu possa:

- Visualizar os caminhões cadastrados;
- As propriedades mínimas do caminhão deverão ser:
- Modelo (Poderá aceitar apenas FH e FM)
- Ano de Fabricação (Ano deverá ser o atual)
- Ano Modelo (Poderá ser o atual ou o ano subsequente)
- Atualizar as informações de um caminhão;
- Excluir um caminhão;
- Inserir um novo caminhão.

Requisito secundário
Poderão existir vários modelos de caminhões.

- Os modelos permitidos serão somente (FH e FM)

Requisitos técnicos

- Utilizar ASP.NET Core;
- Utilizar base de dados local;
- Utilizar ORM para mapear as tabelas de base de dados
- Utilizar “Migrations” para criação da base de dados;
- A criação da base de dados deverá ser automática (sem a necessidade de utilizar algum
  comando adicional).
- Criar testes unitários (Cobrir ao menos 80% dos fluxos)

Importante!
O código fonte deverá ser disponibilizado no GitHub como um repositório público do próprio candidato. O código deverá conter todas as instruções para que o mesmo possa ser executado.
A prova será desqualificada caso os respectivos testes não possam ser executados por falta de documentação.
