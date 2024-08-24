//const imagens = ["imagens/FotosLocais/CasaEmPontalina.png", "imagens/FotosLocais/CasaResidencialGaravelo.png"]
//const legendas = ["EXCELENTE CASA EM PONTALINA - GOIÁS A casa é linda e possui 3 quartos, sendo 1 suíte; 1 banheiro social; sala; cozinha/copa...", "CASA POPULAR COM EXCELENTE PONTO COMERCIAL À VENDA NO RESIDENCIAL GARAVELO PARK. A casa é localizada em frente a uma escola..."]
//intervalo = 6000

//const elementoImagem = document.getElementById('imagem')
//const elementoLegenda = document.getElementById('legenda')
//let i = 0

//function trocarImagem() {
//    elementoImagem.style.opacity = 0
//    elementoLegenda.style.opacity = 0



//    setTimeout(function () {
//        elementoImagem.src = imagens[i]
//        elementoLegenda.textContent = legendas[i]

//        elementoImagem.style.opacity = 1
//        elementoLegenda.style.opacity = 1
//    }, 1500)

//    i = (i + 1) % imagens.length
//}

//setInterval(trocarImagem, intervalo)

function AbreMenu() {
    document.getElementById("MenuOculto").style.height = "4rem"
    document.getElementById("MenuOculto").style.padding = "15px 0px"
    document.getElementById("BotPrincipal").style.display = "none"
}

function FechaMenu() {
    document.getElementById("MenuOculto").style.height = "0px"
    document.getElementById("MenuOculto").style.padding = "0px 0px"
    document.getElementById("Principal").style.color = "black"
    document.getElementById("BotPrincipal").style.display = "inline"
}

function TrocaCor1() {
    document.getElementById("BotPrincipal").style.border = "dashed  rgba(11, 0, 170, 0.568)"
    document.getElementById("BotPrincipal").style.color = "rgba(11, 0, 170, 0.568)"
}

function TrocaCor2() {
    document.getElementById("BotPrincipal").style.border = "solid black"
    document.getElementById("BotPrincipal").style.color = "black"
}

function AumentaBotao() {
    document.getElementById("estilo-zap").style.width = "90px"
    document.getElementById("estilo-zap").style.height = "90px"
}

function VoltaBotao() {
    document.getElementById("estilo-zap").style.width = "70px"
    document.getElementById("estilo-zap").style.height = "70px"
}