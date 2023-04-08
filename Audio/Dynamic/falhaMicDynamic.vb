dim apiVmix as string = API.XML()
   dim x as new system.xml.xmldocument
   x.loadxml(apiVmix)
dim falhaMic as string = x.selectSingleNode("/vmix/dynamic/value1").innertext

Console.WriteLine(falhaMic)

if falhaMic = "true" then 
    API.FUNCTION("SetDynamicValue1",Value:="false") 
else 
    API.FUNCTION("SetDynamicValue1",Value:="true")
end if