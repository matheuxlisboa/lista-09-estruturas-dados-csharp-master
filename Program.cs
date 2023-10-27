using System.Collections;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("Escolha um exemplo para visualizar:");
            Console.WriteLine("1. Sistema de CPF e Telefone");
            Console.WriteLine("2. Sistema de Carrinho de Compras");
            Console.WriteLine("3. Sair");
            Console.Write("Opção: ");

            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) continue;

            int option;
            if (!int.TryParse(input, out option)) continue;

            switch (option)
            {
                case 1:
                    CpfPhoneSystem();
                    break;
                case 2:
                    ShoppingCartSystem();
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    static void CpfPhoneSystem()
    {
        Hashtable cpfPhone = new Hashtable();

        for (int i = 0; i < 5; i++)
        {
            Console.Write("Digite o CPF: ");
            string cpf = Console.ReadLine();
            if (string.IsNullOrEmpty(cpf)) continue;

            Console.Write("Digite o telefone: ");
            string phone = Console.ReadLine();
            if (string.IsNullOrEmpty(phone)) continue;

            cpfPhone[cpf] = phone;
        }

        Console.WriteLine("\nDados armazenados:");
        foreach (DictionaryEntry entry in cpfPhone)
        {
            Console.WriteLine($"CPF: {entry.Key}, Telefone: {entry.Value}");
        }

        while (true)
        {
            Console.Write("Deseja pesquisar um telefone por CPF? (s/n): ");
            string answer = Console.ReadLine().ToLower();
            if (string.IsNullOrEmpty(answer)) continue;

            if (answer == "n")
            {
                break;
            }
            else if (answer == "s")
            {
                Console.Write("Digite o CPF para pesquisa: ");
                string cpf = Console.ReadLine();
                if (string.IsNullOrEmpty(cpf)) continue;

                if (cpfPhone.ContainsKey(cpf))
                {
                    Console.WriteLine($"Telefone: {cpfPhone[cpf]}");
                }
                else
                {
                    Console.WriteLine("CPF não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Resposta inválida.");
            }
        }
    }

    static void ShoppingCartSystem()
    {
        Hashtable cart = new Hashtable();
        decimal total = 0;

        while (true)
        {
            Console.WriteLine("Sistema de Carrinho de Compras");
            Console.WriteLine("1. Adicionar produto");
            Console.WriteLine("2. Visualizar carrinho");
            Console.WriteLine("3. Finalizar compra");
            Console.WriteLine("4. Sair");
            Console.Write("Opção: ");

            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) continue;

            int option;
            if (!int.TryParse(input, out option)) continue;

            switch (option)
            {
                case 1:
                    Console.Write("Nome do produto: ");
                    string productName = Console.ReadLine();
                    if (string.IsNullOrEmpty(productName)) continue;

                    Console.Write("Preço do produto: ");
                    string priceInput = Console.ReadLine();
                    decimal productPrice;
                    if (!decimal.TryParse(priceInput, out productPrice)) continue;

                    cart[productName] = productPrice;
                    break;
                case 2:
                    Console.WriteLine("Produtos no carrinho:");
                    foreach (DictionaryEntry entry in cart)
                    {
                        Console.WriteLine($"Produto: {entry.Key}, Preço: {entry.Value}");
                    }
                    break;
                case 3:
                    foreach (DictionaryEntry entry in cart)
                    {
                        total += (decimal)entry.Value;
                    }

                    Console.WriteLine($"Valor total a ser pago: {total:C2}");
                    cart.Clear();
                    total = 0;
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}
