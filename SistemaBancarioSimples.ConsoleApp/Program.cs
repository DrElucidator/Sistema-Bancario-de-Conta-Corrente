using System.Security.Cryptography;

int IDNum = RandomNumberGenerator.GetInt32(1, 101);
string Owner = "Nome Exemplo";
decimal BankBalance = 1000;

while (true)
{
    Console.WriteLine($"Conta corrente ID {IDNum} de {Owner}");
    Console.WriteLine("\n1 - Saque\n2 - Depósito\n3 - Consulta de Saldo\nS - Sair");

    string? MenuChoice = Console.ReadLine()?.ToUpper();

    if (MenuChoice == "S")
        break;

    if (MenuChoice == "1")
    {
        Console.Write("Digite o valor que deseja sacar (R$): ");
        decimal Withdraw = Convert.ToDecimal(Console.ReadLine());

        if (Withdraw > 0 && Withdraw <= BankBalance)
        {
            BankBalance -= Withdraw;
            Console.WriteLine("Saque realizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente ou valor inválido!");
        }
    }
    else if (MenuChoice == "2")
    {
        Console.Write("Digite o valor que deseja depositar (R$): ");
        decimal Deposit = Convert.ToDecimal(Console.ReadLine());

        if (Deposit > 0)
        {
            BankBalance += Deposit;
            Console.WriteLine("Depósito realizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Valor inválido para depósito!");
        }
    }
    else if (MenuChoice == "3")
    {
        Console.WriteLine($"Seu saldo é de R$ {BankBalance:F2}");
    }
    else
    {
        Console.WriteLine("Opção inválida!");
    }
}