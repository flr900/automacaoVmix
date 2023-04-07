dim cam1 as string = "fd19d100-4fdf-46da-93c8-9629e9685249"
dim cam2 as string = "9e817c44-4690-4708-b968-234be89b3866"
dim cam3 as string = "24907912-1723-4881-97b8-d08b4d52e420"

dim micTit as string = cam1
dim micBy as string = cam3

'Busca dados da API do Vmix em Tempo Real
do while true

dim apiVmix as string = API.XML()
   dim x as new system.xml.xmldocument
   x.loadxml(apiVmix)

dim falhaMic as string = x.selectSingleNode("/vmix/dynamic/value1").innertext
   
dim pgmIndex as integer = x.selectSingleNode("/vmix/active").innertext

dim cam1Index as integer = x.selectSingleNode("/vmix/inputs/input[@key = '" & cam1 &"']/@number").innerText
dim cam2Index as integer = x.selectSingleNode("/vmix/inputs/input[@key = '" & cam2 &"']/@number").innerText
dim cam3Index as integer = x.selectSingleNode("/vmix/inputs/input[@key = '" & cam3 &"']/@number").innerText

if falhaMic = "false" then
 select case pgmIndex
     case cam1Index
            API.FUNCTION("AudioOn", Input:= micTit)
            Console.Writeline("Cam1")
     case cam2Index
            API.FUNCTION("AudioOn", Input:= micTit)
            Console.Writeline("Cam2")
     case cam3Index
            API.FUNCTION("AudioOn", Input:= micTit)
            Console.Writeline("Cam3")
     case else
            Console.WriteLine("Outro")
    end select
else
 select case pgmIndex
     case cam1Index
            API.FUNCTION("AudioOn", Input:= micBy)
            Console.Writeline("Cam1")
     case cam2Index
            API.FUNCTION("AudioOn", Input:= micBy)
            Console.Writeline("Cam2")
     case cam3Index
            API.FUNCTION("AudioOn", Input:= micBy)
            Console.Writeline("Cam3")
     case else
            Console.WriteLine("Outro")
    end select
end if

Console.WriteLine("Input em PGM: "& pgmIndex)
Sleep(100)
loop
