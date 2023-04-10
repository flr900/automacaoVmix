'Checando o tempo restante de um vídeo exibido (ou qualquer outro material) para exibição no formato de Title

dim pos as string = ""
dim dur as string = ""
dim activein as string = ""
dim tempResta as double = 0
dim tempTrigger as integer = 10     'tempo restante para término
dim durTrigger as integer = 2000    'duração do fade

dim titleTimerVideo as string = "timerVideo"

do while true 

'Busca dados da API do Vmix em Tempo Real
dim apiVmix as string = API.XML()
dim x as new system.xml.xmldocument
x.loadxml(apiVmix)

activein = (x.selectSingleNode("//active").innerText)
dur = (x.selectSingleNode("//input[@number='"& activein &"']/@duration").value)
pos = (x.selectSingleNode("//input[@number='"& activein &"']/@position").value)

tempResta= double.parse(dur)-double.parse(pos)
tempResta = tempResta/100

dim regressiva as integer = CInt(tempResta)
regressiva = regressiva/10

dim min as integer = regressiva\60
dim sec as integer = regressiva Mod 60

'debug
'console.writeline("regressiva:" + regressiva)
'console.writeline("minutos:" + min)
'console.writeline("tempo restante:" + tempResta)
'console.writeline("segundos:" + sec)

'somente para teste e aprendizado:
'Dim dur As Integer = Convert.ToInt32(apiVmix.SelectSingleNode("//input").Attributes("duration").Value)

dim tempoAtual as string
tempoAtual = min.ToString("00") + ":" + sec.ToString("00")

'Agora começa sa condições para exibição

if tempResta < 60 'then 'teste de sintaxe
    API.FUNCTION("SetText", input:= titleTimerVideo, SelectedIndex:="0", value:=tempResta) 'value:= ":", value:= sec
        if tempResta < 30
        API.FUNCTION("SetTextColour", input:= titleTimerVideo, value:= "red")
        else
        API.FUNCTION("SetTextColour", input:= titleTimerVideo, value:= "orange")
        end if
else
    API.FUNCTION("SetText", input:= titleTimerVideo, SelectedIndex:="0", value:=tempoAtual) 
    API.FUNCTION("SetTextColour", input:= titleTimerVideo, value:= "green")
end if

sleep(50)
loop