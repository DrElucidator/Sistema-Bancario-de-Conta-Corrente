# Sistema Bancário de Conta Corrente

Este projeto é uma aplicação de console em C# que simula operações básicas de um sistema bancário de conta corrente. Foi desenvolvido como exercício de prática em orientação a objetos em atividade da academia do programador 2026.

## Funcionalidades

- **Criação de contas** com ID aleatório, nome do titular e saldo inicial.
- **Depósito** de valores positivos.
- **Saque** com verificação de saldo disponível.
- **Transferência** entre contas cadastradas.
- **Consulta de saldo** da conta corrente.
- **Menu interativo** para navegação entre opções.

## Estrutura

- **Classe `BankAccount`**  
  Representa uma conta bancária com atributos e métodos para operações financeiras.
  
- **Classe `Program`**  
  Contém o método `Main` e o menu interativo para o usuário realizar operações.

## Como usar

1. Compile e execute o programa.
2. Informe o nome do titular e o saldo inicial da sua conta.
3. Utilize o menu para:
   - Depositar valores
   - Sacar valores
   - Consultar saldo
   - Criar novas contas
   - Transferir valores para outras contas
   - Cancelar a operação e encerrar o programa

## Tecnologias utilizadas

- Linguagem: **C#**
- Biblioteca: **System.Security.Cryptography** (para geração de IDs aleatórios)
- Estruturas: **List\<BankAccount\>** para armazenar contas