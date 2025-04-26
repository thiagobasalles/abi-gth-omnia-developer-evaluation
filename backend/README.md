# 🛠️ Migrations e Atualização do Banco de Dados

Este guia explica como adicionar uma nova migration e atualizar o banco de dados utilizando o Entity Framework Core no Visual Studio com Docker Compose.

## ✅ Pré-requisitos

Antes de executar os comandos abaixo, certifique-se de que:

- Você está utilizando **Visual Studio 2022**.
- O projeto está sendo executado via **Docker Compose** no Visual Studio.
- O projeto **Ambev.DeveloperEvaluation.WebApi** está selecionado como *Startup Project*.
- O console **Gerenciador de Pacotes do NuGet** está aberto.

## 📦 Criar uma Nova Migration

Para criar uma nova migration, execute o comando abaixo no **Console do Gerenciador de Pacotes**:

```powershell
Add-Migration Init -StartupProject Ambev.DeveloperEvaluation.WebApi -Project Ambev.DeveloperEvaluation.ORM -Context DefaultContext
🔁 Substitua Init pelo nome que represente a alteração feita no modelo.

Esse comando irá gerar os arquivos de migration com base nas alterações detectadas no seu modelo de dados.

🧩 Aplicar a Migration no Banco de Dados
Com o projeto Docker Compose rodando (iniciado pelo Visual Studio), execute o comando abaixo no Console do Gerenciador de Pacotes para aplicar a migration ao banco de dados:

powershell
Copiar
Editar
Update-Database -StartupProject Ambev.DeveloperEvaluation.WebApi -Project Ambev.DeveloperEvaluation.ORM -Context DefaultContext
Esse comando aplica todas as migrations pendentes no banco configurado via DefaultContext.

🐳 Dica: Executando com Docker Compose
Lembre-se de que o banco de dados precisa estar rodando antes de aplicar a migration. Para isso:

Inicie o projeto normalmente usando Docker Compose no Visual Studio.

Aguarde até os containers estarem prontos.

Só então execute o Update-Database.