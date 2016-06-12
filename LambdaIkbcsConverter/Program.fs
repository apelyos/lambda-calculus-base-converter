// Lambda expressions IKBCS-Base converter & parser
// Based on Dr. Mayer Goldberg algorithm found here:
// http://www.little-lisper.org/website/files/lambda-calculus-tutorial.pdf
//
// Advanced Programming Methods Course, 
// Ben-Gurion University of the Negev, 2016
//
// Written by: Yos Apel
// Date: 12/6/16

open Types
open Parser
open System

let get_fvars (exp : lexp) : string list = 
    let rec get_fvars_h exp bound = 
        match exp with
        | Var(a) when not (List.exists ((=) a) bound) -> [a]
        | Applic(e1, e2) -> (get_fvars_h e1 bound)@(get_fvars_h e2 bound)
        | Lambda(x, e1) -> (get_fvars_h e1 (x::bound))
        | _ -> [] in
    get_fvars_h exp []

let fvar_exists var lexp = List.exists ((=) var) (get_fvars lexp)


let rec basify (exp : lexp) : lexp =
    match exp with
    | Base(a) as b -> b
    | Applic(e1, e2) -> Applic(basify e1, basify e2)
    (* I *)
    | Lambda(x1,Var(x2)) when x1 = x2 -> Base(I)
    | Lambda(x, Lambda(y, e1)) -> basify (Lambda(x, basify(Lambda(y, e1))))
    (* K *)  
    | Lambda(x,e1) when not (fvar_exists x e1) -> 
        Applic(Base(K), basify e1)
    (* C *)
    | Lambda(x, Applic(p, q)) when (fvar_exists x p) &&
        not (fvar_exists x q) ->
        Applic(Applic(Base(C), basify (Lambda(x,p))), basify q) 
    (* eta-reduction *)
    | Lambda(x1, Applic(p, Var(x2))) when x1 = x2 && 
        not (fvar_exists x1 p) -> basify p
    (* B *)
    | Lambda(x, Applic(p, q)) when not (fvar_exists x p) &&
        (fvar_exists x q) ->
        Applic(Applic(Base(B), basify p), basify (Lambda(x,q))) 
    (* S *)
    | Lambda(x, Applic(p, q)) when (fvar_exists x p) &&
        (fvar_exists x q) ->
        Applic(Applic(Base(S), basify (Lambda(x,p))), basify (Lambda(x,q))) 
    | e -> e
    

let rec stringify exp = 
    match exp with
        | Var v -> v
        | Applic (e1,e2) -> "(" + stringify e1 + stringify e2 + ")"
        | Lambda (v,e1) -> "lambda " + v + "." + stringify e1 
        | Base I -> "I" | Base K -> "K" | Base B -> "B" | Base C -> "C" | Base S -> "S"
    
    
let run_tests exps = 
    for e in exps do
        printfn "%s -> %s\n" (stringify e) (stringify (basify e))
    done
    
(*
[<EntryPoint>]
let main argv = 
    run_tests Tests.tests;
    0 // exit code
*)    

// See top comment on Parser.fs for λ-expression examples
[<EntryPoint>]
let rec main argv = 
    printf "Enter lambda-calc expression: ";
    let input = Console.ReadLine()
    let res = parse input;
    match res with 
        | None -> ()
        | Some(exp) -> printfn "IKBCS Base: %s\n" (stringify (basify exp))
    main argv;