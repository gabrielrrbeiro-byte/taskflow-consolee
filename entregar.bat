@echo off
if not exist TaskFlow.slnx if not exist TaskFlow.sln (
  echo ERRO: rode este arquivo dentro da pasta taskflow-console.
  pause
  exit /b 1
)
if not exist TaskManager_bug.cs (
  echo ERRO: faltam os arquivos .cs e README.md nesta pasta.
  pause
  exit /b 1
)

echo === Tarefa C ===
copy /Y TaskItem.cs TaskFlow.Console\TaskItem.cs >nul
git add TaskFlow.Console\TaskItem.cs
git commit -m "feat(domain): implement TaskItem entity with completion logic"

echo === Tarefa D ===
copy /Y TaskManager_bug.cs TaskFlow.Console\TaskManager.cs >nul
git add TaskFlow.Console\TaskManager.cs
git commit -m "feat(services): implement TaskManager logic for in memory task management"

echo === Tarefa E ===
copy /Y TaskManagerTests.cs TaskFlow.Tests\TaskManagerTests.cs >nul
git add TaskFlow.Tests\TaskManagerTests.cs
git commit -m "test(unit): add xUnit test suite for TaskManager validation rules"

echo === Tarefa F ===
copy /Y TaskManager.cs TaskFlow.Console\TaskManager.cs >nul
git add TaskFlow.Console\TaskManager.cs
git commit -m "fix(manager): handle missing task gracefully in search method"

echo === Tarefa G ===
copy /Y Program.cs TaskFlow.Console\Program.cs >nul
git add TaskFlow.Console\Program.cs
git commit -m "refactor(console): implement interactive menu loop in Program.cs"

echo === Tarefa H ===
git add README.md
git commit -m "docs(readme): add build, run and test instructions"

echo === Testes ===
dotnet test

echo === Historico ===
git log --oneline --graph

echo === Enviando para o GitHub ===
git push -u origin main

echo.
echo Pronto! Confira: https://github.com/gabrielrrbeiro-byte/taskflow-console
pause
