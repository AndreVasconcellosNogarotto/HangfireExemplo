📋 Sobre o Projeto
Este projeto demonstra a implementação e uso do HangFire em uma aplicação .NET Core 7, fornecendo exemplos práticos de processamento de tarefas em background, agendamento de jobs e monitoramento através do dashboard integrado.
HangFire é uma biblioteca open-source que permite executar tarefas em background de forma simples e confiável em aplicações .NET, sem a necessidade de um serviço Windows ou processo separado.
🚀 Tecnologias Utilizadas
Backend

.NET Core 7 - Framework principal da aplicação
C# 11 - Linguagem de programação
ASP.NET Core MVC - Framework web para criação da API/Controllers
HangFire - Biblioteca para processamento de background jobs
Entity Framework Core - ORM para acesso a dados
SQL Server - Banco de dados relacional

Ferramentas

Visual Studio 2022 - IDE de desenvolvimento
Git - Controle de versão
GitHub - Repositório remoto


🏗️ Estrutura do Projeto
HangFireExemplo/
├── 📁 Controllers/           # Controllers da aplicação MVC
│   ├── HomeController.cs     # Controller principal
│   └── JobsController.cs     # Controller para gerenciar jobs
├── 📁 Models/               # Modelos de dados
│   ├── JobModel.cs          # Modelo para representar jobs
│   └── ErrorViewModel.cs    # Modelo para tratamento de erros
├── 📁 Services/             # Serviços de negócio
│   ├── IJobService.cs       # Interface do serviço de jobs
│   ├── JobService.cs        # Implementação do serviço de jobs
│   └── EmailService.cs      # Serviço para envio de emails
├── 📁 Data/                 # Contexto e configurações de dados
│   ├── ApplicationDbContext.cs  # Contexto do Entity Framework
│   └── Migrations/          # Migrações do banco de dados
├── 📁 Views/                # Views do MVC
│   ├── Home/               # Views da Home
│   ├── Jobs/               # Views para gerenciar jobs
│   └── Shared/             # Views compartilhadas
├── 📁 wwwroot/              # Arquivos estáticos (CSS, JS, imagens)
├── 📄 Program.cs            # Ponto de entrada da aplicação
├── 📄 appsettings.json      # Configurações da aplicação
└── 📄 HangFireExemplo.csproj # Arquivo do projeto
⚙️ Funcionalidades Implementadas
1. Jobs em Background

✅ Fire-and-Forget Jobs - Execução única imediata
✅ Delayed Jobs - Execução com atraso específico
✅ Recurring Jobs - Execução recorrente com CRON expressions
✅ Continuations - Jobs que dependem de outros jobs

2. Dashboard de Monitoramento

✅ Interface web integrada para monitoramento
✅ Visualização de jobs em execução, concluídos e falhados
✅ Estatísticas em tempo real
✅ Retry automático de jobs falhados

3. Exemplos Práticos

✅ Envio de emails em background
✅ Processamento de relatórios
✅ Limpeza de dados temporários
✅ Sincronização com APIs externas

🔧 Configuração e Instalação
Pré-requisitos

.NET 7.0 SDK ou superior
SQL Server (LocalDB ou instância completa)
Visual Studio 2022

1. Clone o Repositório
bashgit clone https://github.com/AndreVasconcellosNogarotto/HangfireExemplo.git
cd HangfireExemplo
2. Configurar String de Conexão
Edite o arquivo appsettings.json:
json{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=HangFireExemploDB;Trusted_Connection=true;MultipleActiveResultSets=true"
  },
  "HangFire": {
    "DashboardTitle": "HangFire Dashboard - Exemplo"
  }
}
3. Restaurar Pacotes e Executar Migrações
bash# Restaurar pacotes NuGet
dotnet restore

# Aplicar migrações
dotnet ef database update

# Executar a aplicação
dotnet run
4. Acessar a Aplicação

Aplicação Principal: https://localhost:5001
HangFire Dashboard: https://localhost:5001/hangfire

📚 Como Usar
Criar um Job Fire-and-Forget
csharpBackgroundJob.Enqueue(() => Console.WriteLine("Job executado!"));
Agendar um Job com Delay
csharpBackgroundJob.Schedule(() => EmailService.SendEmail("teste@email.com"), TimeSpan.FromMinutes(5));
Criar um Job Recorrente
csharpRecurringJob.AddOrUpdate("limpeza-diaria", () => LimpezaService.LimparDados(), Cron.Daily);
Job com Continuação
csharpvar jobId = BackgroundJob.Enqueue(() => ProcessarDados());
BackgroundJob.ContinueJobWith(jobId, () => EnviarNotificacao());

🎯 Endpoints da API
Método         Endpoint               Descrição
GET            /                      Página inicial da aplicação
GET            /hangfire              Dashboard do HangFire
POST           /jobs/create-simple    Criar job simples
POST           /jobs/create-delayed   Criar job com delay
POST           /jobs/create-recurring Criar job recorrente
GET            /jobs/status/{id}      Verificar status do job


