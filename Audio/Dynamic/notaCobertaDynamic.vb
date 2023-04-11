'Declara Key do PO
dim po as string = "e48df68b-c25f-4e0c-a5b3-a4d04f70fbc1"

'Busca dados
dim apiVmix as string = API.XML()
   dim x as new system.xml.xmldocument
   x.loadxml(apiVmix)

'Busca Input do PO
dim poIndex = x.selectSingleNode("/vmix/inputs/input[@key = '" & po &"']/@number").innerText

'Ponto importante na ordem! O Cut TEM que vir primeiro que os demais comandos!
API.FUNCTION("Cut", Input:=poIndex)
API.FUNCTION("SetVolume",Value:=30, Input:=poIndex) 
API.FUNCTION("AudioOn", Input:=poIndex)







