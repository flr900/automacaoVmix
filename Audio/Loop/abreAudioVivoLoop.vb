
    'Declara variaveis atrelando ao key de cada input
    dim linha1 as string = "058d8b32-ed73-4df4-9812-ed656bdad5b9"
    dim linha2 as string = "fbc5a08f-0c78-4480-bd53-8fcc059e0e03"


    'Declara quantidade de linhas
    dim linhasKey() as string = {linha1, linha2}
    
    'Ajusta quantidade de linhas para o array de inputs
    dim linhasInput(linhasKey.length - 1) as integer

    'Declara variaveis atrelando a quantidade de telas do preset
    dim telao1 as string = "2"
    dim telao2 as string = "3"


    dim ultimoVivo as integer
    dim cachePgm as integer

    'Inicia o loop principal
    do while true
        'Busca dados da API do Vmix 
        dim apiVmix as string = API.XML()
        dim x as new system.xml.xmldocument
        x.loadxml(apiVmix)

        'Busca o numero do input correspondente ao key de cada sinal
        dim count as integer = 0
        For Each key as string In linhasKey
            linhasInput(count) =  x.selectSingleNode("/vmix/inputs/input[@key = '" & key &"']/@number").innerText
            count = count+1
        Next

        'Declara variaveis condicionais
        dim linhaNoPgm as Boolean = false
        dim ultimoVivoElinha as Boolean = false

        'Busca qual input está plugado em pgm e nas telas'
        dim telao1Index as integer = x.selectSingleNode("/vmix/mix[@number = '" & telao1 & "']/active").innertext''
        dim telao2Index as integer = x.selectSingleNode("/vmix/mix[@number = '" & telao2 & "']/active").innertext'
        dim pgmIndex as integer = x.selectSingleNode("/vmix/active").innertext
        
        'Recebe comando de fechar audio do ultimo vivo
        dim fechaVivo as Boolean = x.selectSingleNode("/vmix/dynamic/value2").innertext

        
        'Grava informação de ultima linha em PGM
        For Each linha As string In linhasInput
            if  pgmIndex = linha then
            linhaNoPgm = true
                if cachePgm = linha then
                ' Console.WriteLine("é igual " & linha)
                else
                ultimoVivo = cachePgm
                cachePgm = linha     
                end if
            end if
        Next

        'Caso o input plugado em PGM não seja uma linha, ajusta a ultima linha plugada
        if not linhaNoPgm then 
            ultimoVivo = cachePgm
            linhaNoPgm = false
        end if

        'Checa se o dado guardado da ultima linha é valido
        For Each linha As string In linhasInput
            if  ultimoVivo = linha then
                ultimoVivoElinha = true
            end if
        Next

        'Fecha o audio do ultimo Vivo
        if fechaVivo then 
            if ultimoVivo <> pgmIndex and ultimoVivoElinha then
                API.FUNCTION("AudioOFF", Input:= ultimoVivo)
                API.FUNCTION("SetDynamicValue2",Value:="false")
            end if
        else
            API.FUNCTION("SetDynamicValue2",Value:="false")  
        end if
    


        'Busca se tem alguma linha em pgm e nas telas e abre o microfone
        For Each linha As integer In linhasInput
            select case linha
                case pgmIndex
                    API.FUNCTION("AudioOn", Input:= linha)
                case telao1Index
                    API.FUNCTION("AudioOn", Input:= linha)
                case telao2Index
                    API.FUNCTION("AudioOn", Input:= linha)    
                case else  
            end select
        Next
        

    Sleep(100)
    loop