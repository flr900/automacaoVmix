'Declara variaveis atrelando ao key de cada input
dim cam1 as string = "fd19d100-4fdf-46da-93c8-9629e9685249"
dim cam2 as string = "9e817c44-4690-4708-b968-234be89b3866"
dim cam3 as string = "24907912-1723-4881-97b8-d08b4d52e420"

'Dclara quais cameras carregam audio
dim micTitKey as string = cam1
dim micByKey as string = cam3


'Declara quantidade de linhas
dim camKey() as string = {cam1, cam2, cam3}

'Ajusta quantidade de linhas para o array de inputs
dim camInput(camKey.length - 1) as integer

'incia o loop
do while true

    'Busca dados da API do Vmix em Tempo Real
    dim apiVmix as string = API.XML()
    dim x as new system.xml.xmldocument
    x.loadxml(apiVmix)


    'Busca o numero do input correspondente ao key de cada sinal
    dim count as integer = 0
    For Each key as string In camKey
        camInput(count) =  x.selectSingleNode("/vmix/inputs/input[@key = '" & key &"']/@number").innerText
        count = count+1
    Next

    'Pega o Input de cada microfone
    dim micTit = x.selectSingleNode("/vmix/inputs/input[@key = '" & micTitKey &"']/@number").innerText
    dim micBy = x.selectSingleNode("/vmix/inputs/input[@key = '" & micByKey &"']/@number").innerText

    'Busca qual input está plugado em pgm
    dim pgmIndex as integer = x.selectSingleNode("/vmix/active").innertext

    'Busca os dados em caso de falha de mic
    dim falhaMic as string = x.selectSingleNode("/vmix/dynamic/value1").innertext
    'Condiciona caso tenha que ir para o mic by
    
    if falhaMic = "false" then
           'Garante o mic by fechado
           API.FUNCTION("AudioOff", Input:= micBy)
           'Estrutura de identificação das câmeras em pgm e roda o audio correspondente
           For Each camera As string In camInput
                if camera = pgmIndex then
                    API.FUNCTION("AudioOn", Input:= micTit)
                end if
           Next
           
    else
           'Garante o mic tit fechado
           API.FUNCTION("AudioOff", Input:= micTit)
           'Estrutura de identificação das câmeras em pgm e roda o audio correspondente
           For Each camera As string In camInput
                if camera = pgmIndex then
                    API.FUNCTION("AudioOn", Input:= micBy)
                End If
           Next
    end if
    Sleep(100)
loop