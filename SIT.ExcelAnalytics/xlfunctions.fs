namespace SIT.Analytics
open System
open ExcelDna.Integration
open System.ComponentModel
    
type xlStatisticFunctions =   
    
    [<ExcelFunction>]
    static member SayHi(toWho:string) = sprintf "Hi %s!" toWho

    [<ExcelFunction(Name="GeoMeanReturn", Description="Geometric average of a return series", Category="Analytics", IsThreadSafe=true, IsVolatile=true)>]
    static member GeoMeanReturn([<ExcelArgument(Name="ReturnSeries", Description="Return series")>] retData) =      
       let retStats = ReturnStatistics(retData)
       retStats.GeoMeanReturn
        
        
