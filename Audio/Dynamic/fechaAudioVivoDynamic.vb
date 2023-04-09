dim apiVmix as string = API.XML()
   dim x as new system.xml.xmldocument
   x.loadxml(apiVmix)
dim fechaVivo as string = x.selectSingleNode("/vmix/dynamic/value2").innertext

if fechaVivo = "true" then 
    API.FUNCTION("SetDynamicValue2",Value:="false") 
else 
    API.FUNCTION("SetDynamicValue2",Value:="true")
end if