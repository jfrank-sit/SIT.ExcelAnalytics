namespace SIT.Analytics
open System
open ExcelDna.Integration
    
type xlStatisticFunctions =   
    
    [<ExcelFunction>]
    static member SayHi(toWho:string) = sprintf "Hi %s!" toWho

    [<ExcelFunction>]
    static member GeoMeanReturn(retData) =      
       let retStats = ReturnStatistics(retData)
       retStats.GeoMeanReturn
        
        
