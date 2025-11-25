# 💰 MyFinances — Sistema de Gestão Financeira Pessoal (Projeto de Estudos)

O **MyFinances** é um projeto pessoal desenvolvido para fins de **estudo e prática** com foco em:
- Arquitetura limpa
- ASP.NET Core + Entity Framework Core
- Autenticação com Identity
- API REST
- Front-end moderno com Angular
- Padrões e boas práticas profissionais

> ⚠️ Este projeto está em desenvolvimento contínuo e será expandido aos poucos conforme novos estudos forem realizados.

---

## 🚀 Tecnologias Utilizadas

### **Back-end**
- ASP.NET Core 8 Web API
- Entity Framework Core 9
- SQL Server
- Identity (Users, Roles, Tokens)
- Lazy Loading Proxies
- Migrations + Fluent API

### **Front-end**
- Angular 17+
- Angular Material
- RxJS
- JWT Authentication (futuro)
- Componentização e boas práticas

### **Arquitetura**
- Domain Driven Design (camadas separadas):
  - `MyFinances.Domain`
  - `MyFinances.Data`
  - `MyFinances.API`
  - `MyFinances.Application` (futuro)

---

## 📂 Estrutura do Projeto

```bash
MyFinances/
│
├── MyFinances.API/             # API (Backend)
├── MyFinances.Data/            # Infraestrutura / Migrations
├── MyFinances.Domain/          # Entidades do Domínio
├── MyFinances.Application/     # (futuro) Regras de Negócio
└── MyFinances.Web/             # (futuro) Projeto Angular

