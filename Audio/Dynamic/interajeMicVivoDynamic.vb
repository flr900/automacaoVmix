'Declara variaveis atrelando ao key de cada input
dim cam1 as string = "fd19d100-4fdf-46da-93c8-9629e9685249"
dim cam2 as string = "9e817c44-4690-4708-b968-234be89b3866"
dim cam3 as string = "24907912-1723-4881-97b8-d08b4d52e420"

'Dclara quais cameras carregam audio
dim micTitKey as string = cam1
dim micByKey as string = cam3

    'Busca dados da API do Vmix em Tempo Real
    dim apiVmix as string = API.XML()
    dim x as new system.xml.xmldocument
    x.loadxml(apiVmix)
    
    'Busca microfones
    dim micTit = x.selectSingleNode("/vmix/inputs/input[@key = '" & micTitKey &"']/@number").innerText
    dim micBy = x.selectSingleNode("/vmix/inputs/input[@key = '" & micByKey &"']/@number").innerText
    
    'Busca os dados em caso de falha de mic
    dim falhaMic as string = x.selectSingleNode("/vmix/dynamic/value1").innertext

        'Condiciona caso tenha que ir para o mic by
    if falhaMic = "false" then
           'Abre Mic correspondente
           API.FUNCTION("AudioOn", Input:= micTit)
    else
       'Abre Mic correspondente
        API.FUNCTION("AudioOn", Input:= micBy)
    end if