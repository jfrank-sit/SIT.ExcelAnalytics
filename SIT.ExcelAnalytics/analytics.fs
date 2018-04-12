namespace SIT.Analytics
open System

type ReturnStatistics(retData) =
    
    member x.TotalReturn = Array.fold (fun retAcc periodRet -> retAcc * (1. + periodRet) ) 1. retData - 1.

    member x.AnnualReturn ?nPerYear = 
        let n = defaultArg nPerYear 12.
        (1. + x.TotalReturn) ** (n / float retData.Length) - 1.

    member x.GeoMeanReturn =
        x.AnnualReturn 1.
        