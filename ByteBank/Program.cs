using System;

namespace ByteBank
{
    public class Program
    {
        static void MostrarMenu()
        {
            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - Quantia armazenada no banco");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Para sair do programa");
            Console.Write("Digite a opção desejada: ");
        }

        static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            cpfs.Add(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Digite o nome do titular: ");
            titulares.Add(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Insira a senha: ");
            senhas.Add(Console.ReadLine());
            saldos.Add(0);
            Console.WriteLine();
        }

        static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<double> saldos, List<string> senhas)
        {
            Console.WriteLine();
            Console.Write("Escreva o CPF do titular que você quer deletar: ");
            string cpfParaDeletar = Console.ReadLine();
            Console.WriteLine();
            int indexParaDeletar = cpfs.FindIndex(cpf => cpf == cpfParaDeletar);
            cpfs.Remove(cpfParaDeletar);

            if (indexParaDeletar == -1)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CPF não encontrado/não foi possível deletar usuário");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("CPF deletado com sucesso!");
                titulares.RemoveAt(indexParaDeletar);
                senhas.RemoveAt(indexParaDeletar);
                saldos.RemoveAt(indexParaDeletar);
            }
        }

        static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {

            for (int i = 0; i < cpfs.Count; i++)
            {
                ApresentaConta(i, cpfs, titulares, saldos);
                Console.WriteLine();
            }
        } 

            static void ApresentarUsuario(List<string> cpfs, List<string> titulares, List<double> saldos)
            {
                Console.Write("Escreva o CPF do titular que você quer pesquisar: ");
                string cpfParaApresentar = Console.ReadLine();
                int indexParaApresentar = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);

                if (indexParaApresentar == -1)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("CPF não encontrado/não foi possível apresentar essa conta");
                    Console.ResetColor();
            }
                else
                {
                    Console.WriteLine();
                    ApresentaConta(indexParaApresentar, cpfs, titulares, saldos);
                    Console.WriteLine();
            }
            }

            static void ApresentarValorTotalNoBanco(List<double> saldos)
            {
                Console.WriteLine();
                Console.WriteLine($"O total acumulado no banco é de: R$ {saldos.Sum():F2}");
                Console.WriteLine();
        }

            static void ApresentaConta(int index, List<string> cpfs, List<string> titulares, List<double> saldos)
            {
                Console.WriteLine();
                Console.WriteLine($"CPF = {cpfs[index]} | Titular = {titulares[index]} | Saldo = R${saldos[index]:F2}");
            }
        

        static void MenuSecundario()
        {
            
            Console.WriteLine("0 - voltar para o menu principal");
            Console.WriteLine("1 - fazer depósito");
            Console.WriteLine("2 - fazer saque");
            Console.WriteLine("3 - fazer transferência");
            Console.WriteLine("4 - sair do programa");
            Console.WriteLine();
            Console.Write("Digite a opção desejada: ");
        }

        static void Deposito(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.WriteLine();
            Console.Write("Digite o CPF para qual você quer depositar:");

            string cpfParaDeposito = Console.ReadLine();
            int indexParaDeposito = cpfs.FindIndex(cpf => cpf == cpfParaDeposito);

            if (indexParaDeposito == -1)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CPF não encontrado/escolha a opção desejada novamente:");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine();
                Console.Write("Digite o valor do depósito: R$");
                double valorDeposito = int.Parse(Console.ReadLine());
                saldos[indexParaDeposito] += valorDeposito;

                Console.WriteLine();
                Console.WriteLine($"Depósito de R$ {valorDeposito:F2} feito com sucesso");
                Console.WriteLine();
                Console.WriteLine($"CPF = {cpfs[indexParaDeposito]} | Titular = {titulares[indexParaDeposito]} | Novo Saldo = R${saldos[indexParaDeposito]:F2}");
                Console.WriteLine();
            }
        }
        
        static void Saque(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.WriteLine();
            Console.Write("Digite o CPF que você quer sacar:");

            string cpfParaSaque = Console.ReadLine();
            int indexParaSaque = cpfs.FindIndex(cpf => cpf == cpfParaSaque);

            if (indexParaSaque == -1)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CPF não encontrado/escolha a opção desejada novamente:");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine();
                Console.Write("Digite o valor do saque: R$");
                double valorSaque = int.Parse(Console.ReadLine());
                saldos[indexParaSaque] -= valorSaque;

                Console.WriteLine();
                Console.WriteLine($"Saque de R$ {valorSaque:F2} feito com sucesso");
                Console.WriteLine();
                Console.WriteLine($"CPF = {cpfs[indexParaSaque]} | Titular = {titulares[indexParaSaque]} | Novo Saldo = R${saldos[indexParaSaque]:F2}");
                Console.WriteLine();
            }
        }

        static void Transferencia(List<string> cpfs, List<string> titulares, List<double> saldos)
            {
            Console.WriteLine();
            Console.Write("Digite o CPF da conta que vai Transferir:");

            string cpfEnviaTrasferencia = Console.ReadLine();
            int indexEnviaTransferencia = cpfs.FindIndex(cpf => cpf == cpfEnviaTrasferencia);

            Console.WriteLine();
            Console.Write("Digite o CPF da conta que vai receber a Transferência:");

            string cpfRecebeTrasferencia = Console.ReadLine();
            int indexRecebeTransferencia = cpfs.FindIndex(cpf => cpf == cpfRecebeTrasferencia);


            if (indexEnviaTransferencia == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CPF não encontrado/escolha a opção desajada novamente:");
                Console.ResetColor();
            }
            else if (indexEnviaTransferencia == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CPF não encontrado/escolha a opção desajada novamente:");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine();
                Console.Write("Digite o valor da transferência: R$");
                double valorTransferencia = int.Parse(Console.ReadLine());
                saldos[indexEnviaTransferencia] -= valorTransferencia;
                saldos[indexRecebeTransferencia] += valorTransferencia;

                Console.WriteLine();
                Console.WriteLine($"Transferência de R$ {valorTransferencia:F2} feito com sucesso");
            }

            Console.WriteLine();
            Console.WriteLine("status de quem enviou");
            Console.WriteLine($"CPF = {cpfs[indexEnviaTransferencia]} | Titular = {titulares[indexEnviaTransferencia]} | Novo Saldo = R${saldos[indexEnviaTransferencia]:F2}");
            Console.WriteLine();
            Console.WriteLine("status de quem recebeu");
            Console.WriteLine($"CPF = {cpfs[indexRecebeTransferencia]} | Titular = {titulares[indexRecebeTransferencia]} | Novo Saldo = R${saldos[indexRecebeTransferencia]:F2}");
            Console.WriteLine();

        }
        

        public static void Main(string[] args)
        {

            Console.WriteLine("Escolha a ação desejada: ");

            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();

            int opcao;
            int opcaoSubMenu;

            do
            {
                MostrarMenu();
                opcao = int.Parse(Console.ReadLine());
                
                Console.WriteLine("-----------------");

                switch (opcao)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Finalizando programa...");
                        Console.ResetColor();
                        break;
                    case 1:
                        RegistrarNovoUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 2:
                        DeletarUsuario(cpfs, titulares, saldos, senhas);
                        break;
                    case 3:
                        ListarTodasAsContas(cpfs, titulares, saldos);
                        break;
                    case 4:
                        ApresentarUsuario(cpfs, titulares, saldos);
                        break;
                    case 5:
                        ApresentarValorTotalNoBanco(saldos);
                        break;
                    case 6:
                        do
                        {
                            MenuSecundario();
                            opcaoSubMenu = int.Parse(Console.ReadLine());
                            Console.WriteLine("-----------------");

                            switch (opcaoSubMenu)
                            {
                                case 1:
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Deposito(cpfs, titulares, saldos);
                                    Console.ResetColor();
                                    break;
                                case 2:
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Saque(cpfs, titulares, saldos);
                                    Console.ResetColor();
                                    break;
                                case 3:
                                    Console.ForegroundColor = ConsoleColor.Blue; 
                                    Transferencia(cpfs, titulares, saldos);
                                    Console.ResetColor();
                                    break;
                                case 4:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Finalizando o programa");
                                    Console.ResetColor();
                                    return;
                            }
                        } while (opcaoSubMenu != 0);
                        break;
                }
            }
            while (opcao != 0);
        }

    }
}
