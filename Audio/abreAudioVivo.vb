'Busca dados da API do Vmix

do while true
    dim apiVmix as string = API.XML()
    dim x as new system.xml.xmldocument
    x.loadxml(apiVmix)


    dim linha1 as string = "058d8b32-ed73-4df4-9812-ed656bdad5b9"
    dim linha2 as string = "fbc5a08f-0c78-4480-bd53-8fcc059e0e03"

    dim linha1Index as integer = x.selectSingleNode("/vmix/inputs/input[@key = '" & linha1 &"']/@number").innerText
    dim linha2Index as integer = x.selectSingleNode("/vmix/inputs/input[@key = '" & linha2 &"']/@number").innerText

    dim telao1 as string = "2"
    dim telao2 as string = "3"

    dim telao1Index as string = x.selectSingleNode("/vmix/mix[@number = '" & telao1 & "']/active").innertext
    dim telao2Index as string = x.selectSingleNode("/vmix/mix[@number = '" & telao2 & "']/active").innertext

    dim pgmIndex as integer = x.selectSingleNode("/vmix/active").innertext

    ' do while true
        select case telao1Index
            case linha1Index
                API.FUNCTION("AudioOn", Value:=linha1)
                ' exit do
            case linha2Index
                API.FUNCTION("AudioOn", Value:=linha2)
                ' exit do
            case else
                Console.WriteLine("Outro Tela 1")
        end select

        select case telao2Index
            case linha1Index
                API.FUNCTION("AudioOn", Value:=linha1)
                ' exit do
            case linha2Index
                API.FUNCTION("AudioOn", Value:=linha2)
                ' exit do
            case else
                Console.WriteLine("Outro Tela 2")
        end select

        select case pgmIndex
            case linha1Index
                API.FUNCTION("AudioOn", Value:=linha1)
                ' exit do
            case linha2Index
                API.FUNCTION("AudioOn", Value:=linha2)
                ' exit do
            case else
                Console.WriteLine("Outro pgm")
                ' exit do
        end select
    ' loop
Sleep(1000)
loop