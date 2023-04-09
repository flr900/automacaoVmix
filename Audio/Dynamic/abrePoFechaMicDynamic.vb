'Declara variaveis atrelando ao key de cada input
dim cam1 as string = "fd19d100-4fdf-46da-93c8-9629e9685249"
dim cam2 as string = "9e817c44-4690-4708-b968-234be89b3866"
dim cam3 as string = "24907912-1723-4881-97b8-d08b4d52e420"
dim po as string = "e48df68b-c25f-4e0c-a5b3-a4d04f70fbc1"

'Dclara quais cameras carregam audio
dim micTitKey as string = cam1
dim micByKey as string = cam3

dim apiVmix as string = API.XML()
   dim x as new system.xml.xmldocument
   x.loadxml(apiVmix)

dim poIndex = x.selectSingleNode("/vmix/inputs/input[@key = '" & po &"']/@number").innerText
dim micTit = x.selectSingleNode("/vmix/inputs/input[@key = '" & micTitKey &"']/@number").innerText
dim micBy = x.selectSingleNode("/vmix/inputs/input[@key = '" & micByKey &"']/@number").innerText

dim falhaMic as string = x.selectSingleNode("/vmix/dynamic/value1").innertext

if falhaMic = "true" then 
    API.FUNCTION("SetVolume",Value:=100, Input:=poIndex) 
    API.FUNCTION("AudioOn", Input:=poIndex)
    API.FUNCTION("Cut", Input:=poIndex)
    API.FUNCTION("AudioOff", Input:=micBy) 
else 
    API.FUNCTION("SetDynamicValue1",Value:="true")
    API.FUNCTION("SetVolume",Value:=100, Input:=poIndex) 
    API.FUNCTION("AudioOn", Input:=poIndex)
    API.FUNCTION("Cut", Input:=poIndex)
    API.FUNCTION("AudioOff", Input:=micTit) 
end if


