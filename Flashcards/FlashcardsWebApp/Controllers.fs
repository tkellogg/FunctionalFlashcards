namespace Flashcards

open System.Web
open System.Web.Mvc
open MongoDB.Driver

[<HandleError>]
type HomeController() =
    inherit Controller()

    member this.Index () =
        this.View() :> ActionResult

[<HandleError>]
type DeckController() =
    inherit Controller()

    let db = MongoDatabase.Create "mongodb://localhost/test"
    let collection = db.GetCollection<Deck> ("decks")

    member this.Index () =
        collection.FindAll () |> List.ofSeq |> this.View

    member this.Add() =
        this.View()

    [<HttpPostAttribute>]
    member this.Add (deck : Deck) =
        let side1 = Side()
        side1.Text <- "this works!!!"
        let card1 = Card()
        card1.Sides <- [ side1 ]
        deck.Cards <- [ card1 ]
        collection.Save deck |> ignore
        this.RedirectToAction "Index"
