
//Function para gerencia a postagem de um imagem, essa funtion é executada quando que a janela é carregada
$(function () {

    //ID do input que enviara os dados do formulario para o controler
    var $IdBotaoEnviar = $("#desabilitarBTN");

    //ID da div que recebera as DIVs e class de Erros
    var $IdErro = $("#MensagemErro");

    //ID do input que recebera o imagem
    var $IdInput = $("#imgInp");

    //Funtion que deve ser executada quando que a janela é carregada
    ExeAoCarregaJanela();

    function ExeAoCarregaJanela() {
        ErrosInput();
        $IdInput.change(function () {
            ErrosInput();
            VerificarErro();
        });
        $IdBotaoEnviar.attr('disabled', 'disabled');
    }

    $("#btnArquivoAtual").click(function (e) {
        e.preventDefault();
        el = $(this).data('element');
        $(el).toggle('slow');
        $("#AtualAnexo").toggle('slow');
        $("#btnArquivoNovo").removeAttr('disabled', 'disabled');
        $("#btnArquivoAtual").attr('disabled', 'disabled');
        $("#imgInp").replaceWith($("#imgInp").val(''));
    });

    $("#btnArquivoNovo").click(function (e) {
        e.preventDefault();
        el = $(this).data('element');
        $(el).toggle('slow');
        $("#novoAnexo").toggle('slow');
        $("#btnArquivoAtual").removeAttr('disabled', 'disabled');
        $("#btnArquivoNovo").attr('disabled', 'disabled');
        ErrosInput();
    });

    //Function para adicionar e remover mensagens de erro Sobre o input de imagem
    function ErrosInput() {
        LimpaMensagensNoDom();
        var quantidade = $IdInput.get(0).files.length;
        function LimpaMensagensNoDom() {
            $(".deletarMensagemErro")
                .hide('slow', function () {
                    $(this).remove();
                });
            $IdErro.removeClass("oErroTipoExiste oErroTamanhoExiste");
            $IdErro.removeClass("MensagemErro");
        }
        //verificar a quantidade de imagems colocadas
        if (quantidade === 1) {
            $("#img-upload").show();

            var arr = $IdInput.get(0).files;
            var tamanhoArqs = 0;
            $.each(arr, function (pos, imagem) {
                var tipo = imagem.name.split('.').slice(-1)[0];
                var nomeimagem = imagem.name;
                if (!((tipo === "png") || (tipo === "gif") || (tipo === "jpg") || (tipo === "jpeg")) && (!$IdErro.hasClass("oErroTipoExiste"))) {
                    $IdErro
                        .append($("<div />")
                            .addClass("deletarMensagemErro")
                            .append("<i class='fa fa-times-circle-o'></i> Erro, só é possivel enviar imagens do tipo PNG, JPG, JPEG e GIF").css({ "font-size": "120%", "color": "#dd4b39", "font-weight": "700" }))
                        .addClass("MensagemErro oErroTipoExiste");
                }
            });
            $.each(arr, function (pos, imagem) {
                var tamanhoArq = imagem.size;
                tamanhoArqs += tamanhoArq;
                console.log(tamanhoArqs);
                //verifica o tamanho 
                if (tamanhoArqs > 1000000000 && (!$IdErro.hasClass("oErroTamanhoExiste"))) {
                    $IdErro
                        .append($("<div />")
                            .addClass("deletarMensagemErro")
                            .append("<i class='fa fa-times-circle-o'></i> Erro, Aquivo maior que 1 Gb (Gigabyte)!").css({ "font-size": "120%", "color": "#dd4b39", "font-weight": "700" }))
                        .addClass("MensagemErro oErroTamanhoExiste");

                }
            });
        }

        //Verificar se há um imagem para ser Enviado
        else {
            $("#img-upload").hide(function () {
                $("#nameAnexo").replaceWith($("#nameAnexo").val(''));
            });

            $IdErro
                .append($("<div />")
                    .addClass("deletarMensagemErro")
                    .append("<i class='fa fa-bell-o'></i> Coloque uma imagem").css({ "font-size": "120%", "color": "#f39c12", "font-weight": "700" }))
                .addClass("MensagemErro");
        }
    }

    //Function para verificar se existe uma mensagem de Erro
    function VerificarErro() {
        //Se não ouver erro abilitar botao criar novo formulario
        if (!$IdErro.hasClass("MensagemErro")) {
            $IdBotaoEnviar.removeAttr('disabled', 'disabled');
        }
        //Se ouver erro desabilitar botao criar novo formulario
        else {
            $IdBotaoEnviar.attr('disabled', 'disabled');
        }
    }
});
function chamaModal() {
    $("#ModalDeletar").modal("show");
}
function FecharModal() {
    $("#ModalDeletar").modal("hide");
    $(".modal-backdrop").removeClass("modal-backdrop fade in");
    $(".skin-blue").removeClass("modal-open").removeAttr("style", "padding-right");
    window.location = "http://localhost:56530/Noticia";
}