namespace SIT.Analytics
open System

type ReturnStatistics(retData) =
    let totalReturn data = Array.fold (fun retAcc periodRet -> retAcc * (1. + periodRet) ) 1. data - 1.
    let periodReturn data n = (1. + (totalReturn data)) ** (n / float data.Length) - 1.
    
    //will handle errors more robustly in future
    let ifErrNone func =
        try
            Some func
        with 
        | _ -> None

    member x.TotalReturn = 
        ifErrNone (totalReturn retData)        

    member x.AnnualReturn nPerYear = 
        ifErrNone (periodReturn retData nPerYear)        

    member x.GeoAvgReturn =
        ifErrNone (periodReturn retData 1.)
        