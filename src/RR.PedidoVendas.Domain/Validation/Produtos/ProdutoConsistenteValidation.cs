﻿using DomainValidation.Validation;
using RR.PedidoVendas.Domain.Models;
using RR.PedidoVendas.Domain.Specification.Produtos;

namespace RR.PedidoVendas.Domain.Validation.Produtos
{
    public class ProdutoConsistenteValidation : Validator<Produto>
    {
        public ProdutoConsistenteValidation()
        {
            var produtoDescricaoMaiorQueValida = new ProdutoDescricaoMaiorQueValidaSpecification();
            var produtoValorMaiorQueValido = new ProdutoValorMaiorQueValidoSpecification();

            Add("produtoDescricaoMaiorQueValida", new Rule<Produto>(produtoDescricaoMaiorQueValida, "A descrição do produto deve conter no mínimo 3 caracteres."));
            Add("produtoValorMaiorQueValido", new Rule<Produto>(produtoValorMaiorQueValido, "O valor do produto deve ser maior que R$ -0.01."));
        }
    }
}
