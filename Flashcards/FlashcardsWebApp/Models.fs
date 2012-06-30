namespace Flashcards.Models

open MongoDB.Bson
open MongoDB.Bson.Serialization
open MongoDB.Bson.Serialization.Attributes

type Side = { Text : string }

type public Card = { Sides : int list }

type Deck() =  
    let mutable cards = []
    let mutable id = BsonObjectId.GenerateNewId()
    let mutable title = "N/A"

    member this.Id
        with get() = id
        and set value = id <- value

    member this.Cards
        with get() = cards
        and set value = cards <- value

    member this.Title
        with get() = title
        and set value = title <- value

module Setups =
    let SetupMongo () =
        if BsonClassMap.IsClassMapRegistered(typedefof<Deck>) |> not then
            BsonClassMap.RegisterClassMap<Deck>() |> ignore
