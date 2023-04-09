'Checando o tempo restante de um vídeo exibido (ou qualquer outro material) para exibição no formato de Title

dim pos as string = ""
dim dur as string = ""
dim activein as string = ""
dim tempResta as double = 0
dim tempTrigger as integer = 10     'tempo restante para término
dim durTrigger as integer = 2000    'duração do fade

dim titleTimer as string = "timerVideo"

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

dim min as integer = regressiva/60
dim sec as integer = regressiva Mod 60

'console.writeline(regressiva)
'console.writeline(sec)

'somente para teste e aprendizado:
'Dim duration As Integer = Convert.ToInt32(xmlDoc.SelectSingleNode("//input").Attributes("duration").Value)

loop