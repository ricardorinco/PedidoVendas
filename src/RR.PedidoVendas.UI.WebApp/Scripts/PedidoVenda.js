var _pedidoId = null;

function SalvarPedido() {
    var cliente = $("#ClienteId").val();
    var dataEntrega = $("#DataEntrega").val();

    var token = $('input[name="__RequestVerificationToken"]').val();
    var tokenadr = $('form[action="/Pedido/Create"] input[name="__RequestVerificationToken"]').val();
    var headers = {};
    var headersadr = {};
    headers['__RequestVerificationToken'] = token;
    headersadr['__RequestVerificationToken'] = tokenadr;

    var url = "/Pedido/Create";

    $.ajax({
        url: url,
        type: "POST",
        datatype: "json",
        headers: headersadr,
        data: { Id: 0, ClienteId: cliente, DataEntrega: dataEntrega, __RequestVerificationToken: token },
        success: function (data) {
            if (data.Resultado > 0) {
                ListarItens(data.Resultado);
            }
        }
    });
}

function ListarItens(pedidoId) {
    var url = "/Item/Listar";

    _pedidoId = pedidoId;

    $.ajax({
        url: url,
        type: "GET",
        data: { id: pedidoId },
        datatype: "html",
        success: function (data) {
            var divItens = $("#Itens");
            divItens.empty();
            divItens.show();
            divItens.html(data);
        }
    });
}

function AdicionarItem() {
    var quantidade = $("#Quantidade").val();
    var produtoId = $("#ProdutoId").val();
    var url = "/Item/SalvarItem";

    $.ajax({
        url: url,
        data: { Quantidade: quantidade, ProdutoId: produtoId, PedidoId: _pedidoId },
        type: "GET",
        datatype: "html",
        success: function (data) {
            if (data.Resultado > 0) {
                ListarItens(_pedidoId);
            }
        }
    });
}