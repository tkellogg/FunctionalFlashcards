module ControllerTests

open Flashcards
open Xunit

type ``Specs for DeckController``() =
    let controller = new DeckController()
    
    [<Fact>]
    member x.``It displays the view for Index() actions``() =
        controller.Index() |> Assert.NotNull

    [<Fact>]
    member x.``It routes to the Index.cshtml view``() =
        let viewName = controller.Index().ViewName 
        Assert.Equal<string>("Index", viewName)
