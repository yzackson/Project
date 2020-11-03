using System;
using System.Collections.Generic;


class MainClass {
  public static void Main (string[] args) {

    int confirmacao;
    string nome, sexo, endereco;
    int idade;

    Console.WriteLine (" --------UCL MARKET-------- ");
    Console.WriteLine("Para dar inicio a nossa loja vamos realizar o seu cadastro.\n");
    
    // Colhendo informações do cliente
    do {
      Console.Write("Digite seu nome: ");
      nome = Console.ReadLine();
      Console.Write("Olá {0}, digite seu sexo: ", nome);
      sexo = Console.ReadLine();
      Console.Write("Digite sua idade: ");
      idade = int.Parse(Console.ReadLine());
      Console.Write("Digite seu Endereço: ");
      endereco = Console.ReadLine();

      Console.WriteLine("\n\nOs dados cadastrados são:\nNome: {0}\nSexo: {1}\nIdade: {2}\nEndereço: {3}", nome, sexo, idade, endereco);
      Console.WriteLine("\nConfirma os dados? Digite \"1\" para Sim ou \"2\" para Não");
      confirmacao = int.Parse(Console.ReadLine());

    } while (confirmacao != 1);
    
    //Instanciando Cliente
    CadastroCliente Cliente = new CadastroCliente(nome, sexo, idade, endereco );
   
    Console.WriteLine("Cadastro realizado com sucesso!\n");
    Console.Clear();
    Console.WriteLine("\n======== Produtos disponíveis ========\n");

    //Instanciando estoque
    Estoque Produtos = new Estoque();

    //Chamando métodos da classe Produtos
    Produtos.mostraTabela();
    //Produtos.GetDescricao();

    Carrinho carrinho = new Carrinho();
    
    string prox = "s";
    int i, quant;
    double valorTotal = 0.0;

    while (prox != "n" || prox !="N") {
      //Produtos.mostraTabela();
      Console.Write("\nID do produto: ");
      i = int.Parse(Console.ReadLine()); //Pegar o indice do produto
      
      if (i >= 50) {
          Console.WriteLine("\nERRO!!! Digite um ID válido!");
          //Volta a primeira opção!
          continue;

      
      } else {
        Console.Write("Quantidade: ");
        quant = int.Parse(Console.ReadLine());
          
          if (quant > Produtos.Quantidade[i]) { 
            if (quant >= 51) {
                Console.WriteLine("\n Maximo de produtos do estoque atingido  \n");
            } else if(Produtos.Quantidade[i] == 0 ) {
                Console.WriteLine("\n O produto {0} não está mais disponível no estoque! \n", Produtos.GetDescricao()[i]);
            } else {
                continue;
            }
          
          } else {
            Produtos.Quantidade[i] -= quant;
            Console.WriteLine("\n✓ Item adicionado ao carrinho. ✓\n");


            carrinho.SetCarrinhoProdutos(i);
            carrinho.SetCarrinhoQuanti(quant);
            carrinho.SetCarrinhoValor(Produtos.GetValor()[i]);
            
            Console.WriteLine("Carrinho:\n   Produto: {0}\n   Quantidade: {1}\n   Valor: {2}\n   Total: {3}", Produtos.GetDescricao()[i], quant, Produtos.GetValor()[i],quant* Produtos.GetValor()[i]);
            Console.WriteLine("-----------------------------------------------");
            valorTotal = (quant*Produtos.GetValor()[i]) + valorTotal;
            }
           
            
          Console.WriteLine("Continuar comprando? [s/n]: ");
          Console.WriteLine("-----------------------------------------------");
          prox = Console.ReadLine();
          if (prox == "s" || prox =="S") {
              continue;
          } else {
              Console.WriteLine("O valor total do seu carrinho é de: {0}\n", valorTotal);
              break;
          }

        }
    }
    int opcao, metodo;
    Console.WriteLine("O que deseja fazer agora? ");
    Console.WriteLine("[ 1 ] - Fechar Compra");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("➜ Seu total foi de: {0} ", valorTotal);
    opcao = int.Parse(Console.ReadLine());
    if (opcao == 1) {
        Console.Write("Escolha o método de Pagamento:\n[ 1 ] -Cartão de crédito\n[ 2 ] - Cartão de Debito\n[ 3 ] - À vista\n➜ ");
        metodo = int.Parse(Console.ReadLine());
        if (metodo == 1 ) {
          Console.WriteLine("Pagamento no crédito escolhido/ \n Finalizando pedido...\n Volte sempre, obrigado!");
          }
        else if (metodo == 2 ) {
          Console.WriteLine("Pagamento no débito escolhido/ \n Finalizando pedido...\n Volte sempre, obrigado!");
          }
        else if (metodo == 3 ) {
        Console.WriteLine("Pagamento à vista escolhido/ \n Finalizando pedido...\n Volte sempre, obrigado!");
        }
        else {
          Console.WriteLine("Opção inválida!");
        }
    } else {
        Console.WriteLine("Saindo da loja...");
        Console.ReadKey();
    }

  }

}
