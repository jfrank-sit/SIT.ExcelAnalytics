namespace SIT.Analytics
open System

type ReturnStatistics(retData) =
    
    member x.TotalReturn = 
        try
            Some (Array.fold (fun retAcc periodRet -> retAcc * (1. + periodRet) ) 1. retData - 1.)
        with 
        | _ -> None

    member x.AnnualReturn nPerYear = 
        match x.TotalReturn with 
        | Some tr ->  Some ((1. + tr) ** (nPerYear / float retData.Length) - 1.)
        | None -> None

    member x.GeoMeanReturn =
        x.AnnualReturn 1.
        