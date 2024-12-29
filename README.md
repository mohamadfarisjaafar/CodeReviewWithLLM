# Code Review Tool with LLM Integration

This project is a simple Code Review Tool that uses a Large Language Model (LLM), like OpenAI's GPT-4, to assist in reviewing code for:

- **Coding standards** (e.g., naming conventions, indentation)
- **Bug detection** (e.g., logical errors, runtime issues)
- **Optimization suggestions** (e.g., performance improvements)
- **Security review** (e.g., SQL injection, XSS vulnerabilities)
- **Documentation review** (e.g., missing comments, unclear function names)

### Project Architecture

The project is divided into three main components:

1. **Frontend (Vue.js)**: A user interface for users to input their code and receive the code review feedback.
2. **Backend (Node.js)**: A server that acts as a gateway, forwarding code to the .NET Core engine for processing.
3. **Engine (.NET Core)**: A server that integrates with the LLM API to analyze the submitted code and return feedback.

### Prerequisites

Before you begin, ensure you have the following installed:

- **Node.js** (for backend and frontend)
- **.NET Core SDK** (for the engine)
- **Vue CLI** (for Vue.js frontend)
- **OpenAI API Key** (or another LLM provider key)

### Setup Instructions

Follow the steps below to set up each part of the application.

---

## 1. Frontend Setup (Vue.js)

### 1.1 Install Vue.js

First, make sure you have **Vue CLI** installed globally:

```bash
npm install -g @vue/cli
