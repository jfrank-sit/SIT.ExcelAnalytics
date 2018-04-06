namespace SIT.ExcelAnalytics
open System
open ExcelDna.Integration
    
type xlStatisticFunctions =
    [<ExcelFunction>]
    static member SayHi(toWho:string) = sprintf "Hi %s!" toWho
        
