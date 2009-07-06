namespace Bonsai.Runtime
open System
open System.Reflection
open System.Collections.Generic
open Microsoft.Scripting

type Maybe<'a> =
    | Nothing
    | Some of 'a

type IBonsaiFunction = 
    abstract Call:array<Object> -> Object
    
type DelegateBonsaiFunction(calledMethod:MethodInfo) =
    interface IBonsaiFunction with
        member x.Call(args) = 
            match calledMethod.IsStatic with
            | true -> calledMethod.Invoke(args.[0], args.[1..])
            | false -> null

type DictionaryBonsaiFunction(proto:IBonsaiFunction) =
    let dict = new Dictionary<SymbolId, IBonsaiFunction>()
    interface IBonsaiFunction with
        member x.Call(args) = 
            match x.TryCallThis(args) with
            | Some result -> result
            | Nothing -> proto.Call(args)
    member x.TryCallThis(args:array<Object>) = 
        match args.Length with
        | 0 -> Nothing
        | _ -> 
            match args.[0] with
            | :? SymbolId as methodSymbol when dict.ContainsKey(methodSymbol) ->
                Some (dict.[methodSymbol].Call(args))
            | _ -> Nothing
