namespace SIT.Analytics
open System


///Statistic type
type Statistic =
    | StatVal
    | Fail of string

type ReturnStatistics(retData) =
    let totalReturn data = Array.fold (fun retAcc periodRet -> retAcc * (1. + periodRet) ) 1. data - 1.
    let periodReturn data n = (1. + (totalReturn data)) ** (n / float data.Length) - 1.
    
    //will handle errors more robustly in future
    let errorCheck func = try Some func with | _ -> None 

    member x.TotalReturn =  totalReturn retData |> errorCheck

    member x.AnnualReturn nPerYear = periodReturn retData nPerYear |> errorCheck     

    member x.GeoAvgReturn = periodReturn retData 1. |> errorCheck
        