'Declara variaveis atrelando ao key de cada input

dim cam1 as string = "fd19d100-4fdf-46da-93c8-9629e9685249"
dim cam2 as string = "9e817c44-4690-4708-b968-234be89b3866"
dim cam3 as string = "24907912-1723-4881-97b8-d08b4d52e420"

dim po as string = "e48df68b-c25f-4e0c-a5b3-a4d04f70fbc1"

dim micTitKey as string = cam1
dim micByKey as string = cam3

dim apiVmix as string = API.XML()
   dim x as new system.xml.xmldocument
   x.loadxml(apiVmix)

'Busca os dados em caso de falha de mic
dim falhaMic as string = x.selectSingleNode("/vmix/dynamic/value1").innertext

'Busca o numero do input correspondente ao key de cada sinal
dim cam1Index as integer = x.selectSingleNode("/vmix/inputs/input[@key = '" & cam1 &"']/@number").innerText
dim cam2Index as integer = x.selectSingleNode("/vmix/inputs/input[@key = '" & cam2 &"']/@number").innerText
dim cam3Index as integer = x.selectSingleNode("/vmix/inputs/input[@key = '" & cam3 &"']/@number").innerText

dim micTit = x.selectSingleNode("/vmix/inputs/input[@key = '" & micTitKey &"']/@number").innerText
dim micBy = x.selectSingleNode("/vmix/inputs/input[@key = '" & micByKey &"']/@number").innerText



if falhaMic = "false" then
       'Garante o mic by fechado
       API.FUNCTION("AudioOff", Input:= micBy)
       'Estrutura de identificação das câmeras em pgm e roda o audio correspondente
       select case pgmIndex
       case cam1Index
              API.FUNCTION("AudioOn", Input:= micTit)
       case cam2Index
              API.FUNCTION("AudioOn", Input:= micTit)
                     case cam3Index
              API.FUNCTION("AudioOn", Input:= micTit)
                     case else
              
       end select
else
       'Garante o mic tit fechado
       API.FUNCTION("AudioOff", Input:= micTit)
       'Estrutura de identificação das câmeras em pgm e roda o audio correspondente
       select case pgmIndex
       case cam1Index
              API.FUNCTION("AudioOn", Input:= micBy)
                     case cam2Index
              API.FUNCTION("AudioOn", Input:= micBy)
                     case cam3Index
              API.FUNCTION("AudioOn", Input:= micBy)
                     case else
              
       end select
end if

