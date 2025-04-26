# 🧾 Documentação - Configuração e Uso da Aplicação

## 🐳 Execução com Docker Compose

Esta aplicação utiliza **Docker Compose** e deve ser iniciada diretamente pelo **Visual Studio 2022**.

### Passos para iniciar o projeto:

1. Abra a solução no **Visual Studio 2022**.
2. Defina o projeto `docker-compose` como **Startup Project**.
3. Inicie a aplicação (F5 ou Ctrl + F5) e aguarde os containers estarem prontos.

---

## 🧬 Gerenciando Migrations (EF Core)

Para adicionar e aplicar migrations ao banco de dados usando o **Entity Framework Core**, siga os passos abaixo.

### ✅ Criar uma nova migration

Abra o **Console do Gerenciador de Pacotes** e execute:

```powershell
Add-Migration Init -StartupProject Ambev.DeveloperEvaluation.WebApi -Project Ambev.DeveloperEvaluation.ORM -Context DefaultContext
Substitua Init pelo nome descritivo da migration.

🚀 Aplicar a migration no banco de dados
Com o Docker Compose rodando, execute:

powershell
Copiar
Editar
Update-Database -StartupProject Ambev.DeveloperEvaluation.WebApi -Project Ambev.DeveloperEvaluation.ORM -Context DefaultContext
Isso aplicará a migration atual no banco de dados containerizado.

📫 Testando a API com Postman
O arquivo Ambev.postman_collection.json pode ser importado no Postman para facilitar o teste dos endpoints da API.

Como usar:
Abra o Postman.

Clique em Import > selecione o arquivo Ambev.postman_collection.json.

Use os endpoints disponíveis para interagir com a API.

🛠️ Requisitos
Visual Studio 2022

Docker Desktop

.NET SDK 8.0+

Postman (opcional, mas recomendado)

