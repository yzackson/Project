using System;

class CadastroCliente {
    string nome, sexo, endereco;
    int idade;
    
    public CadastroCliente () {
        nome = "Cliente";
        sexo = "F"; 
        idade = 35;
        endereco = "Rua dos Palmares";
    }
    // Construtor do cadastro do cliente
    public CadastroCliente (string NomeDoCliente, string SexoDoCliente, int IdadeDoCliente, string EnderecoDoCliente) {
        nome = NomeDoCliente;
        sexo = SexoDoCliente; 
        idade = IdadeDoCliente;
        endereco = EnderecoDoCliente;
    }

    //GET info cliente
    public string GetNome () {
        return nome; 
    }
    public string GetSexo () {
        return sexo; 
    }
    public int GetIdade () {
        return idade; 
    }
    public string GetEndereco () {
        return endereco; 
    }
}
