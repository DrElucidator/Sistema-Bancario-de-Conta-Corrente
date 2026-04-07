using System;
using System.Collections.Generic;
using System.Security.Cryptography;

class BankAccount
{
    public int IDNum { get; private set; }
    public string Owner { get; set; }
    public decimal BankBalance { get; private set; }

    public BankAccount(string owner, decimal initialBalance)
    {
        IDNum = RandomNumberGenerator.GetInt32(1, 101);
        Owner = owner;
        BankBalance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            BankBalance += amount;
            Console.WriteLine($"Depósito de R${amount} realizado. Saldo atual: R${BankBalance:F2}");
        }
        else
        {
            Console.WriteLine("Valor inválido para depósito.");
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= BankBalance)
        {
            BankBalance -= amount;
            Console.WriteLine($"Saque de R${amount} realizado. Saldo atual: R${BankBalance:F2}");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente ou valor inválido!");
        }
    }

    public void Transfer(BankAccount destination, decimal amount)
    {
        if (amount > 0 && amount <= BankBalance)
        {
            BankBalance -= amount;
            destination.BankBalance += amount;
            Console.WriteLine($"Transferência de R${amount} para {destination.Owner} realizada.");
            Console.WriteLine($"Saldo atual da conta destino ({destination.Owner}): R${destination.BankBalance:F2}");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente ou valor inválido!");
        }
    }

    public void ShowBalance()
    {
        Console.WriteLine($"Saldo da conta de {Owner} (ID {IDNum}): R${BankBalance:F2}");
    }
}
class Program
{
    static void Main()
    {
        BankAccount joao = new BankAccount("João", 1500m);
        BankAccount josiane = new BankAccount("Josiane", 1200m);

        List<BankAccount> accounts = new List<BankAccount> { joao, josiane };

        Console.Write("Digite o nome do titular da sua conta: ");
        string userOwner = Console.ReadLine();
        Console.Write("Digite o saldo inicial: ");
        decimal userBalance = Convert.ToDecimal(Console.ReadLine());

        BankAccount userAccount = new BankAccount(userOwner, userBalance);
        accounts.Add(userAccount);

        int menuChoice;
        do
        {
            Console.WriteLine($"\nConta corrente ID {userAccount.IDNum} de {userAccount.Owner}");
            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Consultar Saldo");
            Console.WriteLine("4 - Criar nova conta");
            Console.WriteLine("5 - Transferir");
            Console.WriteLine("6 - Cancelar");
            Console.Write("Escolha uma opção: ");

            bool validOption = int.TryParse(Console.ReadLine(), out menuChoice);

            if (!validOption || menuChoice < 1 || menuChoice > 6)
            {
                Console.WriteLine("Opção inválida! Tente novamente.");
                continue;
            }

            switch (menuChoice)
            {
                case 1:
                    Console.Write("Valor do depósito: ");
                    decimal dep = Convert.ToDecimal(Console.ReadLine());
                    userAccount.Deposit(dep);
                    break;
                case 2:
                    Console.Write("Valor do saque: ");
                    decimal saque = Convert.ToDecimal(Console.ReadLine());
                    userAccount.Withdraw(saque);
                    break;
                case 3:
                    userAccount.ShowBalance();
                    break;
                case 4:
                    Console.Write("Nome do titular: ");
                    string newOwner = Console.ReadLine();
                    Console.Write("Saldo inicial: ");
                    decimal initialBalance = Convert.ToDecimal(Console.ReadLine());
                    accounts.Add(new BankAccount(newOwner, initialBalance));
                    Console.WriteLine("Nova conta criada com sucesso!");
                    break;
                case 5:
                    Console.WriteLine("Contas disponíveis para transferência:");
                    for (int i = 0; i < accounts.Count; i++)
                    {
                        if (accounts[i].IDNum != userAccount.IDNum)
                            Console.WriteLine($"ID {accounts[i].IDNum} - {accounts[i].Owner}");
                    }

                    Console.Write("Digite o ID da conta destino: ");
                    bool validId = int.TryParse(Console.ReadLine(), out int idDestino);
                    if (!validId)
                    {
                        Console.WriteLine("ID inválido! Tente novamente.");
                        break;
                    }

                    BankAccount destino = accounts.Find(a => a.IDNum == idDestino);

                    if (destino == null)
                    {
                        Console.WriteLine("Conta destino não encontrada! Tente novamente.");
                        break;
                    }

                    Console.Write("Valor da transferência: ");
                    decimal transf = Convert.ToDecimal(Console.ReadLine());
                    userAccount.Transfer(destino, transf);
                    break;
                case 6:
                    Console.WriteLine("Operação cancelada.");
                    break;
            }

        } while (menuChoice != 6);
    }
}