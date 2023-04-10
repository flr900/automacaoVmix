do while true

'Busca dados da API do Vmix em Tempo Real
dim apiVmix as string = API.XML()
dim x as new system.xml.xmldocument
x.loadxml(apiVmix)

dim input1 as XmlNode = x.SelectSingleNode("//text[@name='flag1.Text']")
dim input2 as XmlNode = x.SelectSingleNode("//text[@name='flag2.Text']")
dim input3 as XmlNode = x.SelectSingleNode("//text[@name='flag3.Text']")
dim input4 as XmlNode = x.SelectSingleNode("//text[@name='flag4.Text']")
dim input5 as XmlNode = x.SelectSingleNode("//text[@name='flag5.Text']")

dim convIn1 as integer = Integer.Parse(input1.InnerText)
dim output1 as string = convIn1.tostring

dim convIn2 as integer = Integer.Parse(input2.InnerText)
dim output2 as string = convIn2.tostring

dim convIn3 as integer = Integer.Parse(input3.InnerText)
dim output3 as string = convIn3.tostring

dim convIn4 as integer = Integer.Parse(input4.InnerText)
dim output4 as string = convIn4.tostring

dim convIn5 as integer = Integer.Parse(input5.InnerText)
dim output5 as string = convIn5.tostring

dim titleIn as string = "flagTitle"

console.writeline(output1)
console.writeline(output2)
console.writeline(output3)
console.writeline(output4)
console.writeline(output5)
console.writeline("next")

sleep(2000)

'Para teste de escrita
API.Function("SetText", Input:= titleIn, SelectedName:= "flag1.Text", value:= 8001)
'Function=SetText&Input=flagTitle&SelectedName=flag1.text&Value=800

loop