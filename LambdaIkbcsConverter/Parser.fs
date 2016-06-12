// Simple parser for λ-expressions

// Expecting expressions of the form: 
// lambda: "lambda <VARS>.<BODY>"
// application: "(<VARS>)"

// Examples:
// lambda abc.(cbacba)
// lambda p.(p lambda x.lambda y.x)
// lambda xyz.lambda d.(x(y(zd)))
// lambda x.lambda y.(x(x(x(x(xy)))))
// lambda x.lambda f.(f((xx)f))

// Written by: Yos Apel
// Date: 11/6/16

module Parser

    open Types
    open FParsec

    exception ProcessingError of string

    let pvar = 
        let var = letter |>> (fun x -> RVar (x.ToString()))
        var

    // forward declare the lambda-expression definition (recursive parser)
    let lexpr, pexprImpl = createParserForwardedToRef()

    let papplic = 
        let exprs = lexpr .>> spaces
        let body = (pstring "(" ) >>. spaces >>. (many1 exprs) .>> spaces .>> (pstring ")" )
        body |>> (fun x -> RApplic x)

    let plambda = 
        let keyword = pstring "lambda" 
        let vars = many1 (letter |>> (fun x -> x.ToString()))
        let def = keyword >>. spaces  >>.  vars
        let dot = spaces >>. pstring "." .>> spaces
        let comb = def .>> dot .>>. lexpr |>> (fun (x,y) -> RLambda(x , y))
        comb

    do pexprImpl := choice [ plambda; papplic; pvar]

    // dealing with λ-calc associativity rules
    // examples: MNP may be written instead of ((M N) P)
    // λx.λy.λz.N is abbreviated as λxyz.N
    let rec lprocess raw = 
        match raw with
        | RVar(str) -> Var(str)
        | RLambda (head::[], rexp) -> Lambda(head, lprocess(rexp))
        | RLambda (head::tail, rexp) -> Lambda(head, lprocess(RLambda(tail,rexp)))
        | RApplic (head::[]) -> lprocess(head)
        | RApplic (exp_lst) -> 
            let last = List.last exp_lst
            let lst_but_last  = List.take (List.length exp_lst - 1) exp_lst
            Applic(lprocess(RApplic(lst_but_last)), lprocess(last))
        | _ -> raise (ProcessingError "this should not happen")
        
    let parse str = 
        let res = run plambda str
        match res with 
        | Success(result, _, _)   -> 
            let p = lprocess result in
            printfn "Parse Success: %A" p; Some (p);
        | Failure(errorMsg, _, _) -> printfn "Parse Failure: %s" errorMsg; None;

