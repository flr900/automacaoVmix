' dim apiVmix as string = API.XML()
' dim x as new system.xml.xmldocument
' x.loadxml(apiVmix)

API.FUNCTION("OverlayInput1Off", Input:= 12)
sleep(250)
API.FUNCTION("OverlayInput1In", Input:= 12)
sleep(800)
API.FUNCTION("OverlayInput1Out", Input:= 12)
sleep(1000) 'com menos de 1 segundo, o conteúdo atualiza antes mesmo de sair da tela, dependendo da transição
API.FUNCTION("DataSourceNextRow", Value:= "GoogleDadosTitle,data")