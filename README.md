TaskFlow
Gerenciador de tarefas (To-Do List) via console, desenvolvido em C# com .NET 10. O projeto tem testes unitários com xUnit e histórico de commits no padrão Conventional Commits.
Funcionalidades
Adicionar tarefas, com validação de título (não aceita título nulo, vazio ou só com espaços).
Listar as tarefas com o status de cada uma (`[ ]` pendente, `[x]` concluída).
Concluir tarefas.
Buscar tarefa por ID, retornando `null` quando ela não existe.
Menu interativo no console.
Requisitos
.NET 10 SDK
Git
Confira a instalação com `dotnet --version` (o resultado deve começar com `10.`).
Estrutura do projeto
```
TaskFlow.slnx
TaskFlow.Console/        -> aplicação console e regras de negócio
    TaskItem.cs          -> entidade de domínio (Id, Title, IsCompleted)
    TaskManager.cs       -> gerenciamento das tarefas em memória
    Program.cs           -> menu interativo
TaskFlow.Tests/          -> testes unitários xUnit
    TaskManagerTests.cs
```
Como compilar
```bash
dotnet restore
dotnet build
```
Como executar
```bash
dotnet run --project TaskFlow.Console
```
O menu exibe as opções:
```
1 - Adicionar tarefa
2 - Listar tarefas
3 - Concluir tarefa
0 - Sair
```
Para concluir uma tarefa, digite o número dela na lista.
Como executar os testes
```bash
dotnet test
```
Os testes cobrem:
adição de tarefa com título válido;
exceção para título nulo, vazio ou só com espaços (`[Theory]`);
remoção de espaços extras do título (`Trim`);
busca por ID com e sem resultado (retorna `null` quando não existe);
conclusão de tarefa existente e inexistente.
